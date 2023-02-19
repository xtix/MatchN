using App.Services.Board;
using Leopotam.Ecs;

namespace App.Ecs.Board
{
    public readonly struct BoardComponent
    {
        public readonly BoardSize BoardSize;

        public readonly EcsEntity[,] ItemsLookupTable;

        public BoardComponent(BoardSize boardSize)
        {
            BoardSize = boardSize;
            ItemsLookupTable = new EcsEntity[boardSize.X, boardSize.Y];
        }
    }
}