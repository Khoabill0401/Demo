#region Namespaces
using System;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
#endregion

namespace Ankobim
{
    public class ABConstraint
    {
        #region Khai bao Field Constraint

        public string RootFolder;
        public string ContentsFolder;
        public string ResourcesFolder;
        public string HelpFolder;
        public string ImageFolder;
        public string SettingFolder;
        public string DllFolder;
        public BitmapImage IconWindow;
        public string HelperPath;

        #endregion

        public ABConstraint(ControlledApplication a = null)
        {

            #region Khoi tao gia tri cho cac Field Constraint

            ContentsFolder = @"C:\ProgramData\Autodesk\ApplicationPlugins\Ankobim.bundle\Contents";
            SettingFolder = @"C:\ProgramData\Autodesk\ApplicationPlugins\Ankobim.bundle\Contents\Resources\Setting";


            ResourcesFolder = Path.Combine(ContentsFolder, "Resources");
            HelpFolder = Path.Combine(ResourcesFolder, "Help");
            ImageFolder = Path.Combine(ResourcesFolder, "Image");
            //HelperPath = Path.Combine(HelperPath, "WELCOME TO ANKOBIM.pdf");

            string iconWindowPath = Path.Combine(ImageFolder, "About.ico");
            Uri iconWindowUri = new Uri(iconWindowPath, UriKind.Relative);
            IconWindow = new BitmapImage(iconWindowUri);

            if (a != null)
            {
                switch (a.VersionNumber)
                {
                    case "2017":
                        DllFolder = Path.Combine(ContentsFolder, "2017", "dll");
                        break;
                    case "2018":
                        DllFolder = Path.Combine(ContentsFolder, "2018", "dll");
                        break;
                    case "2019":
                        DllFolder = Path.Combine(ContentsFolder, "2019", "dll");
                        break;
                    case "2020":
                        DllFolder = Path.Combine(ContentsFolder, "2020", "dll");
                        break;
                    case "2021":
                        DllFolder = Path.Combine(ContentsFolder, "2021", "dll");
                        break;
                    case "2022":
                        DllFolder = Path.Combine(ContentsFolder, "2022", "dll");
                        break;
                    case "2023":
                        DllFolder = Path.Combine(ContentsFolder, "2023", "dll");
                        break;
                    case "2024":
                        DllFolder = Path.Combine(ContentsFolder, "2024", "dll");
                        break;
                    case "2025":
                        DllFolder = Path.Combine(ContentsFolder, "2025", "dll");
                        break;
                }
            }

            #endregion Khai bao cac bien
        }
    }
}
