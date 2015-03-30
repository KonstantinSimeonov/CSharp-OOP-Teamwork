using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class CardGame : Form
    {
        int a;
        int b;
        public CardGame()
        {
            InitializeComponent();
        }

        private void CardGame_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            a = 1;
        }


        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {
            if (a == 1)
            {
                ZoomMonsterCard.Image = PCard2.Image;
                a = 0;
                b = 1;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            if (a==1)
            {
                ZoomMonsterCard.Image = PCard2.Image;
                PCard2.Image = null;
                
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void CompMonster3_Click(object sender, EventArgs e)
        {

        }

        private void PlayerSpell3_Click(object sender, EventArgs e)
        {

        }

        private void PlayerMonster5_Click(object sender, EventArgs e)
        {

        }

        private void PlayerMonster5_MouseHover(object sender, EventArgs e)
        {

        }

        private void PCard1_MouseHover(object sender, EventArgs e)
        {
            ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/01.jpg");
        }

        private void PCard2_Click(object sender, EventArgs e)
        {

        }

        private void PCard2_MouseHover(object sender, EventArgs e)
        {
            ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/02.jpg");
        }

        private void PCard3_MouseHover(object sender, EventArgs e)
        {
            ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/03.jpg");
        }

        private void PCard4_MouseHover(object sender, EventArgs e)
        {
            ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/04.jpg");
        }

        private void PCard5_MouseHover(object sender, EventArgs e)
        {
            ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/05.jpg");
        }

        private void PCard6_MouseHover(object sender, EventArgs e)
        {
            ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/06.jpg");
        }

        private void PCard7_MouseHover(object sender, EventArgs e)
        {
            ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/07.jpg");
        }

        private void PCard8_MouseHover(object sender, EventArgs e)
        {

            ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/08.jpg");
        }

        private void PCard5_Click(object sender, EventArgs e)
        {

        }

        private void PCard1_Click(object sender, EventArgs e)
        {

        }

        private void PCard8_Click(object sender, EventArgs e)
        {

        }

        private void PCard6_Click(object sender, EventArgs e)
        {

        }

        private void CompMonster4_Click(object sender, EventArgs e)
        {

        }
    }
}
