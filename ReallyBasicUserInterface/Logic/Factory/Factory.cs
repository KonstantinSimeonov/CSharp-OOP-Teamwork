namespace Logic.Factory
{
    using System;
    using System.IO;
    using Logic.Interfaces;
    using Logic.Cards;

    public class Factory : IFactory
    {
        private const char SPLIT = ',';
        private const string MONSTER_CARD = "Monster";
        private const string SPECIAL_MONSTER_CARD = "SpecialMonster";
        private const string EQUIP_CARD = "Equip";
        private const string TRAP_CARD = "Trap";
        private const string FIELD_CARD = "Field";
        private const string INVALID_ARG = "Wrong message from parsed txt";

        private const string path = @"..\..\CardInfo\CardInfo.txt";
        private static readonly StreamReader cardReader = new StreamReader(path);

        public Factory()
        {
        
        }

        public ICard CreateCard()
        {
            // catch exception
            string[] cardCommand = cardReader.ReadLine().Split(Factory.SPLIT);

            switch (cardCommand[0])
            {
                case Factory.MONSTER_CARD: 
                    return new MonsterCard(cardCommand[1], cardCommand[2], cardCommand[3], int.Parse(cardCommand[4]), int.Parse(cardCommand[5]));
                case Factory.EQUIP_CARD:
                    throw new NotImplementedException("Dotuk dobre");
                default:
                    throw new ArgumentException(Factory.INVALID_ARG);
            }
        }

        public IPlayer CreatePlayer(bool isAI)
        {
            throw new NotImplementedException();
        }
    }
}
