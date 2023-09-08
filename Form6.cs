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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {

        public Form6()
        {
            InitializeComponent();
        }

        public void ResetDataGridView(SqlConnection conn,bool b)
        {
            if (b == true)
            {
                string str = "select * from Book";
                SqlCommand cmd = new SqlCommand(str, conn);
                FillDataGridView(conn, cmd);
            }
            else
            {
                string str = "select * from backupTable";
                SqlCommand cmd = new SqlCommand(str, conn);
                FillDataGridView(conn, cmd);
            }
        }

        public void FillDataGridView(SqlConnection conn,SqlCommand cmd) 
        {
            dataGridView1.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            bindingSource1.DataSource = dt;
            dataGridView1.DataSource = bindingSource1;

            string str4 = "select id,tname from BookType";
            SqlCommand cmd4 = new SqlCommand(str4, conn);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd4);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = dt2;

            UpdateTreeView();
            
            ((DataGridViewComboBoxColumn)dataGridView1.Columns["bookType"]).DataSource = bindingSource2;
            ((DataGridViewComboBoxColumn)dataGridView1.Columns["bookType"]).DisplayMember = "tname";
            ((DataGridViewComboBoxColumn)dataGridView1.Columns["bookType"]).ValueMember = "id";

            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{
            //    dataGridView1.Rows[i].Cells["bookType"].Value = dt.Rows[i]["btid"];
            //}

            conn.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            UpdateTreeView();
            SqlConnection conn = SQLHelp.GetSqlConnection();

            ResetDataGridView(conn,true);
           
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            SqlConnection conn=SQLHelp.GetSqlConnection();

            if (treeView1.SelectedNode.Text != "图书类别")
            {
                if (treeView1.SelectedNode.Parent.Text == "图书类别")
                {
                    //父节点
                    string str = "select * from Book b inner join BookType bt on bt.id=b.btid where bt.tname=@tname";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    string tname = treeView1.SelectedNode.Text;
                    cmd.Parameters.AddWithValue("@tname", tname);

                    FillDataGridView(conn, cmd);
                }
                else
                {
                    //子节点
                    string str = "select * from Book where bname=@bname";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    string bname = treeView1.SelectedNode.Text;
                    cmd.Parameters.AddWithValue("@bname", bname);

                    FillDataGridView(conn, cmd);

                }
            }
            else
            {
                ResetDataGridView(conn, true);
            }
        }

        public void UpdateTreeView() 
        {
            treeView1.Nodes.Clear();

            SqlConnection conn = SQLHelp.GetSqlConnection();
            string str1 = "select id,tname from BookType";
            SqlCommand cmd1 = new SqlCommand(str1, conn);
            SqlDataReader sdr1 = cmd1.ExecuteReader();

            TreeNode rootNode = new TreeNode("图书类别");
            treeView1.Nodes.Add(rootNode);
            List<Tuple<int, string>> btl = new List<Tuple<int, string>>();

            while (sdr1.Read())
            {
                int tid = Convert.ToInt32(sdr1["id"]);
                string tname = sdr1["tname"].ToString();

                btl.Add(new Tuple<int, string>(tid, tname));
            }
            sdr1.Close();
            foreach (var btItem in btl)
            {
                int tid = btItem.Item1;
                string tname = btItem.Item2;

                TreeNode childNode = new TreeNode(tname);
                childNode.Tag = tid;
                rootNode.Nodes.Add(childNode);

                string str2 = "select btid,bname from Book where btid=@tid";
                SqlCommand cmd2 = new SqlCommand(str2, conn);
                cmd2.Parameters.AddWithValue("@tid", tid);

                SqlDataReader sdr2 = cmd2.ExecuteReader();

                while (sdr2.Read())
                {
                    string bname = sdr2["bname"].ToString();
                    TreeNode subChildNode = new TreeNode(bname);
                    childNode.Nodes.Add(subChildNode);
                }
                sdr2.Close();
            }
            conn.Close();
            treeView1.ExpandAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string bname="%"+textBox1.Text+"%";
            SqlConnection conn= SQLHelp.GetSqlConnection();

            string str = "select * from Book where bname like @bname";
            SqlCommand cmd=new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@bname",bname);

            FillDataGridView(conn, cmd);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //已选中
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["selectRow"].Value = true;
                }
            }
            else 
            {
                //取消选中
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["selectRow"].Value = false;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User.Id = 0;
            Form5 f5=new Form5();
            f5.ShowDialog();

            SqlConnection conn = SQLHelp.GetSqlConnection();
            ResetDataGridView(conn, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int counti = 0;
            SqlConnection conn=SQLHelp.GetSqlConnection();
            int rowCount=dataGridView1.Rows.Count;

            for (int i = 0; i < rowCount-1; i++)
            {
                DataGridViewCheckBoxCell cbc= dataGridView1.Rows[i].Cells["selectRow"] as DataGridViewCheckBoxCell;
                if (cbc != null)
                {
                    bool isChecked = Convert.ToBoolean(cbc.Value);
                    if (isChecked)
                    {
                        if (checkBox2.Checked)
                        {
                            int id = (int)dataGridView1.Rows[i].Cells["id"].Value;
                            string str = "delete from backupTable where id=@id";
                            SqlCommand cmd = new SqlCommand(str, conn);
                            cmd.Parameters.AddWithValue("@id", id);
                            int count = cmd.ExecuteNonQuery();
                            if (count != 0)
                                counti++;
                        }
                        else
                        {
                            int id = (int)dataGridView1.Rows[i].Cells["id"].Value;
                            string str = "delete from Book where id=@id";
                            SqlCommand cmd = new SqlCommand(str, conn);
                            cmd.Parameters.AddWithValue("@id", id);
                            int count = cmd.ExecuteNonQuery();
                            if (count != 0)
                                counti++;
                        }
                    }
                }
            }

            if (counti != 0)
            {
                MessageBox.Show($"删除成功,删除{counti}行");
                ResetDataGridView(conn,true);
                checkBox2.Checked = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                int counti = 0;
                SqlConnection conn = SQLHelp.GetSqlConnection();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    DataGridViewCheckBoxCell cbc = dataGridView1.Rows[i].Cells["selectRow"] as DataGridViewCheckBoxCell;
                    if (cbc != null && cbc.Value != null)
                    {
                        int bid = (int)dataGridView1.Rows[i].Cells["encode"].Value;
                        string str = "insert into Book select bid,bname,btid,amount,price,inTime,bimage,remark from backupTable where bid=@bid";
                        SqlCommand cmd = new SqlCommand(str, conn);
                        cmd.Parameters.AddWithValue("@bid", bid);
                        int count=cmd.ExecuteNonQuery();
                        if(count!=0)
                        {
                            string str2 = "delete from backupTable where bid=@bid";
                            SqlCommand cmd2= new SqlCommand(str2, conn);
                            cmd2.Parameters.AddWithValue("@bid",bid);
                            int count2=cmd2.ExecuteNonQuery();
                            if (count2 != 0)
                                counti++;
                        }
                    }
                }
                if (counti != 0)
                {
                    MessageBox.Show($"恢复成功，恢复{counti}行");
                    ResetDataGridView(conn, true);
                    checkBox2.Checked = false;
                }
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection conn = SQLHelp.GetSqlConnection();
            if (checkBox2.Checked)
            {
                ResetDataGridView(conn, false);
            }
            else
            {
                ResetDataGridView(conn, true);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection conn=SQLHelp.GetSqlConnection();
            if (!checkBox2.Checked)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["bupdate"].ColumnIndex)
                {
                    DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                    BookUpdate(clickedRow,conn);
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["bdele"].ColumnIndex)
                {
                    DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                    Bookdelete(clickedRow,conn);
                }
            }
            else
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["recover"].ColumnIndex)
                {
                    DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                    BookRecover(clickedRow,conn);
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["remove"].ColumnIndex)
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                BookRemove(clickedRow,conn);
            }
        }

        private void BookUpdate(DataGridViewRow clickedRow,SqlConnection conn) 
        {
            int bid = Convert.ToInt32(clickedRow.Cells["encode"].Value);
            string bname = clickedRow.Cells["bookName"].Value.ToString();
            int btype = Convert.ToInt32(clickedRow.Cells["bookType"].Value);
            int price = Convert.ToInt32(clickedRow.Cells["price"].Value);
            int amount = Convert.ToInt32(clickedRow.Cells["amount"].Value);

            int id = Convert.ToInt32(clickedRow.Cells["id"].Value);
            DateTime time = SQLGetData.GetBookInTime(conn,id);

            string str = "update Book set bid=@bid,bname=@bname,btid=@btype,amount=@amount,price=@price,inTime=@inTime where id=@id";
            SqlCommand cmd=new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@bid",bid);
            cmd.Parameters.AddWithValue("@bname", bname);
            cmd.Parameters.AddWithValue("@btype", btype);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@inTime",time);
            cmd.Parameters.AddWithValue("@id",id);

            int count=cmd.ExecuteNonQuery();

            if (count != 0)
            {
                UpdateTreeView();
            }

        }

        private void Bookdelete(DataGridViewRow clickedRow,SqlConnection conn)
        {
            int id = Convert.ToInt32(clickedRow.Cells["id"].Value);

            string str1 = "delete from Book where id=@id";
            SqlCommand cmd = new SqlCommand(str1, conn);
            cmd.Parameters.AddWithValue("@id", id);

            int count = cmd.ExecuteNonQuery();
            if (count != 0)
            {
                ResetDataGridView(conn, true);
            }
        }
        private void BookRecover(DataGridViewRow clickedRow,SqlConnection conn)
        {
            int id = Convert.ToInt32(clickedRow.Cells["id"].Value);
            int bid = Convert.ToInt32(clickedRow.Cells["encode"].Value);
            string bname = clickedRow.Cells["bookName"].Value.ToString();
            int btype = Convert.ToInt32(clickedRow.Cells["bookType"].Value);
            int amount = Convert.ToInt32(clickedRow.Cells["amount"].Value);
            int price = Convert.ToInt32(clickedRow.Cells["price"].Value);

            DateTime time = SQLGetData.GetBackupTableInTime(conn,id);

            string str = "insert into Book(bid,bname,btid,amount,price,inTime) values (@bid,@bname,@btype,@amount,@price,@inTime)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@bid", bid);
            cmd.Parameters.AddWithValue("@bname", bname);
            cmd.Parameters.AddWithValue("@btype", btype);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@inTime", time);

            int count = cmd.ExecuteNonQuery();
            if (count != 0)
            {
                string str2 = "delete  from backupTable where bid=@bid";
                SqlCommand cmd3 = new SqlCommand(str2, conn);
                cmd3.Parameters.AddWithValue("@bid",bid);
                int count2= cmd3.ExecuteNonQuery();
                if (count2 != 0)
                {
                    ResetDataGridView(conn, true);
                    checkBox2.Checked = false;
                }
            }
        }
        private void BookRemove(DataGridViewRow clickedRow,SqlConnection conn)
        {
            int id = Convert.ToInt32(clickedRow.Cells["id"].Value);

            string str = "delete from Book where id=@id";
            SqlCommand cmd= new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@id",id);
            int count= cmd.ExecuteNonQuery();
            if (count != 0)
            {
                string str2 = "delete from backupTable where id=@id";
                SqlCommand cmd2 = new SqlCommand(str2, conn);
                cmd2.Parameters.AddWithValue("@id", id);
                int count2 = cmd2.ExecuteNonQuery();

                if (count2 != 0)
                {
                    ResetDataGridView(conn, true);
                }
            }
        }
    }
}
