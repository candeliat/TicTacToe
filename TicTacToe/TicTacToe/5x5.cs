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
    public partial class _5x5 : Form
    {
        public _5x5()
        {
            InitializeComponent();
        }
        public enum oyuncular
        {
            X, O
        }
        private const int BOARD_SIZE = 5;
        private const int WIN_LENGTH = 5;  // 5'li kazanma koşulu (indis farkı ile 4 olarak kontrol ediliyor)

        oyuncular oyuncuX;
        int oyuncu = 0;
        int bilgisayar = 0;
        Random random = new Random();
        List<Button> butonlar;

        private void _5x5_Load(object sender, EventArgs e)
        {
            butonlar = new List<Button> { button00, button01, button02, button10, button11, button12, button20, button21, button22,
        button23, button13, button03, button24, button100, button04, button34, button33,
        button32, button31, button30, button44, button43, button42, button41, button40 };
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
        private void oyunKontrol()
        {
            bool kazananVar = false;
            string kazanan = "";

            // Tüm hücreleri kontrol et
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    string simge = GetButtonText(i, j);

                    if (!string.IsNullOrEmpty(simge))
                    {
                        // Yatay, dikey ve iki çapraz yönde kontrol et
                        if (KontrolEt(i, j, 0, 1, simge) || // Yatay kontrol
                            KontrolEt(i, j, 1, 0, simge) || // Dikey kontrol
                            KontrolEt(i, j, 1, 1, simge) || // Sağ çapraz
                            KontrolEt(i, j, 1, -1, simge))  // Sol çapraz
                        {
                            kazanan = simge == "X" ? "Oyuncu" : "Bilgisayar";
                            kazananVar = true;

                            if (kazanan == "Oyuncu")
                            {
                                oyuncu++;
                                label1.Text = "Oyuncu: " + oyuncu;
                            }
                            else
                            {
                                bilgisayar++;
                                label2.Text = "Bilgisayar: " + bilgisayar;
                            }

                            break;
                        }
                    }
                }

                if (kazananVar) break;
            }

            if (kazananVar)
            {
                pcZaman.Stop();
                MessageBox.Show("Kazanan: " + kazanan);
                
                yenile();
            }
           
        }

        // Belirli bir hücreden başlayarak belirli bir yönde 5 aynı simgenin olup olmadığını kontrol eden metod
        private bool KontrolEt(int x, int y, int dx, int dy, string simge)
        {
            for (int i = 0; i < WIN_LENGTH; i++)
            {
                int yeniX = x + i * dx;
                int yeniY = y + i * dy;

                // Sınır dışı kontrolü yap
                if (yeniX < 0 || yeniX > BOARD_SIZE || yeniY < 0 || yeniY > BOARD_SIZE)
                    return false;

                // Farklı bir simge varsa kazanma durumu yok
                if (GetButtonText(yeniX, yeniY) != simge)
                    return false;
            }
            return true;
        }

        // Butonların Text değerini almak için yardımcı metod
        private string GetButtonText(int row, int col)
        {
            string buttonName = $"button{row}{col}";
            Control[] controls = this.Controls.Find(buttonName, true);

            if (controls.Length == 0 || controls[0] == null)
                return string.Empty;

            return controls[0].Text;
        }

        private void yenile()
        {
            butonlar = new List<Button> { button00, button01, button02, button10, button11, button12, button20, button21, button22,
                button40, button23, button13, button03, button24, button100, button04, button34, button33,
                button32, button31, button30, button44, button43, button42, button41 };

            foreach (Button x in butonlar)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
            butonlar.Clear();
            
        }

        private void yenileButon(object sender, EventArgs e)
        {
            yenile();

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
    }
}
