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
            if (a == 1)
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
            if (PCard1.Image != null)
            {
                int index = ReturnIndex(PCard1);
                ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/"+index+".jpg");
            }

        }

        private void PCard2_Click(object sender, EventArgs e)
        {

        }

        private void PCard2_MouseHover(object sender, EventArgs e)
        {
            if (PCard2.Image != null)
            {
                int index = ReturnIndex(PCard2);
                ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/" + index + ".jpg");
            }
        }

        private void PCard3_MouseHover(object sender, EventArgs e)
        {
            if (PCard3.Image != null)
            {

                int index = ReturnIndex(PCard3);
                ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/" + index + ".jpg");
            }
        }

        private void PCard4_MouseHover(object sender, EventArgs e)
        {
            if (PCard4.Image != null)
            {
                int index = ReturnIndex(PCard4);
                ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/" + index + ".jpg");
            }
        }

        private void PCard5_MouseHover(object sender, EventArgs e)
        {
            if (PCard5.Image != null)
            {
                int index = ReturnIndex(PCard5);
                ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/" + index + ".jpg");
            }
        }

        private void PCard6_MouseHover(object sender, EventArgs e)
        {
            if (PCard6.Image != null)
            {
                int index = ReturnIndex(PCard6);
                ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/" + index + ".jpg");
            }
        }

        private void PCard7_MouseHover(object sender, EventArgs e)
        {
            if (PCard7.Image != null)
            {
                int index = ReturnIndex(PCard7);
                ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/" + index + ".jpg");
            }
        }

        private void PCard8_MouseHover(object sender, EventArgs e)
        {
            if (PCard8.Image != null)
            {
                int index = ReturnIndex(PCard8);
                ZoomMonsterCard.Image = Image.FromFile("C:/Users/Тито/Desktop/oop2/BigMonstCards/" + index + ".jpg");
            }
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

        private void PCard1_DoubleClick(object sender, EventArgs e)
        {
            Movecards(PCard1);

        }

        private void PlayerMonster1_Click(object sender, EventArgs e)
        {

        }

        private void PCard2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Movecards(PCard2);
        }



        private void PCard3_DoubleClick(object sender, EventArgs e)
        {
            Movecards(PCard3);
        }

        private void PCard4_DoubleClick(object sender, EventArgs e)
        {
            Movecards(PCard4);
        }

        private void PCard5_DoubleClick(object sender, EventArgs e)
        {
            Movecards(PCard5);
        }

        private void PCard6_DoubleClick(object sender, EventArgs e)
        {
            Movecards(PCard6);
        }

        private void PCard7_DoubleClick(object sender, EventArgs e)
        {
            Movecards(PCard7);
        }

        private void PCard8_DoubleClick(object sender, EventArgs e)
        {
            Movecards(PCard8);
        }
        /// <summary>
        /// methodsssssssssssssssssssssssssssssssss
        /// </summary>
        /// <param name="current"></param>
        private void Movecards(PictureBox current)
        {
            if (PlayerMonster1.Image == null)
            {
                PlayerMonster1.Image = current.Image;
                current.Image = null;
            }
            else if (PlayerMonster2c.Image == null)
            {
                PlayerMonster2c.Image = current.Image;
                current.Image = null;
            }
            else if (PlayerMonster3.Image == null)
            {
                PlayerMonster3.Image = current.Image;
                current.Image = null;

            }
            else if (PlayerMonster4.Image == null)
            {
                PlayerMonster4.Image = current.Image;
                current.Image = null;

            }
            else if (PlayerMonster5.Image == null)
            {
                PlayerMonster5.Image = current.Image;
                current.Image = null;

            }
        }

        private void DrawCard()
        {
          Random rand = new Random();
            int index = rand.Next(0,8);
           PictureBox temp = new PictureBox();
            temp.Image=SmallCards.Images[index];

            if (PCard1.Image == null)
            {
                PCard1.Image = temp.Image;
                PCard1.Image.Tag = index.ToString();
            }
            else if (PCard2.Image == null)
            {
                PCard2.Image = temp.Image;
                PCard2.Image.Tag = index.ToString();
            }
            else if (PCard3.Image == null)
            {
                PCard3.Image = temp.Image;
                PCard3.Image.Tag = index.ToString();
            }
            else if (PCard4.Image == null)
            {
                PCard4.Image = temp.Image;
                PCard4.Image.Tag = index.ToString();
            }
            else if (PCard5.Image == null)
            {
                PCard5.Image = temp.Image;
                PCard5.Image.Tag = index.ToString();
            }
            else if (PCard6.Image == null)
            {
                PCard6.Image = temp.Image;
                PCard6.Image.Tag = index.ToString();
            }
            else if (PCard7.Image == null)
            {
                PCard7.Image = temp.Image;
                PCard7.Image.Tag = index.ToString();
            }
            else if (PCard8.Image == null)
            {
                PCard8.Image = temp.Image;
                PCard8.Image.Tag = index.ToString();
            }


        }

        private int ReturnIndex(PictureBox current)
        {
            if (current.Image.Tag.Equals("0"))
            {
                return 0;
            }
            else if (current.Image.Tag.Equals("1"))
            {
                 return 1;
            }
            else if (current.Image.Tag.Equals("2"))
            {
                return 2;
            }
            else if (current.Image.Tag.Equals("3"))
            {
                return 3;
            }
            else if (current.Image.Tag.Equals("4"))
            {
                return 4;
            }
            else if (current.Image.Tag.Equals("5"))
            {
                return 5;
            }
            else if (current.Image.Tag.Equals("6"))
            {
                return 6;
            }
            else 
            {
                return 7;
            }
        }
        /// <summary>
        /// methoods end !!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PDeck_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DrawCard();
        }

        private void PDeck_Click(object sender, EventArgs e)
        {

        }
    }
}
