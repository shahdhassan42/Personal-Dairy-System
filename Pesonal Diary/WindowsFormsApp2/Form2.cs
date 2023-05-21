using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        String title;
        string ordb = "Data source=orcl;User Id=hr; password=hr;";
        //string ordb = "Data source=orcl;User Id=scott; password=tiger;";

        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

   
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            title = textBox3.Text;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetRequiredHrs";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("title", title);
            cmd.Parameters.Add("hrs", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            int x = Convert.ToInt32(cmd.Parameters["hrs"].Value.ToString());
            textBox4.Text = x.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ViewCheckedTasks";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username", textBox6.Text);
            cmd.Parameters.Add("checked_tasks", OracleDbType.RefCursor, ParameterDirection.Output);


            OracleDataReader dr = cmd.ExecuteReader();
            listBox2.Items.Clear();
            while (dr.Read())
            {
                listBox2.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ViewUncheckedTasks";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username", textBox6.Text);
            cmd.Parameters.Add("unchecked_tasks", OracleDbType.RefCursor, ParameterDirection.Output);


            OracleDataReader dr = cmd.ExecuteReader();
            listBox2.Items.Clear();
            while (dr.Read())
            {

                listBox2.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}
