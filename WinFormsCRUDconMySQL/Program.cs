<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCRUDconMySQL
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
=======
namespace WinFormsCRUDconMySQL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
>>>>>>> 3108f7a (Agregar archivos de proyecto.)
        /// </summary>
        [STAThread]
        static void Main()
        {
<<<<<<< HEAD
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
=======
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
>>>>>>> 3108f7a (Agregar archivos de proyecto.)
