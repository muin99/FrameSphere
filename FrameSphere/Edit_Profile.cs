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

namespace FrameSphere
{
    public partial class Edit_Profile : Form
    {
        public Edit_Profile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //Validation
            if (string.IsNullOrWhiteSpace(FirstNameField.Text) ||
                string.IsNullOrWhiteSpace(LastNameField.Text) ||
                string.IsNullOrWhiteSpace(EmailField.Text) ||
                string.IsNullOrWhiteSpace(CurrentPWField.Text))
        
            {
                MessageBox.Show("All fields are required. Please fill in all the details.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = DB.Connect())
            {

                string query = $@"
                        UPDATE AllUser
                        SET FirstName = '{FirstNameField.Text}',
                        LastName = '{LastNameField.Text}',
                        Email = '{EmailField.Text}'
                        WHERE Password = 'a' and Username = '';
                        ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        int rowsChanged = cmd.ExecuteNonQuery();
                        if (rowsChanged > 0)
                        {
                            MessageBox.Show("Information updated successfully");

                        }
                        else { MessageBox.Show("Password may be incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }



            }
        }
    }
}
//UPDATE UserContact\r\nSET Address = 'thiscity',\r\n    Email = 'ra@',\r\n\tPhone = '73823',\r\n\t\r\n"