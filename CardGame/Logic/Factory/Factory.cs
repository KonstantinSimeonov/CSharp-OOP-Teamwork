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
        private const string INVALID_ARG = "Wrong message from parsed txt";
        private const string CANNOT_CREATE_TWO_AI_PLAYERS = "Cannot create two AI players!";
        private const string NO_MULTIPLAYER = "No multiplayer yet!";

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
            deckInfo = cardList.Split(Factory.NEWLINE);
            this.currentLine = 0;
        }

        public ICard CreateCard()
        {
            // catch exception
            string[] cardCommand = this.deckInfo[this.currentLine++].Split(Factory.SPLIT);
            string cardTypeAsString = cardCommand[0];
            CardTypes cardType = (CardTypes)Enum.Parse(typeof(CardTypes), cardTypeAsString);
            string cardName = cardCommand[1];
            string cardDescription = cardCommand[2];
            string cardPath = cardCommand[3];
            int cardAttack = int.Parse(cardCommand[4]);
            int cardDefense = int.Parse(cardCommand[5]);


            switch (cardType)
            {
                case CardTypes.Monster:
                    return new MonsterCard(cardName, cardDescription, cardPath, cardAttack, cardDefense);
                case CardTypes.SpecialMonster:
                    return new SpecialMonster(cardName, cardDescription, cardPath, cardAttack, cardDefense, Effects.NoEffect);
                case CardTypes.Spell:
                    return new SpellCard(cardName, cardDescription, cardPath, Effects.NoEffect, Effects.NoEffect);
                case CardTypes.Equip:
                    return new EquipSpellCard(cardName, cardDescription, cardPath, Effects.NoEffect, Effects.NoEffect, 0, 0);
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

            return deck;
        }

        public IPlayer CreatePlayer(IDeck deck, bool isAI = false)
        {
            if (isAI)
            {
                if (this.aiCreated == true)
                {
                    throw new InvalidOperationException(Factory.CANNOT_CREATE_TWO_AI_PLAYERS);
                }

                this.aiCreated = true;
                return new HumanPlayer(deck);
            }

            if (this.humanPlayerCreated == true)
            {
                throw new NotImplementedException(Factory.NO_MULTIPLAYER);
            }

            this.humanPlayerCreated = true;
            return new HumanPlayer(deck);
        }
    }
}
