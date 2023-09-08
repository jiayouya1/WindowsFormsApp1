using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {

        Form6 form6 = new Form6();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text =$"{User.Usid},欢迎使用图示系统！你是{User.Name}";
            timer1.Enabled = true;
            jz();
        }

        private void jz() 
        {
            form6.TopLevel = false;
            form6.Dock= DockStyle.Fill;
            panel1.Controls.Add(form6);
            form6.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4=new Form4();
            f4.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab==tabPage1)
                form6.Visible= true;
        }
    }
}
