using System;

namespace App.Services.Board.Grid
{
    public readonly struct GridPosition : IEquatable<GridPosition>
    {
        public readonly int X;
        public readonly int Y;

        public GridPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static GridPosition operator +(GridPosition a, GridPosition b) =>
            new(a.X + b.X, a.Y + b.Y);

        public static GridPosition operator -(GridPosition a, GridPosition b) =>
            new(a.X - b.X, a.Y - b.Y);

        public static bool operator ==(GridPosition a, GridPosition b) =>
            a.X == b.X && a.Y == b.Y;

        public static bool operator !=(GridPosition a, GridPosition b) =>
            !(a == b);

        public bool Equals(GridPosition other) =>
            this == other;

        public override bool Equals(object obj) =>
            obj is GridPosition other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(X, Y);
    }
}