using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FrameSphere.EntityClasses
{
    public class Artist : User
    {
        public int NumberOfArts { get; private set; } = 0;
        public List<Art> HisArts = new List<Art>();
        public List<Art> myArts = new List<Art>();
        public void loadArtList()
        {
            if (isArtist)
            {
                string query = $"select artId from ArtArtist where username = '{this.UserName}'";
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(query, connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int aid = Int32.Parse(reader["ArtId"].ToString());
                            Art a = new Art(aid);
                            myArts.Add(a);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN LOADING ARTIST DATA: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN LOADING ARTIST DATA: " + e.Message);
                    return;
                }
                
            }
        }

        public Artist(string UserName) : base(UserName)
        {
        }
        public void AddArt(Art art)
        {
            HisArts.Add(art);
            NumberOfArts++;
        }

        
    }
}
