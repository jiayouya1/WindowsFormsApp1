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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname=textBoxUser.Text;
            string pwd=textBoxPwd.Text;

            try
            {
                SqlConnection conn = SQLHelp.GetSqlConnection();
                string str = @"select usid,name from [User] u
                inner join [Role] r on u.roleid=r.id 
                where usid=@name and pwd=@pwd";
                SqlCommand cmd = SQLHelp.GetSqlCommand(conn,str);
                cmd.Connection = conn;
                cmd.CommandText = str;
                cmd.Parameters.AddWithValue("@name", uname);
                cmd.Parameters.AddWithValue("@pwd", pwd);

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    User.Usid = sdr[0].ToString();
                    User.Name = sdr[1].ToString();
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.ShowDialog();
                    this.Show();
                }
                else
                    labelTiShi.Text = "账号密码错误！";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }
    }
}
