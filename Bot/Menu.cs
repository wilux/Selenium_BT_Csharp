using BT_Selenium.Task;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    class Menu
    {

        public static void Main(string[] args)
            {

            Browser browser = new Browser();
            bool salir = false;

                while (!salir)
                {

                    try
                    {

                        Console.WriteLine("1. Ingresar a BT y loguearse");
                        Console.WriteLine("2. Simular Productos");
                        Console.WriteLine("3. Opción 3");
                        Console.WriteLine("4. Salir");
                        Console.WriteLine("Elige una de las opciones");
                        int opcion = Convert.ToInt32(Console.ReadLine());
                  

                    switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("Has elegido la opción 1");

                            browser.login();
                            break;

                            case 2:
                                Console.WriteLine("Has elegido iniciar una simulación");
                            Console.WriteLine("Ingrese el CUIL del cliente: ");
                            string cuil = Console.ReadLine();
                            browser.Simular(cuil);
                                break;

                            case 3:
                                Console.WriteLine("Has elegido la opción 3");
                                break;
                            case 4:
                                Console.WriteLine("Has elegido salir de la aplicación");
                                salir = true;
                            browser.Salir();
                  
                            break;
                            default:
                                Console.WriteLine("Elige una opcion entre 1 y 4");
                                break;
                        }

                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.ReadLine();

            }
        }
    }

