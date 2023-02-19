using App.Ecs.Board.State;
using App.Services.Board;
using Leopotam.Ecs;

namespace App.Ecs.Board
{
    public class BoardInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        private readonly Config.Board.Board _board;

        public BoardInitSystem(Config.Board.Board board)
        {
            _board = board;
        }

        public void Init()
        {
            EcsEntity entity = _world.NewEntity();
            
            entity.Replace(
                new BoardComponent(new BoardSize(_board.XSize, _board.YSize)));
            entity.Get<BoardFillStateTag>();
        }
    }
}