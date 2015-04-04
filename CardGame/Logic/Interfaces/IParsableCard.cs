namespace Logic.Interfaces
{
    using System.Collections.Generic;

    public interface IParsableCard
    {
        string Path { get; }
        IList<ICard> Parse(string path);
    }
}
