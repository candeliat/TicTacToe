using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _3x3 form2 = new _3x3();

            // Form2'yi göster
            form2.Show();

            // İsteğe bağlı: Form1'i gizle
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _5x5 form3 = new _5x5();

            // Form2'yi göster
            form3.Show();

            // İsteğe bağlı: Form1'i gizle
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _7x7 form4 = new _7x7();

            // Form2'yi göster
            form4.Show();

            // İsteğe bağlı: Form1'i gizle
            this.Hide();
        }
    }
}
