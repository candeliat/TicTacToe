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
    public partial class _3x3 : Form
    {
        public _3x3()
        {
            InitializeComponent();
            yenile();
        }

        public enum oyuncular
        {
            X, O
        }

        oyuncular oyuncuX;
        int oyuncu = 0;
        int bilgisayar = 0;
        Random random = new Random();
        List<Button> butonlar;


        private void OyuncuSure(object sender, EventArgs e)
        {
            if (butonlar.Count > 0)
            {
                int index = random.Next(butonlar.Count);
                butonlar[index].Enabled = false;
                oyuncuX = oyuncular.O;
                butonlar[index].Text = oyuncuX.ToString();
                butonlar[index].BackColor = Color.DarkSalmon;
                butonlar.RemoveAt(index);
                oyunKontrol();
                pcZaman.Stop();
            }
        }

        private void yenileButon(object sender, EventArgs e)
        {
            yenile();
        }

        private void oyuncuTikla(object sender, EventArgs e)
        {
            var button = (Button)sender;
            oyuncuX = oyuncular.X;
            button.Text = oyuncuX.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            butonlar.Remove(button);
            oyunKontrol();
            pcZaman.Start();

        }

        private void yenile()
        {
            butonlar = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (Button x in butonlar)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }

        private void oyunKontrol()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                pcZaman.Stop();
                MessageBox.Show("Kazanan Oyuncu");
                oyuncu++;
                label1.Text = "Oyuncu: " + oyuncu;
                yenile();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                pcZaman.Stop();
                MessageBox.Show("Kazanan Bilgisayar");
                bilgisayar++;
                label2.Text = "Bilgisayar: " + bilgisayar;
                yenile();
            }
        }



        private void _3x3_Load(object sender, EventArgs e)
        {

        }

        private void form1Btn_Click(object sender, EventArgs e)
        {
            // Form'nin bir örneğini oluştur
            Form1 form1 = new Form1();

            // Form1'yi göster
            form1.Show();

            // İsteğe bağlı: Form2'i kapat
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
