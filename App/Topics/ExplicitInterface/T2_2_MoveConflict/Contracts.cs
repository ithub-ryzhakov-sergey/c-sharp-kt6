using System;


namespace App.Topics.ExplicitInterface.T2_2_MoveConflict
{
    public interface ILeft
    {
        void Move(int dx);
    }

    public interface IRight
    {
        void Move(int dx);
    }

    public sealed class Cursor : ILeft, IRight
    {
        public int X { get; private set; }

        void ILeft.Move(int dx)
        {
            X -= Math.Abs(dx);
        }

        void IRight.Move(int dx)
        {
            X += Math.Abs(dx);
        }
    }
}