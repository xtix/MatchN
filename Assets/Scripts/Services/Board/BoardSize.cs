namespace App.Services.Board
{
    public readonly struct BoardSize
    {
        public readonly int X;
        public readonly int Y;

        public BoardSize(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int Square() => X * Y;
    }
}