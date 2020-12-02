using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace DataAdapter_ADO_NET
{
    public partial class Form1 : Form
    {
        SqlDataAdapter adapter ;
        SqlCommandBuilder cmd;
        DataSet set;
        SqlConnection connection;
        ListView listView1;
        static int i = 0;

        public Form1()
        {
            InitializeComponent();
            tab.Visible = false;
            
        }

        private void btn_Fill_Click(object sender, EventArgs e)
        {
            listView1 = new ListView();
            tab.Visible = true;
            TabPage page = new TabPage();
            tab.TabPages.Add(page.Text = "Tab " + i.ToString());
            i++;
            page.Select();
            page.Controls.Add(listView1);
            listView1.Items.Clear();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);
            SqlCommand command = new SqlCommand(txbx_Select.Text, connection);
            try
            {

                adapter = new SqlDataAdapter(command);
                set = new DataSet();
                adapter.Fill(set);
                foreach (DataRow ds in set.Tables[0].Rows)
                {
                    ListViewItem item = new ListViewItem(ds["Title"].ToString());
                    item.SubItems.Add(ds["Price"].ToString());
                    item.SubItems.Add(ds["Pages"].ToString());
                    item.SubItems.Add(ds["AuthorId"].ToString());
                    listView1.Items.Add(item);
                }
              


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    
    }
}
//connection.Open();
//reader = command.ExecuteReader();
//while (reader.Read())
//{
//    ListViewItem item = new ListViewItem(reader["Title"].ToString());
//    item.SubItems.Add(reader["Price"].ToString());
//    item.SubItems.Add(reader["Pages"].ToString());
//    item.SubItems.Add(reader["AuthorId"].ToString());

//    listView1.Items.Add(item);
//}



//DataTable table = new DataTable();
//adapter.Fill(table);
//foreach(DataRow dr in table.Rows)
//{
//    ListViewItem item = new ListViewItem(dr["Title"].ToString());
//    item.SubItems.Add(dr["Price"].ToString());
//    item.SubItems.Add(dr["Pages"].ToString());
//    item.SubItems.Add(dr["AuthorId"].ToString());

//    listView1.Items.Add(item);
//}



//DataTable table = new DataTable();
//adapter.Fill(table);
//for(int i = 0; i < table.Rows.Count; i++)
//{
//    ListViewItem item = new ListViewItem(table.Rows[i]["Title"].ToString());
//    item.SubItems.Add(table.Rows[i]["Price"].ToString());
//    item.SubItems.Add(table.Rows[i]["Pages"].ToString());
//    item.SubItems.Add(table.Rows[i]["AuthorId"].ToString());

//    listView1.Items.Add(item);
//}

