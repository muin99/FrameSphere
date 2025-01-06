using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class RegisteredEvents : Form
    {
        public RegisteredEvents()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            RegistrationForm f1 = new RegistrationForm();
            this.Close();
            f1.Show();
        }

        private void RegisteredEvents_Load(object sender, EventArgs e)
        {

        }
    }
}
