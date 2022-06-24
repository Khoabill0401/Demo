#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Application = Autodesk.Revit.ApplicationServices.Application;
#endregion

namespace Ankobim
{
    [Transaction(TransactionMode.Manual)]
    public class ColumnFromCadCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // code

            ColumnFromCadViewModel viewModel
                = new ColumnFromCadViewModel(uidoc);

            ColumnFromCadWindow window
                = new ColumnFromCadWindow(viewModel);

            if (window.ShowDialog() == false) return Result.Cancelled;

            return Result.Succeeded;
        }
    }
}
