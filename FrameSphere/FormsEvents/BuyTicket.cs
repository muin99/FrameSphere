using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            title.Text = currentEvent.EventTitle;
            organizer.Text = currentEvent.EventDescription;
            starts.Text = currentEvent.StartsAt.ToString();
            ends.Text = currentEvent.EndsAt.ToString();
            price.Text = (currentEvent.RegistrationType == "Free") ? "Free" : currentEvent.TicketPrice.ToString();
            cover.Image = FSystem.GetImageFromPath(currentEvent.PosterImage);
            amountToPay_field.Text = currentEvent.TicketPrice.ToString();
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void BuyTicket_Load(object sender, EventArgs e)
        {
           
        }

        private void checkout_button_Click(object sender, EventArgs e)
        {
            if(bKashOption_button.Checked || VisaOption_button.Checked)
            {
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        connection.Open();
                        string query = $"insert into UserEvent values('{FSystem.loggedInUser.UserName}','{currentEvent.EventID}','Visitor');";
                        using(SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Payment successful","Done", MessageBoxButtons.OK);


                }
                catch(Exception err) { throw err; }
                
            }
            else { MessageBox.Show("Please choose a payment option","Payment Option",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }
    }
}
