#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;

#endregion

namespace Cofragem
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            //get location
            string curAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string curAssemblyPath = System.IO.Path.GetDirectoryName(curAssembly);

            //Ribbon tab creation
            string thisNewTabName = "VE-Menu";
            string thisNewPanelName = "Tools";

            try
            {
                a.CreateRibbonTab(thisNewTabName);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
            }
            //Button creation
            PushButtonData pb1 = new PushButtonData("Paint", "Paint", curAssembly, "Cofragem.Command");
            pb1.LargeImage = new BitmapImage(new Uri(System.IO.Path.Combine(curAssemblyPath, "cf_logo.ico")));
            pb1.ToolTip = "Aplica pintura em multiplos elementos.";
            pb1.LongDescription = "Copiar o nome de um material existente que será utilizado como pintura nos elementos selecionados. Antes da utilização os elementos desejados devem ser selecionados.";

            try
            {
                //Add ribbon panel
                RibbonPanel curPanel = a.CreateRibbonPanel(thisNewTabName, thisNewPanelName);
                PushButton pushButton1 = (PushButton)curPanel.AddItem(pb1);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
                //Add button to panel
                List<RibbonPanel> list = a.GetRibbonPanels(thisNewTabName);

                foreach (RibbonPanel curPanel in list)
                {
                    string panelName = curPanel.Name;

                    if (panelName == thisNewPanelName)
                    {
                        PushButton pushButton1 = (PushButton)curPanel.AddItem(pb1);
                    }
                }
            }
            return Result.Succeeded;

        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
