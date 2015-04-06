namespace Logic.Delegates
{
    using System;

    public delegate void EventRaiser(object sender, EventArgs e);

    public delegate void Effect();
    public delegate void ParametricEffect(int attack, int defense);
}