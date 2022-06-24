#region Namespaces
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using Autodesk.Revit.DB.Structure;
#endregion 

namespace Ankobim
{
    public partial class ColumnFromCadWindow
    {
        private ColumnFromCadViewModel _viewModel;
        readonly ABConstraint abConstraint = new ABConstraint();
        private TransactionGroup transG;

        public ColumnFromCadWindow(ColumnFromCadViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;
            Icon = abConstraint.IconWindow;
            transG = new TransactionGroup(_viewModel.Doc);
        }


        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            #region Lấy về maximum những element cần chạy

            List<PlanarFace> hatchToCreateColumn =
                CadUtils.GetHatchHaveName(_viewModel.SelectedCadLink,
                    _viewModel.SelectedLayer);

            List<ColumnData> allColumnsData
                = new List<ColumnData>();

            foreach (PlanarFace hatch in hatchToCreateColumn)
            {
                ColumnData columnData = new ColumnData(hatch);
                allColumnsData.Add(columnData);
            }

            #endregion

            ProgressWindow.Maximum = allColumnsData.Count;
            transG.Start("Run Process");

            #region Code

            List<ElementId> newColumns = new List<ElementId>();
            double value = 0;

            foreach (ColumnData columnData in allColumnsData)
            {
                if (transG.HasStarted())
                {
                    #region Setup cho ProgressBar nhảy % tiến trình

                    value = value + 1;
                    _viewModel.Percent
                        = value / ProgressWindow.Maximum * 100;

                    ProgressWindow.Dispatcher?.Invoke(() => ProgressWindow.Value = value,
                        DispatcherPriority.Background);

                    #endregion

                    #region Viết Code ở đây

                    FamilySymbol familySymbol
                        = FamilyUtils.GetFamilySymbolColumn(_viewModel.SelectedFamilyColumn, columnData.CanhNgan, columnData.CanhDai, "b", "h");

                    if (familySymbol == null) continue;

                    using (Transaction tran = new Transaction(_viewModel.Doc, "Create Column"))
                    {
                        tran.Start();

                        DeleteWarningSuper warningSuper = new DeleteWarningSuper();
                        FailureHandlingOptions failOpt = tran.GetFailureHandlingOptions();
                        failOpt.SetFailuresPreprocessor(warningSuper);
                        tran.SetFailureHandlingOptions(failOpt);

                        FamilyInstance instance = _viewModel.Doc.Create
                            .NewFamilyInstance(columnData.TamCot,
                            familySymbol, _viewModel.BaseLevel, StructuralType.Column);

                        instance.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_PARAM)
                            .SetValue(_viewModel.BaseLevel.Id);
                        instance.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_PARAM)
                            .Set(_viewModel.TopLevel.Id);

                        instance.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM)
                            .Set(ABUnitUtils.MmToFeet(_viewModel.BaseOffset));

                        instance.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM)
                            .Set(ABUnitUtils.MmToFeet(_viewModel.TopOffset));

                        Line axis = Line.CreateUnbound(columnData.TamCot, XYZ.BasisZ);
                        ElementTransformUtils.RotateElement(_viewModel.Doc,
                            instance.Id, axis,
                            columnData.GocXoay);

                        newColumns.Add(instance.Id);
                        tran.Commit();
                        //_viewModel.UiDoc.Selection.SetElementIds(new List<ElementId>() { instance.Id });
                    }

                    #endregion
                }
                else
                {
                    break;
                }
            }

            #endregion

            if (transG.HasStarted())
            {
                transG.Commit();
                DialogResult = true;

                TaskDialog.Show(string.Concat("Success: ", newColumns.Count, " elements!"),
                    "Success", TaskDialogCommonButtons.Ok, TaskDialogResult.Ok);

                _viewModel.UiDoc.Selection.SetElementIds(newColumns);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            if (transG.HasStarted())
            {
                transG.RollBack();
                TaskDialog.Show("Progress is Cancel!", "Stop Progress",
                    TaskDialogCommonButtons.Cancel, TaskDialogResult.Cancel);
            }
        }

        private void ColumnFromCadWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (transG.HasStarted())
            {
                DialogResult = false;
                transG.RollBack();
                TaskDialog.Show("Progress is Cancel!", "Stop Progress",
                    TaskDialogCommonButtons.Cancel, TaskDialogResult.Cancel);
            }
        }
    }
}
