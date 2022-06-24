#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Application = Autodesk.Revit.ApplicationServices.Application;
#endregion

namespace Ankobim
{
    [Transaction(TransactionMode.Manual)]
    public class CreateGridCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //code

            ObjectSnapTypes snapSettings = ObjectSnapTypes.Endpoints;

            XYZ point1 = uidoc.Selection.PickPoint(snapSettings, "Chọn điểm 1");
            XYZ point2 = uidoc.Selection.PickPoint("Chọn điểm 2");

            Line line2 = Line.CreateBound(point1, point2);

            using (Transaction trans = new Transaction(doc))
            {
                trans.Start("Tạo lưới trục tự động");

                Grid grid1 = Grid.Create(doc, line2);
                //if (grid1.Name == "1") { }
                //else { };
                grid1.Name = "1";

                trans.Commit();
            }

            return Result.Succeeded;
        }
    }
}
