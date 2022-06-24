#region Namespaces

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI.Selection;

#endregion

namespace Ankobim
{
    public class ColumnFromCadViewModel : ViewModelBase
    {
        public UIDocument UiDoc;
        public Document Doc;
        public ImportInstance SelectedCadLink;

        private double _percent;
        public double Percent
        {
            get => _percent;
            set
            {
                _percent = value;

                // Thông báo cho WPF là property "Percent" đã thay đổi giá trị,
                // WPF hãy thay đổi theo
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Hàm khởi tạo đối tượng thuộc lớp ColumnFromCadViewModel
        /// </summary>
        /// <param name="uidoc"></param>
        public ColumnFromCadViewModel(UIDocument uidoc)
        {
            // Lưu trữ data từ Revit
            UiDoc = uidoc;
            Doc = UiDoc.Document;

            // khởi tạo data cho WPF

            Reference r = UiDoc.Selection.PickObject(ObjectType.Element,
                new ImportInstanceSelectionFilter(), "CHỌN CAD LINK");
            SelectedCadLink = Doc.GetElement(r) as ImportInstance;

            AllLayers = CadUtils.GetAllLayer(SelectedCadLink);
            // AllLayers = SelectedCadLink.GetAllLayer();

            SelectedLayer = AllLayers[0];

            AllFamiliesColumn = new FilteredElementCollector(Doc)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .Where(f => f.FamilyCategory.Name.Equals("Structural Columns")
                            || f.FamilyCategory.Name.Equals("Columns")
                            )
                .ToList();

            SelectedFamilyColumn = AllFamiliesColumn[0];

            AllLevel = new FilteredElementCollector(Doc)
                .OfClass(typeof(Level))
                .Cast<Level>().ToList();
            AllLevel = AllLevel.OrderBy(l => l.Elevation)
                .ToList();

            BaseLevel = AllLevel[0];
            TopLevel = AllLevel[1];
        }

        #region Khai báo Binding Properties 
        public List<string> AllLayers { get; set; }
        public string SelectedLayer { get; set; }
        public List<Family> AllFamiliesColumn { get; set; }
        public Family SelectedFamilyColumn { get; set; }
        public List<Level> AllLevel { get; set; }
        public Level BaseLevel { get; set; }
        public Level TopLevel { get; set; }
        public double BaseOffset { get; set; }
        public double TopOffset { get; set; }

        #endregion Khai báo biến & properties

    }
}
