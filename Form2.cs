using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user=textBoxUser.Text;
            string pwd=textBoxPwd.Text;
            string name=textBoxName.Text;
            int sex=GetSex();
            int state=GetState();
            int role=GetRole();
            try 
            {
                SqlConnection conn = SQLHelp.GetSqlConnection();

                SqlCommand cmd = SQLHelp.GetSqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"insert into [User] values (@user,@pwd,@name,@sex,@state,@role)";

                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@role", role);

                int i = cmd.ExecuteNonQuery();

                if (i != 0)
                    labelZC.Text = "注册成功";
                else
                    labelZC.Text = "注册失败";

                conn.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetSex() 
        {
            int i = 0;
            ICollection collection =panelSex.Controls;
            foreach (Control c in collection) 
            {
                RadioButton rd= (RadioButton)c;
                if (rd.Checked)
                {
                    i = rd.Text.Equals("男") ? 1 : 0;
                    break;
                }
            }
            Console.WriteLine(i);
            return i;
        }

        private int GetState() 
        {
            int i=0;
            ICollection collection =panelState.Controls;
            foreach (Control c in collection) 
            {
                RadioButton rd= (RadioButton)c;
                if (rd.Checked)
                {
                    i = rd.Text.Equals("冻结") ? 1 : 2;
                    break;
                }
            }
            Console.WriteLine(i);
            return i;
        }

        private int GetRole() 
        {
            int i = 0;
            ICollection collection =panelRole.Controls;
            foreach (Control c in collection)
            {
                RadioButton rd= (RadioButton)c;
                if (rd.Checked)
                {
                    switch (rd.Text)
                    {
                        case "工作人员": i = 1;
                            break;
                        case "管理员":  i = 2;
                            break;
                        case "教师":    i = 3;
                            break;
                        case "学生":    i = 4;
                            break;

                    }
                    break;
                }
            }
            Console.WriteLine(i);
            return i;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Blue);

            int startX = 30;
            int startY = this.ClientSize.Height / 10;
            int endX = this.ClientSize.Width-30;
            int endY = this.ClientSize.Height / 10;

            //Point star = new Point(0,40);
            //Point end=new Point(600,40);

            g.DrawLine(pen, startX, startY, endX, endY);
            pen.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(OnPaint);
        }
    }
}
