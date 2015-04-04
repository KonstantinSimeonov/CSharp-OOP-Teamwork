namespace Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Logic.CustomEventArgs;
    using Logic.Interfaces;

    public partial class CardGame : Form, IPublisher
    {

        private PictureBox[] pHandC;
        private PictureBox[] pSpellC;
        private PictureBox[] pFieldC;
        private bool playerEnable;

        public CardGame()
        {
            InitializeComponent();
            pHandC = new PictureBox[] { PCard1, PCard2, PCard3, PCard4, PCard5, PCard6, PCard7, PCard8 };
            pSpellC = new PictureBox[] { PlayerSpell1, PlayerSpell2, PlayerSpell3, PlayerSpell4, PlayerSpell5 };
            pFieldC = new PictureBox[] { PlayerMonster1, PlayerMonster2c, PlayerMonster3, PlayerMonster4, PlayerMonster5 };
            this.playerEnable = true;
        }



        private PictureBox GetFirstEmpty(PictureBox[] boxes)
        {
            return boxes.Where(x => x.Image == null).First();
        }

        private void SetZoom(object sender, EventArgs e)
        {
            var box = sender as PictureBox;

            if (box.Image == null)
                return;

            int index = int.Parse(box.Image.Tag.ToString());
            this.ZoomMonsterCard.ImageLocation = string.Format(@"../../Resources/DeckImgCurrent/BigCards/{0}.jpg", index);
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

        }


        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {

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

        

        private void PCard2_Click(object sender, EventArgs e)
        {

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
            if(this.playerEnable)
            Movecards(PCard1);

        }

        private void PlayerMonster1_Click(object sender, EventArgs e)
        {

        }

        private void PCard2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.playerEnable)
            Movecards(PCard2);
        }



        private void PCard3_DoubleClick(object sender, EventArgs e)
        {
            if (this.playerEnable)
            Movecards(PCard3);
        }

        private void PCard4_DoubleClick(object sender, EventArgs e)
        {
            if (this.playerEnable)
            Movecards(PCard4);
        }

        private void PCard5_DoubleClick(object sender, EventArgs e)
        {
            if (this.playerEnable)
            Movecards(PCard5);
        }

        private void PCard6_DoubleClick(object sender, EventArgs e)
        {
            if (this.playerEnable)
            Movecards(PCard6);
        }

        private void PCard7_DoubleClick(object sender, EventArgs e)
        {
            if (this.playerEnable)
            Movecards(PCard7);
        }

        private void PCard8_DoubleClick(object sender, EventArgs e)
        {
            if(this.playerEnable)
            Movecards(PCard8);
        }
        /// <summary>
        /// methodsssssssssssssssssssssssssssssssss
        /// </summary>
        /// <param name="current"></param>
        private void Movecards(PictureBox current)
        {
            if (current.Image != null)
            {
                var box = this.GetFirstEmpty(this.pFieldC);
                box.Image = current.Image;
                current.Image = null;
            }
            
            

            //if (PlayerMonster1.Image == null)
            //{
            //    PlayerMonster1.Image = current.Image;
            //    current.Image = null;
            //}
            //else if (PlayerMonster2c.Image == null)
            //{
            //    PlayerMonster2c.Image = current.Image;
            //    current.Image = null;
            //}
            //else if (PlayerMonster3.Image == null)
            //{
            //    PlayerMonster3.Image = current.Image;
            //    current.Image = null;

            //}
            //else if (PlayerMonster4.Image == null)
            //{
            //    PlayerMonster4.Image = current.Image;
            //    current.Image = null;

            //}
            //else if (PlayerMonster5.Image == null)
            //{
            //    PlayerMonster5.Image = current.Image;
            //    current.Image = null;

            //}
        }

        private void GameDraw(object sender, EventArgs e)
        {
            var args = new PlayCardArgs(null);
            Raise(sender, args);
            string path = (args.PlayedCard as Logic.Cards.Card).Path;
            var nextBox = this.GetFirstEmpty(this.pHandC);
            nextBox.Image = SmallCards.Images[int.Parse(path)];
            nextBox.Image.Tag = path;
        }

        private void DrawCard(object sender, EventArgs e)
        {

            Random rand = new Random();
            int index = rand.Next(0, 8);
            PictureBox temp = new PictureBox();
            temp.Image = SmallCards.Images[index];

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
            return int.Parse(current.Image.Tag.ToString());
        }
        /// <summary>
        /// methoods end !!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PDeck_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //DrawCard(sender, e);
            //GameDraw(sender, e);

        }

        private void PDeck_Click(object sender, EventArgs e)
        {
            
        }

        public event Logic.Delegates.EventRaiser Raise;



        private void PlayerSpell1_Click(object sender, EventArgs e)
        {

        }



        private void PCard8_Click_1(object sender, EventArgs e)
        {

        }

        private void PlayerSpell5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.playerEnable)
                this.GameDraw(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.playerEnable = false;
        }

    }
}
