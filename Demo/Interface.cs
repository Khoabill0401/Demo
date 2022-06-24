#region Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Xceed.Wpf.Toolkit;
#endregion

namespace Ankobim
{
    /// <summary>
    /// Reference;
    /// 1. http://bit.ly/2l3Jsf6
    /// 2. https://autode.sk/2mtSaUb
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    // Dang ky giao dien



    public class Interface : IExternalApplication
    {
        public string RootFolder;
        public string ContentsFolder;
        public string SettingFolder;
        public string DllFolder;
        public string Dllfile;
        public Result OnStartup(UIControlledApplication application)
        {


            #region Copy folder vao C:
            Dllfile = "Demo.dll";
            DllFolder = @"D:\API\Demo\Demo\bin\Debug";
            RootFolder = @"D:\API\Demo\Ankobim.bundle";

            string sourceFile = Path.Combine(DllFolder, Dllfile);

            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2017\dll\Demo.dll", true);
            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2018\dll\Demo.dll", true);
            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2019\dll\Demo.dll", true);
            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2020\dll\Demo.dll", true);
            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2021\dll\Demo.dll", true);
            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2022\dll\Demo.dll", true);
            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2023\dll\Demo.dll", true);
            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2024\dll\Demo.dll", true);
            File.Copy(sourceFile, @"D:\API\Demo\Ankobim.bundle\Contents\2025\dll\Demo.dll", true);



            ContentsFolder = @"C:\ProgramData\Autodesk\ApplicationPlugins\Ankobim.bundle\Contents";
            SettingFolder = @"C:\ProgramData\Autodesk\ApplicationPlugins\Ankobim.bundle\Contents\Resources\Setting";

            Directory.CreateDirectory(ContentsFolder);
            Directory.CreateDirectory(SettingFolder);

            //Copy all the files & Replaces any files with the same name
            string[] files = Directory.GetFiles(RootFolder);
            foreach (string s in files)
            {
                string fileName = Path.GetFileName(s);
                string destFile = Path.Combine(ContentsFolder, fileName);
                File.Copy(s, destFile, true);
            }

            #endregion

            //ABConstraint abConstraint = new ABConstraint();
            //RibbonUtils ribbonUtils = new RibbonUtils(application.ControlledApplication);

            // Create Tab name Ankobim
            application.CreateRibbonTab("Ankobim");

            // Create Group (RibbonPanel) About us
            RibbonPanel rbWeb = application.CreateRibbonPanel("Ankobim", "www.ankobim.com");
            rbWeb.Enabled = true;
            rbWeb.Visible = true;
            rbWeb.Name = "Ankobim";
            rbWeb.Title = "www.ankobim.com";
            // Create button About in group website
            PushButton btHello = rbWeb.AddItem(new PushButtonData("Ankobim", "About us!", @"D:\API\Demo\Demo\bin\Debug\Demo.dll", "Ankobim.HelloCmd")) as PushButton;
            // Set ToolTip Help
            btHello.ToolTip = "© 2022 ANKOBIM All Rights Reserved";
            ContextualHelp Help = new ContextualHelp(ContextualHelpType.Url, "http://ankobim.com/");
            btHello.SetContextualHelp(Help);
            // Setup Image Button
            Uri imgHello = new Uri(@"D:\API\Demo\Demo\02.Image\Logo\32x32.ico");
            BitmapImage img_Hello = new BitmapImage(imgHello);
            btHello.LargeImage = img_Hello;


            // Create Group (RibbonPanel) General

            #region Create Push Button

            // Create Group (RibbonPanel) General
            RibbonPanel rbGen = application.CreateRibbonPanel("Ankobim", "General");
            rbGen.Enabled = true;
            rbGen.Visible = true;
            rbGen.Name = "General";
            rbGen.Title = "General";

            // CreateGridCmd
            PushButton btGrid1 = rbGen.AddItem(new PushButtonData("CreateGridCmd", "Create Grid", @"D:\API\Demo\Demo\bin\Debug\Demo.dll", "Ankobim.CreateGridCmd")) as PushButton;
            // Set ToolTip Help
            btGrid1.ToolTip = "Click 2 points to create new grid";
            ContextualHelp Help2 = new ContextualHelp(ContextualHelpType.Url, "http://ankobim.com/");
            btGrid1.SetContextualHelp(Help2);
            // Setup Image Button
            Uri imgHello2 = new Uri(@"D:\API\Demo\Demo\02.Image\Icon\grid32x32.ico");
            BitmapImage img_Hello2 = new BitmapImage(imgHello2);
            btGrid1.LargeImage = img_Hello2;

           


            // ModelFromCAD
            PushButton btCad = rbGen.AddItem(new PushButtonData("ModelFromCAD", "Create columns from CAD", @"D:\API\Demo\Demo\bin\Debug\Demo.dll", "Ankobim.ColumnFromCadCmd")) as PushButton;
            // Set ToolTip Help
            btCad.ToolTip = "Pick CAD layer to automatically model columns";
            ContextualHelp Help3 = new ContextualHelp(ContextualHelpType.Url, "http://ankobim.com/");
            btCad.SetContextualHelp(Help3);
            // Setup Image Button
            Uri imgCad = new Uri(@"D:\API\Demo\Demo\02.Image\Icon\colfromcad32x32.ico");
            BitmapImage img_Cad = new BitmapImage(imgCad);
            btCad.LargeImage = img_Cad;

            #endregion


            // Done

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }   

    }
}
