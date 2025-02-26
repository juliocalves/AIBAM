using AIBAM.Classes;
using AIBAM.Controles;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Diagnostics;

namespace AIBAM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
           
            Application.Run(new FrmPrincipal());
        }
    }
}
