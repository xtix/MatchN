using System.Collections.Generic;
using App.Ecs.Board.Grid;
using App.Ecs.Fall;
using App.Ecs.Fill;
using App.Ecs.Input.Click;
using App.Ecs.Input.ClickReleased;
using App.Ecs.Load;
using App.Ecs.Match;
using App.Ecs.Player.Score;
using Leopotam.Ecs;

namespace App.Services.SystemComposer
{
    public class GameSystemComposer : SystemComposerBase
    {
        public GameSystemComposer(EcsWorld ecsWorld, List<IEcsSystem> ecsSystems) : base(ecsWorld, ecsSystems)
        {
        }

        protected override EcsSystems AddOneFrameComponents(EcsSystems systems)
        {
            return base.AddOneFrameComponents(systems)
                .OneFrame<BoardFilledEvent>()
                .OneFrame<ClickEvent>()
                .OneFrame<ClickReleasedEvent>()
                .OneFrame<PositionOnBoardChangedEvent>()
                .OneFrame<MatchedEvent>()
                .OneFrame<PlayerScoreChangedEvent>()
                .OneFrame<EntityLoadedEvent>()
                .OneFrame<FallEvent>()
            ;
        }
    }
}