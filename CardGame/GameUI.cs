namespace Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Logic.CustomEventArgs;
    using Logic.Interfaces;
    using Logic.Delegates;
    using Logic.Cards;

    public partial class CardGame : Form, IFormPublisher
    {
        private bool firstDraw;

        private PictureBox[] pHandC;
        private PictureBox[] pSpellC;
        private PictureBox[] pFieldC;
        private PictureBox[] aiMonsters;
        private PictureBox[] aiSpells;

        public CardGame()
        {
            InitializeComponent();
            pHandC = new PictureBox[] { PCard1, PCard2, PCard3, PCard4, PCard5, PCard6, PCard7, PCard8 };
            pSpellC = new PictureBox[] { PlayerSpell1, PlayerSpell2, PlayerSpell3, PlayerSpell4, PlayerSpell5 };
            pFieldC = new PictureBox[] { PlayerMonster1, PlayerMonster2c, PlayerMonster3, PlayerMonster4, PlayerMonster5 };
            aiMonsters = new PictureBox[] { CompMonster1, CompMonster2, CompMonster3, CompMonster4, CompMonster5 };
            aiSpells = new PictureBox[] { CompSpell1, CompSpell2, CompSpell3, CompSpell4, CompSpell5 };
            this.firstDraw = false;

        }

        private void Draw(int cards)
        {
            for (int i = 0; i < cards; i++)
            {
                this.GameDraw(this, new EventArgs());
            }
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


        private void GameDraw(object sender, EventArgs e)
        {
            var args = new DrawCardArgs(null);
            this.DrawEvent(sender, args);
            this.AssignPicture(args.PlayedCard, pHandC, true);
            PlayerCardsInDeck.Text = args.CardsRemaining.ToString();
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
            if (!firstDraw)
            {
                this.Draw(5);
                this.firstDraw = true;
                return;
            }

            this.GameDraw(sender, e);
            this.DrawButton.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DisablePlayerUI();
            var args = new PlayCardArgs(null, null, true, false);
            this.End(sender, args);
        }

        private void PlayerMonster2c_Click(object sender, EventArgs e)
        {

        }

        // TODO: implement the remaining events

        public event EventRaiser DrawEvent;

        public event EventRaiser RequestStateReport;

        public event EventRaiser RequestCardsLeft;

        public event EventRaiser PlayCardEvent;

        public event EventRaiser Main1;

        public event EventRaiser Battle;

        public event EventRaiser Main2;

        public event EventRaiser End;

        public event EventRaiser GameOver;

        private PictureBox[] GetField(ICard card, bool playerTurn = true)
        {
            switch (card.Type)
            {
                case CardTypes.Spell:
                    return playerTurn ? this.pSpellC : this.aiSpells;
                case CardTypes.Equip:
                    return playerTurn ? this.pSpellC : this.aiSpells;
                case CardTypes.Field:
                    return playerTurn ? this.pSpellC : this.aiSpells;
                case CardTypes.Trap:
                    return playerTurn ? this.pSpellC : this.aiSpells;
                case CardTypes.Monster:
                    return playerTurn ? this.pFieldC : this.aiMonsters;
                case CardTypes.SpecialMonster:
                    return playerTurn ? this.pFieldC : this.aiMonsters;
                default:
                    throw new NotImplementedException("em kot takoa");
            }
        }



        private void RaisePlay(object sender, EventArgs e)
        {
            // TODO: delete this metod

            var box = sender as PictureBox;
            var args = new PlayCardArgs(null, box.Image.Tag.ToString(), true, this.EndTurnButton.Enabled);
            this.PlayCardEvent(sender, args);

            if (args == null)
                throw new NullReferenceException("Played card cannot be null");
            this.AssignPicture(args.PlayedCard, this.GetField(args.PlayedCard), args.FaceUp);
        }


        private void AssignPicture(ICard card, PictureBox[] boxes, bool faceUp)
        {
            var box = this.GetFirstEmpty(boxes);
            box.Image = !faceUp ? Image.FromFile(@"..\..\Resources\DeckImgCurrent\face_down_monster_card.jpg") : SmallCards.Images[int.Parse(card.Path)];
            box.Image.Tag = card.Path;
        }
        //box.Image = faceUp ? current.Image : Image.FromFile(@"..\..\Resources\DeckImgCurrent\face_down_monster_card.jpg");
        private void PlayerCardsInDeck_Click(object sender, EventArgs e)
        {

        }

        private void DisablePlayerUI()
        {
            // TODO: make this method useful or delete it

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

        private void RaisePlay(object sender, MouseEventArgs e)
        {
            // TODO: add a message box that ask for monster position or something like that

            bool left = e.Button == MouseButtons.Left;

            var box = sender as PictureBox;
            var args = new PlayCardArgs(null, box.Image.Tag.ToString(), left, this.EndTurnButton.Enabled);
            this.PlayCardEvent(sender, args);

            if (args == null)
                throw new NullReferenceException("Played card cannot be null");

            box.Image = null;

            this.AssignPicture(args.PlayedCard, this.GetField(args.PlayedCard), left);

        }

        private void PCard1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
