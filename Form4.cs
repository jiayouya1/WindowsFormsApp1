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

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User.Id = 0;
            Form5 f5= new Form5();
            this.Hide();
            f5.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                User.Id = 1;
                int id = Convert.ToInt32(textBox1.Text);
                SqlConnection conn = SQLHelp.GetSqlConnection();
                string str = "select count(*) from Book where bid=@bid";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@bid", id);
                int count = (int)cmd.ExecuteScalar();
                if (count != 0)
                {
                    User.Id = id;
                    Form5 f5 = new Form5();
                    this.Hide();
                    f5.ShowDialog();
                    this.Show();
                    string str2 = "select * from Book where bid=@id";
                    SqlCommand cmd2 = new SqlCommand(str2, conn);
                    cmd2.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = cmd2.ExecuteReader();
                    while (sdr.Read())
                    {
                        textBoxXinxi.Text = $"{sdr["bid"]}  {sdr["bname"]}  {sdr["btid"]}  {sdr["amount"]}  {sdr["price"]}  {sdr["inTime"]}  {sdr["bimage"]}  {sdr["remark"]}";
                    }
                    sdr.Close();
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
