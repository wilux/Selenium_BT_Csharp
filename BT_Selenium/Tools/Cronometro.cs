using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace BT_Selenium.Tools
{
    /*
     * Clase para Cronometrar
     */
    public static class Cronometro
    {
        static Stopwatch timer = new Stopwatch();
        static int segundosTranscurridos;

        public static void start()
        {

            segundosTranscurridos = 0;
            timer.Start();


        }

        public static void stop(string mensaje)
        {
         TimeSpan timeTaken = timer.Elapsed;
         segundosTranscurridos = (int)(timeTaken.TotalSeconds);
        Console.WriteLine(mensaje+" : "+segundosTranscurridos);
          }


    }
}
