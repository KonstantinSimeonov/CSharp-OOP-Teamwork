﻿namespace Game
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
    using Logic.Delegates;

    public partial class CardGame : Form, IFormPublisher
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

        private void PlayerMonster1_Click(object sender, EventArgs e)
        {

        }

        private void PCard2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void PlayOnTheField(PictureBox current, PictureBox[] boxes)
        {
            if (current.Image != null)
            {
                var box = this.GetFirstEmpty(boxes);
                box.Image = current.Image;
                current.Image = null;
            }
        }

        private void GameDraw(object sender, EventArgs e)
        {
            var args = new TakeCardArgs(null);
            this.DrawEvent(sender, args);
            this.AssignPicture(args.PlayedCard, pHandC);

            var args2 = new RemainingCardArgs();
            this.RequestCardsLeft(sender, args2);
            PlayerCardsInDeck.Text = args2.Remaining.ToString();
        }

        private void PDeck_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void PDeck_Click(object sender, EventArgs e)
        {

        }

        private void PlayerSpell1_Click(object sender, EventArgs e)
        {

        }

        private void PCard8_Click_1(object sender, EventArgs e)
        {

        }

        private void PlayerSpell5_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
                this.GameDraw(sender, e);
                this.DrawButton.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DisablePlayerUI();
            this.End(sender, e);
        }

        private void PlayerMonster2c_Click(object sender, EventArgs e)
        {

        }


        public event EventRaiser DrawEvent;

        public event EventRaiser RequestStateReport;

        public event EventRaiser RequestCardsLeft;

        public event EventRaiser PlayCardEvent;

        public event EventRaiser Main1;

        public event EventRaiser Battle;

        public event EventRaiser Main2;

        public event EventRaiser End;

        public event EventRaiser GameOver;

        private PictureBox[] GetField(ICard card)
        {
            switch (card.Type)
            {
                case Logic.Cards.CardTypes.Spell:
                    return this.pSpellC;
                case Logic.Cards.CardTypes.Equip:
                    return this.pSpellC;
                case Logic.Cards.CardTypes.Field:
                    return this.pSpellC;
                case Logic.Cards.CardTypes.Trap:
                    return this.pSpellC;
                case Logic.Cards.CardTypes.Monster:
                    return this.pFieldC;
                case Logic.Cards.CardTypes.SpecialMonster:
                    return this.pFieldC;
                default:
                    throw new NotImplementedException("em kot takoa");
            }
        }

        private void RaisePlay(object sender, EventArgs e)
        {
            var box = sender as PictureBox;
            var args = new PlayCardArgs(null, box.Image.Tag.ToString());
            this.PlayCardEvent(sender, args);

            if (args == null)
                throw new NullReferenceException("Played card cannot be null");

            this.PlayOnTheField(box, this.GetField(args.PlayedCard));
        }


        private void AssignPicture(ICard card, PictureBox[] boxes)
        {
            var box = this.GetFirstEmpty(boxes);
            box.Image = SmallCards.Images[int.Parse(card.Path)];
            box.Image.Tag = card.Path;
        }

        private void DummyEffect(object sender, EventArgs e)
        { }

        private void PlayerCardsInDeck_Click(object sender, EventArgs e)
        {

        }

        private void DisablePlayerUI()
        {
            foreach (var box in this.pHandC)
            {
                box.Enabled = false;
            }

            this.Phase1Button.Enabled = this.Phase2Button.Enabled = this.BattleButton.Enabled = this.EndTurnButton.Enabled = false;

        }

        private void BattleButton_Click(object sender, EventArgs e)
        {
            this.Phase1Button.Enabled = false;
            // TODO: implement battle
            this.Battle(sender, e);
        }

        private void Phase1Button_Click(object sender, EventArgs e)
        {
            this.BattleButton.Enabled = true;
            // TODO: do it correctly
            this.Main1(sender, e);
        }

        private void Phase2Button_Click(object sender, EventArgs e)
        {
            this.BattleButton.Enabled = false;
            // TODO: do it correctly
            this.Main2(sender, e);
        }
    }
}
