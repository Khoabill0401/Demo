#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Ankobim
{
    // Tao ra 1 lech thuc thi
    [Transaction(TransactionMode.Manual)]
    class HelloCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Ankobim", "Welcome to Ankobim!");
            return Result.Succeeded;
        }
    }
}
