using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.D3Program;
using FrameSphere.EntityClasses;
using FrameSphere.FormsArts;
namespace FrameSphere
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            //Application.Run(new Form1());
            //Application.Run(new ArtReviewPage(7));
        }
    }
}
