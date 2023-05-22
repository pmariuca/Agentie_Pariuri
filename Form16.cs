using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class Form16 : Form
    {
        private Button[] buttons;
        private Random random;
        private int butonCurent;
        public Form16()
        {
            InitializeComponent();
            InitializeButtons();
            random = new Random();
        }

        private void InitializeButtons()
        {
            buttons = new Button[] { btn1, btn2, btn3, btn4, btn5 };
            butonCurent = -1;
        }

        private async void btnSpin_Click_1(object sender, EventArgs e)
        {
            ShuffleButtons();

            butonCurent = random.Next(buttons.Length);
            Button selectedButton = buttons[butonCurent];

            selectedButton.Width += 20;
            selectedButton.Height += 20;

            Glow(selectedButton);

            await Task.Delay(2500);

            RemoveGlow(selectedButton);

            selectedButton.Width -= 20;
            selectedButton.Height -= 20;
            
            if(selectedButton == btn2 || selectedButton == btn3 || selectedButton == btn4 || selectedButton ==btn5)
            {
                MessageBox.Show("Felicitari! Prezinta id-ul biletului si acest cod in agentiile fizice pentru a mari suma castigata cu "+selectedButton.Text+ ". Te asteptam!\n" + "Cod: "+genereazaCod(10));
            }
        }

        public static string genereazaCod(int length)
        {
            string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            string NumericChars = "0123456789";
            string SpecialChars = "!@#$%^&*()_-+=<>?";
            string charPool = UppercaseChars+LowercaseChars+NumericChars+SpecialChars;

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[length];
                rng.GetBytes(buffer);

                string cod = string.Empty;

                for (int i = 0; i < length; i++)
                {
                    int randomIndex = buffer[i] % charPool.Length;
                    cod += charPool[randomIndex];
                }

                return cod;
            }
        }

        private void ShuffleButtons()
        {
            int n = buttons.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Button value = buttons[k];
                buttons[k] = buttons[n];
                buttons[n] = value;
            }
        }

        private void Glow(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = Color.Purple;
        }

        private void RemoveGlow(Button button)
        {
            button.FlatStyle = FlatStyle.Standard;
            button.FlatAppearance.BorderSize = 0;
        }
    }
}
