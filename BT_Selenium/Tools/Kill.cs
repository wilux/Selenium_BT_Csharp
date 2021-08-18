using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace BT_Selenium.Tools
{
    /*
     * Clase para manejar las esperas explicitas
     */
    public class Kill
    {

        //Capture
        //capture screenshot along file name

        public static void IE()
        {

            //IEDriverServer.exe
            //iexplore.exe
            if (Process.GetProcessesByName("iexplore").Length > 0)
            {
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("iexplore"))
                    {
                        proc.Kill();
                    }
                }
                catch //(Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                }
            }
            if (Process.GetProcessesByName("IEDriverServer").Length > 0)
            {
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("IEDriverServer"))
                    {
                        proc.Kill();
                    }
                }
                catch //(Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }

        }

    }
}
