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
    using Engine.CustomEventArgs;
    using Logic.Interfaces;
    using Engine.Delegates;
    using Logic.Cards;

    public partial class CardGame : Form, IFormPublisher
    {
        private PictureBox[] pHandC;
        private PictureBox[] pSpellC;
        private PictureBox[] pFieldC;
        private PictureBox[] aiMonsters;
        private PictureBox[] aiSpells;
        private Button[] buttons;
        private bool uiEnabled;
        private bool battleSelectFriendly;
        private bool battleSelectEnemy;
        private string IdAttacker, IdDefender;

        public CardGame()
        {
            InitializeComponent();
            pHandC = new PictureBox[] { PCard1, PCard2, PCard3, PCard4, PCard5, PCard6, PCard7, PCard8 };
            pSpellC = new PictureBox[] { PlayerSpell1, PlayerSpell2, PlayerSpell3, PlayerSpell4, PlayerSpell5 };
            pFieldC = new PictureBox[] { PlayerMonster1, PlayerMonster2c, PlayerMonster3, PlayerMonster4, PlayerMonster5 };
            aiMonsters = new PictureBox[] { CompMonster1, CompMonster2, CompMonster3, CompMonster4, CompMonster5 };
            aiSpells = new PictureBox[] { CompSpell1, CompSpell2, CompSpell3, CompSpell4, CompSpell5 };
            buttons = new Button[] { this.DrawButton, this.Phase1Button, this.BattleButton, this.Phase2Button, this.EndTurnButton };
            this.uiEnabled = true;
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

        #region WTF
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

        private void PlayerSpell3_Click(object sender, EventArgs e)
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

        private void PCard2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void SelectFriendly(object sender, EventArgs e)
        {
            if (this.battleSelectFriendly)
            {
                this.IdAttacker = (sender as PictureBox).Image.Tag.ToString();
                this.battleSelectFriendly = false;
                this.battleSelectEnemy = true;
                this.SetClicking(this.pFieldC, false);
                this.SetClicking(this.pSpellC, false);
                this.SetClicking(this.aiMonsters, true);
            }
        }

        private void SelectEnemy(object sender, EventArgs e)
        {
            if (this.battleSelectEnemy)
            {
                this.IdDefender = (sender as PictureBox).Image.Tag.ToString();
                this.battleSelectEnemy = false;
                this.SetClicking(this.aiMonsters, false);
                var args = new BoardReportArgs(true, true, true, bArgs: new BattleArgs(this.IdAttacker, this.IdDefender));
                this.Battle(sender, args);
                this.UpdateUI(args);
                this.IdAttacker = this.IdDefender = null;
                if (this.pFieldC.Where(x => x.Image != null).Any())
                    this.BattleButton_Click(this.BattleButton, e);
            }
        }

        #endregion

        #region WTF
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

        #endregion

        /// <summary>
        /// Raises an event to which the board subscribes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawButton_Click(object sender, EventArgs e)
        {
            var args = new BoardReportArgs(true, true, true);
            this.DrawEvent(sender, args);
            this.UpdateUI(args);
            this.DrawButton.Enabled = false;
        }

        private void UpdateUI(BoardReportArgs args)
        {
            for (int i = 0; i < 6; i++)
            {
                if (args.PlayerMonsters.Count > i)
                    UpdateBox(this.pFieldC[i], args.PlayerMonsters[i], args.PlayerMonsters[i].FaceUp);
                else if (i < this.pFieldC.Length)
                    this.pFieldC[i].Image = null;
                if (args.PlayerEffects.Count > i)
                    UpdateBox(this.pSpellC[i], args.PlayerEffects[i], args.PlayerEffects[i].FaceUp);
                if (args.AIMonsters.Count > i)
                    UpdateBox(this.aiMonsters[i], args.AIMonsters[i], args.AIMonsters[i].FaceUp);
                else if (i < this.pFieldC.Length)
                    this.aiMonsters[i].Image = null;
                if (args.AIEffects.Count > i)
                    UpdateBox(this.aiSpells[i], args.AIEffects[i], args.AIEffects[i].FaceUp);
                if (args.Player.Hand.Count > i)
                    UpdateBox(this.pHandC[i], args.Player.Hand[i]);
            }
            this.aiLife.Text = args.AI.LifePoints.ToString();
            this.playerLife.Text = args.Player.LifePoints.ToString();
            this.PlayerCardsInDeck.Text = args.PlayerCardsRemaining.ToString();

        }

        private void UpdateBox(PictureBox box, ICard card, bool faceUp = true)
        {
            box.Image = faceUp ? card.CardImage : this.FaceDown();
            if (!faceUp)
                box.Image.Tag = card.CardImage.Tag;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.TogglePlayerUI();
            var args = new BoardReportArgs(false, false, true);
            this.End(sender, args);
            this.UpdateUI(args);
            this.TogglePlayerUI();
        }

        #region Events
        // TODO: implement the remaining events

        public event EventRaiser DrawEvent;

        public event EventRaiser PlayCardEvent;

        public event EventRaiser Main1;

        public event EventRaiser Battle;

        public event EventRaiser Main2;

        public event EventRaiser End;

        public event EventRaiser GameOver;

        #endregion

        private void PlayerCardsInDeck_Click(object sender, EventArgs e)
        {

        }


        private void TogglePlayerUI()
        {
            this.uiEnabled = !this.uiEnabled;

            for (int i = 0; i < pHandC.Length; i++)
            {
                pHandC[i].Enabled = this.uiEnabled;

            }

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Enabled = this.uiEnabled;
            }

            //this.DrawButton.Enabled = true;

        }

        private void BattleButton_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            this.Phase1Button.Enabled = false;
            this.SetClicking(this.pFieldC, true);
            this.SetClicking(this.pSpellC, true);
            this.battleSelectFriendly = true;

        }

        private void Phase1Button_Click(object sender, EventArgs e)
        {
            this.SetClicking(this.pHandC, true);
            //this.Main1(sender, e);
        }

        private void SetClicking(Control[] controls, bool enabled)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                controls[i].Enabled = enabled;
            }
        }

        private void Phase2Button_Click(object sender, EventArgs e)
        {
            this.BattleButton.Enabled = false;
            // TODO: do it correctly
            //this.Main2(sender, e);
        }

        private void RaisePlay(object sender, MouseEventArgs e)
        {
            // TODO: add a message box that ask for monster position or something like that


            bool left = e.Button == MouseButtons.Left;

            var box = sender as PictureBox;
            if (box.Image == null)
                return;
            var args = new BoardReportArgs(this.EndTurnButton.Enabled, this.EndTurnButton.Enabled, left, box.Image.Tag.ToString());
            this.PlayCardEvent(sender, args);
            this.UpdateUI(args);
            this.pHandC[args.Player.Hand.Count].Image = null;
            this.SetClicking(this.pHandC, false);
        }

        private void PCard1_Click_1(object sender, EventArgs e)
        {

        }

        private Image FaceDown()
        {
            return Image.FromFile(@"..\..\Resources\DeckImgCurrent\face_down_monster_card.jpg");
        }

        private void SelectFriendly(object sender, MouseEventArgs e)
        {

        }

        private void SelectEnemy(object sender, MouseEventArgs e)
        {

        }
    }
}
