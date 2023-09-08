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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        private string selectPath=null;
        

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = SQLHelp.GetSqlConnection();
            try 
            {
                if (User.Id == 0)
                {
                    string str = "insert into Book values (@bookid,@bookname,@booktype,@amount,@bookprice,@time,@image,@bookremake)";
                    
                    int count = GetCount(conn, str,true);
                    if (count != 0)
                        MessageBox.Show("保存成功");
                }
                else
                {
                    string str = "update Book set bid = @bookid, bname = @bookname, btid = @booktype, amount = @amount, price = @bookprice, inTime = @time, bimage = @image,remark=@bookremake WHERE id = @id";
                    
                    int count = GetCount(conn, str,false);
                    if (count != 0)
                        MessageBox.Show("更新成功");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private int GetCount(SqlConnection conn,string str,bool b) 
        {
            int id = 0;
            int bookid = Convert.ToInt32(textBoxBookId.Text);
            if (b == false)
            {
                id = SQLGetData.GetId(conn, User.Id);
            }
            string bookname = textBoxBookName.Text;
            string booktype = comboBoxBookType.SelectedValue.ToString();
            decimal bookprice = numericUpDownBookPrice.Value;
            int amount = Convert.ToInt32(numericUpDownAmount.Value);
            DateTime time = dateTimePicker1.Value;
            string image = selectPath;
            string bookremake = textBoxBookRemake.Text;

            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@bookid", bookid);
            cmd.Parameters.AddWithValue("@bookname", bookname);
            cmd.Parameters.AddWithValue("@booktype", booktype);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@bookprice", bookprice);
            cmd.Parameters.AddWithValue("@time", time);
            if (image != null)
                cmd.Parameters.AddWithValue("@image", image);
            else
                cmd.Parameters.AddWithValue("@image", DBNull.Value);
            if (bookremake != null)
                cmd.Parameters.AddWithValue("@bookremake", bookremake);
            else
                cmd.Parameters.AddWithValue("@bookremake", DBNull.Value);

            if (b == false)
                cmd.Parameters.AddWithValue("@id",id);

            int count = cmd.ExecuteNonQuery();

            return count;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            SqlConnection conn=SQLHelp.GetSqlConnection();
            string str ="select * from BookType";
            SqlDataAdapter adapter = SQLHelp.GetDataAdapter(conn,str);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
           
            comboBoxBookType.DataSource = dt;
            comboBoxBookType.DisplayMember = "tname";
            comboBoxBookType.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片文件 (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectPath = openFileDialog.FileName;
                pictureBox1.Image=Image.FromFile(selectPath);
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g= e.Graphics;
            Pen pen=new Pen(Color.Blue);

            int startX = 0;
            int startY = this.ClientSize.Height/11;
            int endX = this.ClientSize.Width;
            int endY = this.ClientSize.Height / 11;

            //Point star = new Point(0,40);
            //Point end=new Point(600,40);

            g.DrawLine(pen,startX,startY,endX,endY);
            pen.Dispose();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(OnPaint);
            if (User.Id != 0)
            {
                int bid = User.Id;

                SqlConnection conn = SQLHelp.GetSqlConnection();

                string str = "select * from Book where bid=@bid";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@bid", bid);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                textBoxBookId.Text = table.Rows[0]["bid"].ToString();
                textBoxBookName.Text = table.Rows[0]["bname"].ToString();
                label10_Click(label10, EventArgs.Empty);
                comboBoxBookType.SelectedIndex = ((int)table.Rows[0]["btid"]) - 1;
                numericUpDownBookPrice.Value = (decimal)table.Rows[0]["price"];
                numericUpDownAmount.Value = (int)table.Rows[0]["amount"];
                dateTimePicker1.Value = (System.DateTime)table.Rows[0]["inTime"];
                if (!Convert.IsDBNull(table.Rows[0]["bimage"]) && table.Rows[0]["bimage"] != null)
                    pictureBox1.Image = Image.FromFile((string)table.Rows[0]["bimage"]);
                if (!Convert.IsDBNull(table.Rows[0]["remark"]) && table.Rows[0]["remark"] != null)
                    textBoxBookRemake.Text = (string)table.Rows[0]["remark"];
                conn.Close();
            }
        }
    }
}
