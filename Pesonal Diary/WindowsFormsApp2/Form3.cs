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
    public partial class Form3 : Form
    {
        string conn = "Data Source= orcl; User Id = hr ; Password = hr;";
        //string conn = "Data Source= orcl; User Id = scott ; Password = tiger;";
        OracleDataAdapter adapter;
        DataSet dataset;
        OracleCommandBuilder builder;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string command = "select * from tasks " +
                "where title=:task_title";


            adapter = new OracleDataAdapter(command, conn);

            adapter.SelectCommand.Parameters.Add("task_title", textBox3.Text);
            dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string command = "select *  from journals";

            adapter = new OracleDataAdapter(command, conn);

            dataset = new DataSet();

            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(dataset.Tables[0]);
        }
        private void label1_Click_1(object sender, EventArgs e) { }


        private void textBox3_TextChanged_1(object sender, EventArgs e){ }

        private void button4_Click(object sender, EventArgs e)
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

