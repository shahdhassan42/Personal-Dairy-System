using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        Form1 form1 = new Form1();
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        Form4 form4 = new Form4();
        Form6 form6 = new Form6();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Show();
            form2.Hide();
            form3.Hide();
            form4.Hide();
            form6.Hide();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            form2.Show();
            form1.Hide();
            form3.Hide();
            form4.Hide();
            form6.Hide();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            form3.Show();
            form1.Hide();
            form2.Hide();
            form4.Hide();
            form6.Hide();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            form4.Show();
            form1.Hide();
            form2.Hide();
            form3.Hide();
            form6.Hide();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            form6.Show();
            form1.Hide();
            form2.Hide();
            form3.Hide();
            form4.Hide();
            this.Hide();
        }

    }
}
