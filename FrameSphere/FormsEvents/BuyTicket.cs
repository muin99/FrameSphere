using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsEvents
{
    public partial class BuyTicket : Form
    {
        Event currentEvent;
        public BuyTicket(Event ee)
        {
            this.currentEvent = ee;
            InitializeComponent();
        }
    }
}
