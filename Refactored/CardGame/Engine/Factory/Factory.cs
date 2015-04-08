namespace Engine.Factory
{
    using System;
    using System.IO;
    using System.Drawing;

    using Engine.CustomExceptions;
    using Logic.Interfaces;
    using Logic.Cards;
    using Logic.Player;
    

    public class Factory : IFactory
    {
        #region Constants
        private const char SPLIT = ',';
        private const char NEWLINE = '\n';
        private const string MONSTER_CARD="Monster";
        private const string SPECIAL_MONSTER_CARD="SpecialMonster";
        private const string TRAP_CARD="Trap";
        private const string SPELL_CARD="Spell";
        private const string EQUIP_CARD="Equip";
        private const string FIELD_CARD = "Field";
        private const string INVALID_ARG = "Wrong message from parsed txt";
        private const string CANNOT_CREATE_TWO_AI_PLAYERS = "Cannot create two AI players!";
        private const string NO_MULTIPLAYER = "No multiplayer yet!";

        private const string PATH = @"..\..\CardInfo\CardInfo.cinf";
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
            var security = new FactorySourceSecurity();
            var cardList = security.Normalize();
            deckInfo = cardList.Split(Factory.NEWLINE);
            this.currentLine = 0;
        }

        public ICard CreateCard()
        {
            // catch exception
            string[] cardCommand = this.deckInfo[this.currentLine++].Split(Factory.SPLIT);


            //string cardTypeAsString = cardCommand[0];
            //CardTypes cardType = (CardTypes)Enum.Parse(typeof(CardTypes), cardTypeAsString);
            //string cardName = cardCommand[1];
            //string cardDescription = cardCommand[2];
            //string cardPath = cardCommand[3];
            //int cardAttack = int.Parse(cardCommand[4]); thats plenty of unhandled exceptions
            //int cardDefense = int.Parse(cardCommand[5]); that too

            Image image = Image.FromFile(string.Format(@"..\..\Resources\DeckImgCurrent\SmallCards\{0}.jpg", int.Parse(cardCommand[3])));

            switch (cardCommand[0])
            {

                case Factory.MONSTER_CARD:
                    return new MonsterCard(cardCommand[1], cardCommand[2], cardCommand[3], int.Parse(cardCommand[4]), int.Parse(cardCommand[5]), image:image);
                case Factory.SPECIAL_MONSTER_CARD:
                    return new SpecialMonster(cardCommand[1], cardCommand[2], cardCommand[3], int.Parse(cardCommand[4]), int.Parse(cardCommand[5]), image, Effects.NoEffect);
                case Factory.TRAP_CARD:
                    return new TrapCard(cardCommand[1], cardCommand[2], cardCommand[3], image, Effects.NoEffect, Effects.NoEffect);
                case Factory.SPELL_CARD:
                    return new SpellCard(cardCommand[1], cardCommand[2], cardCommand[3], image, Effects.NoEffect, Effects.NoEffect);
                case Factory.EQUIP_CARD:
                    return new EquipSpellCard(cardCommand[1], cardCommand[2], cardCommand[3], image, Effects.NoEffect, Effects.NoEffect, 0, 0);
                case Factory.FIELD_CARD:
                    return new FieldSpellCard(cardCommand[1], cardCommand[2], cardCommand[3], image, Effects.NoEffect, Effects.NoEffect, int.Parse(cardCommand[6]));

                    // where is the trap card?
                //case CardTypes.Monster:
                //    return new MonsterCard(cardName, cardDescription, cardPath, cardAttack, cardDefense);
                //case CardTypes.SpecialMonster:
                //    return new SpecialMonster(cardName, cardDescription, cardPath, cardAttack, cardDefense, Effects.NoEffect);
                //case CardTypes.Spell:
                //    return new SpellCard(cardName, cardDescription, cardPath, Effects.NoEffect, Effects.NoEffect);
                //case CardTypes.Equip:
                //    return new EquipSpellCard(cardName, cardDescription, cardPath, Effects.NoEffect, Effects.NoEffect, 0, 0);

                default: throw new InvalidParseException(this.deckInfo[this.currentLine - 1]);
                    // THROW CUSTOM EXCEPTION HERE
                    
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
