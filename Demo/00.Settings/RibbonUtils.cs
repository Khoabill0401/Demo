#region Namespaces
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
#endregion

namespace Ankobim
{
    public class RibbonUtils
    {
        private ABConstraint abConstraint;
        private string imageFolder;
        private string dllFolder;

        public RibbonUtils(ControlledApplication a)
        {
            abConstraint = new ABConstraint(a);
            imageFolder = abConstraint.ImageFolder;
            dllFolder = abConstraint.DllFolder;
        }

        /// <summary>
        /// Create a PushButtonData
        /// </summary>
        /// <param name="name">Unique Name</param>
        /// <param name="displayName">Name will be display on Ribbon</param>
        /// <param name="dllName">name of file .dll, include extension, eg. FormworkArea.dll</param>
        /// <param name="fullClassName">include Namespace and name of class inherited from IExternalCommand, eg. Ankobim.FormworkAreaCmd</param>
        /// <param name="image">eg. Icon32x32.png</param>
        /// <param name="tooltip"></param>
        /// <param name="helperPath">link to help file: pdf</param>
        /// <param name="longDescription"></param>
        /// <param name="tooltipImage"></param>
        /// <returns></returns>
        /// 

        public PushButtonData CreatePushButtonData(
            string name, string displayName,
            string dllName, string fullClassName,
            string image, string tooltip,
            string helperPath = null,
            string longDescription = null,
            string tooltipImage = null)

        {
            //PushButtonData pushButtonData = new PushButtonData(name, displayName,
            //    dllFolder + "\\" + dllName,
            //    fullClassName);


            //string path = @"C:\ProgramData\Autodesk\ApplicationPlugins\Ankobim.bundle\Contents\";
            //string path2 = Path.Combine(dllFolder, dllName);

            PushButtonData pushButtonData = new PushButtonData(name, displayName, Path.Combine(dllFolder, dllName), fullClassName);

            // image appears when create single PushButton
            pushButtonData.LargeImage = CreateBitmapImage(imageFolder, image);

            // smaller image appears when create PushButton for ItemStacked
            pushButtonData.Image = CreateBitmapImage(imageFolder, image);

            pushButtonData.ToolTip = tooltip;

            if (!string.IsNullOrEmpty(tooltipImage))
            {
                Uri tooltipUri = new Uri(Path.Combine(imageFolder, tooltipImage),
                    UriKind.Absolute);
                pushButtonData.ToolTipImage = new BitmapImage(tooltipUri);
            }

            if (!string.IsNullOrEmpty(helperPath))
            {
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.ChmFile,
                    helperPath);
                pushButtonData.SetContextualHelp(contextHelp);
            }

            if (longDescription != null)
            {
                pushButtonData.LongDescription = longDescription;
            }

            return pushButtonData;
        }

        /// <summary>
        /// Initialization data for PulldownButton
        /// </summary>
        /// <param name="name">Only name</param>
        /// <param name="displayName">The name shown on Ribbon bar</param>
        /// <param name="tooltip"></param>
        /// <param name="image"></param>
        /// <param name="helperPath"></param>
        /// <param name="toolTipImage"></param>
        /// <returns></returns>
        /// 

        public PulldownButtonData CreatePulldownButtonData(
            string name,
            string displayName,
            string tooltip,
            string image,
            string helperPath = null,
            string toolTipImage = null)
        {
            PulldownButtonData pulldownButtonData = pulldownButtonData = new PulldownButtonData(name, displayName);

            pulldownButtonData.ToolTip = tooltip;

            if (!string.IsNullOrEmpty(helperPath))
            {
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.ChmFile,
                    helperPath);
                pulldownButtonData.SetContextualHelp(contextHelp);
            }

            if (!string.IsNullOrEmpty(image))
            {
                pulldownButtonData.Image
                    = CreateBitmapImage(imageFolder, image);
            }

            if (!string.IsNullOrEmpty(toolTipImage))
            {
                pulldownButtonData.ToolTipImage
                    = CreateBitmapImage(imageFolder, toolTipImage);
            }

            return pulldownButtonData;
        }

        /// <summary>
        /// Add a PulldownButton to a Panel.
        /// </summary>
        /// <param name="ribbonPanel"></param>
        /// <param name="name">Unique Name</param>
        /// <param name="displayName">Name will be displayed on Ribbon</param>
        /// <param name="tooltip"></param>
        /// <param name="largeImage"></param>
        /// <param name="toolTipImage"></param>
        /// <param name="helperPath"></param>
        /// <returns></returns>
        public PulldownButton CreatePulldownButton(
            RibbonPanel ribbonPanel,
            string name, string displayName,
            string tooltip,
            string largeImage,
            string toolTipImage = null,
            string helperPath = null)
        {

            PulldownButtonData pulldownButtonData
                = new PulldownButtonData(name, displayName);
            pulldownButtonData.ToolTip = tooltip;


            if (!string.IsNullOrEmpty(helperPath))
            {
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.ChmFile,
                    helperPath);
                pulldownButtonData.SetContextualHelp(contextHelp);
            }

            if (!string.IsNullOrEmpty(largeImage))
            {
                pulldownButtonData.LargeImage
                    = CreateBitmapImage(imageFolder, largeImage);
            }

            if (!string.IsNullOrEmpty(toolTipImage))
            {
                pulldownButtonData.ToolTipImage
                    = CreateBitmapImage(imageFolder, toolTipImage);
            }

            return ribbonPanel.AddItem(pulldownButtonData) as PulldownButton;
        }


        /// <summary>
        /// Add a SplitButton to a Panel
        /// </summary>
        /// <param name="ribbonPanel"></param>
        /// <param name="name">Unique Name</param>
        /// <param name="displayName">Name will be display on Ribbon</param>
        /// <param name="tooltip"></param>
        /// <param name="helperPath"></param>
        /// <returns></returns>
        public SplitButton CreateSplitButton(
            RibbonPanel ribbonPanel,
            string name,
            string displayName,
            string tooltip,
            string helperPath = null)
        {
            SplitButtonData splitButtonData = new SplitButtonData(name, displayName);
            splitButtonData.ToolTip = tooltip;

            if (!string.IsNullOrEmpty(helperPath))
            {
                ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.ChmFile,
                        helperPath);
                splitButtonData.SetContextualHelp(contextHelp);
            }

            return ribbonPanel.AddItem(splitButtonData) as SplitButton;
        }

        /// <summary>
        /// Create BitmapImage
        /// </summary>
        /// <param name="imageFolders">eg. "C:\ProgramData\Autodesk\ApplicationPlugins\Ankobim.bundle\Contents\Resources\Image"</param>
        /// <param name="image">eg. Match32x32.png</param>
        /// <returns></returns>
        public BitmapImage CreateBitmapImage(string imageFolder, string image)
        {
            string pathImage = Path.Combine(imageFolder, image);

            Uri iconUri = new Uri(pathImage, UriKind.Absolute);
            return new BitmapImage(iconUri);
        }
    }
}
