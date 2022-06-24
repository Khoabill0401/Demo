#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Application = Autodesk.Revit.ApplicationServices.Application;
#endregion

namespace Ankobim
{
    [Transaction(TransactionMode.Manual)]
    public class CreateLevelCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //doc

            using (Transaction tran = new Transaction(doc))
            {
                tran.Start("Tạo Level");

                Level level = Level.Create(doc, AnkobimUnitUtils.MeterToFeet(5));

                level.Name = "Level 1";

                tran.Commit();
            }

            return Result.Succeeded;
        }
    }
}
