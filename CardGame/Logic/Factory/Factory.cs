namespace Logic.Factory
{
    using System;
    using System.IO;
    using Logic.Interfaces;
    using Logic.Cards;
    using Logic.Player;
    using Logic.Delegates;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;

    public class Factory : IFactory
    {
        // TODO: implement serializing, encryption and encoding of the deck cards


        #region Constants
        private const char SPLIT = ',';
        private const char NEWLINE = '\n';
        private const string MONSTER_CARD = "Monster";
        private const string SPECIAL_MONSTER_CARD = "SpecialMonster";
        private const string SPELL_CARD = "Spell";
        private const string EQUIP_CARD = "Equip";
        private const string TRAP_CARD = "Trap";
        private const string FIELD_CARD = "Field";
        private const string INVALID_ARG = "Wrong message from parsed txt";

        private const string path = @"..\..\CardInfo\CardInfo.txt";
        #endregion

        private static readonly IFactory factory = new Factory();

        private bool aiCreated, humanPlayerCreated;
        private int currentLine;
        private string[] deckInfo;

        public static IFactory Instance
        {
            get { return factory; }
        }

        private Factory()
        {
            aiCreated = humanPlayerCreated = false;
            var cardList = File.ReadAllText(path);
            deckInfo = cardList.Split('\n');
            this.currentLine = 0;
        }

        public ICard CreateCard()
        {
            // catch exception
            string[] cardCommand = this.deckInfo[this.currentLine++].Split(Factory.SPLIT);

            switch (cardCommand[0])
            {
                case Factory.MONSTER_CARD:
                    return new MonsterCard(cardCommand[1], cardCommand[2], cardCommand[3], int.Parse(cardCommand[4]), int.Parse(cardCommand[5]));
                case Factory.SPECIAL_MONSTER_CARD:
                    return new SpecialMonster(cardCommand[1], cardCommand[2], cardCommand[3], int.Parse(cardCommand[4]), int.Parse(cardCommand[5]), Effects.NoEffect);
                case Factory.TRAP_CARD:
                    return new TrapCard(cardCommand[1], cardCommand[2], cardCommand[3], Effects.NoEffect, Effects.NoEffect);
                case Factory.SPELL_CARD:
                    return new SpellCard(cardCommand[1], cardCommand[2], cardCommand[3], Effects.NoEffect, Effects.NoEffect);
                case Factory.EQUIP_CARD:
                    return new EquipSpellCard(cardCommand[1], cardCommand[2], cardCommand[3], Effects.NoEffect, Effects.NoEffect, 0, 0);
                default:
                    throw new ArgumentException(Factory.INVALID_ARG);
            }
        }

        public IDeck AssembleDeck()
        {
            var deck = new Deck();
            for (int i = 0; i < deckInfo.Length; i++)
            {
                deck.Cards.Add(this.CreateCard());
            }
            this.currentLine = 0;
            return deck;
        }

        public IPlayer CreatePlayer(IDeck deck, bool isAI = false)
        {
            if (isAI)
            {
                if (this.aiCreated == true)
                    throw new InvalidOperationException("Cannot create two AI players!");

                this.aiCreated = true;
                return new HumanPlayer(deck);
            }

            if (this.humanPlayerCreated == true)
                throw new NotImplementedException("No multiplayer yet!");

            this.humanPlayerCreated = true;
            return new HumanPlayer(deck);
        }
    }
}
