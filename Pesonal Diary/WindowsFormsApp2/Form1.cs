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
    public partial class Form1 : Form
    {
        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        //string ordb = "Data source=orcl;User Id=scott;Password=tiger;";

        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select title from tasks";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select task_date,checked,hrs_required,user_username,worked_hrs from tasks where title=:title";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if(dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into tasks values(:title,:user_username,:task_date,:checked,:hrs_required,:worked_hrs)";
            cmd.Parameters.Add("title",comboBox1.Text);
            cmd.Parameters.Add("user_username", textBox1.Text);
            cmd.Parameters.Add("task_date", textBox2.Text);
            cmd.Parameters.Add("checked",textBox3.Text);
            cmd.Parameters.Add("hrs_required", textBox4.Text);
            cmd.Parameters.Add("worked_hrs", textBox5.Text);



            int r = cmd.ExecuteNonQuery();
            if (r != 0)
            {
                comboBox1.Items.Add(comboBox1.Text);
                MessageBox.Show("new task is added","Message");
                comboBox1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
