using App.Config;
using App.Core.Reactivity;
using App.Ecs.Board;
using App.Ecs.Board.State.Transitions;
using App.Ecs.Camera;
using App.Ecs.Fall;
using App.Ecs.Fill;
using App.Ecs.Input.Click;
using App.Ecs.Input.ClickReleased;
using App.Ecs.Item.Destroy;
using App.Ecs.Item.Drag;
using App.Ecs.Item.Selection;
using App.Ecs.Item.Spawn;
using App.Ecs.Item.Swap;
using App.Ecs.Item.Swap.Undo;
using App.Ecs.Match;
using App.Ecs.Match.Check;
using App.Ecs.Player;
using App.Ecs.Player.Score;
using App.Ecs.Spawn;
using App.Ecs.View.Color;
using App.Ecs.View.Fall;
using App.Ecs.View.Item.Despawn;
using App.Ecs.View.Position;
using App.Installers.Services.Reactivity;
using App.Services.SystemComposer;
using Leopotam.Ecs;
using Zenject;

namespace App.Installers.Ecs.SystemsGroups
{
    public class GameSystemsInstaller : Installer<GameSystemsInstaller>
    {
        [Inject] private GameConfig _gameConfig;

        [Inject(Id = PlayerScoreChangeReactiveValueInstaller.PlayerScoreChangeReactiveValueServiceId)]
        private ReactiveValue<int> _playerScoreChangeReactiveValue;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameConfig.MatchCount).WhenInjectedInto<MatchItemSystem>();
            Container.BindInstance(_gameConfig.Board).WhenInjectedInto<BoardInitSystem>();
            Container.Bind<IReactiveNotifier<int>>()
                .FromInstance(_playerScoreChangeReactiveValue)
                .WhenInjectedInto<PlayerScoreChangedNotificationSystem>();

            // systems order is important
            Container.Bind<IEcsSystem>()
                .To(
                    typeof(ClickPressedSystem),
                    typeof(ClickReleasedSystem),
                    
                    typeof(PlayerInitSystem),
                    typeof(BoardInitSystem),
                    typeof(CameraFocusOnBoardSystem),
                    typeof(BoardInitialFillSystem),

                    typeof(BoardFallSystem),
                    typeof(BoardFillSystem),
                    typeof(SpawnItemSystem),
                    typeof(FallItemOnBoardWhenEntityLoadedSystem),
                    typeof(MatchItemSystem),
                    typeof(MatchedItemScoreSystem),
                    typeof(CancelUndoSwapItemsSystem),
                    typeof(UndoSwapItemsSystem),
                    typeof(ItemUnselectionSystem),
                    typeof(ItemSelectionSystem),
                    typeof(DragItemsSystem),
                    typeof(SwapItemsSystem),
                    typeof(RequireMatchCheckSystem),
                    typeof(RequestDestroyMatchedItemSystem),

                    typeof(PlayerScoreChangedNotificationSystem),

                    typeof(RenderPositionWhenEntityLoadedSystem),
                    typeof(RenderColorWhenEntityLoadedSystem),
                    typeof(RenderFallSystem),

                    typeof(DespawnViewSystem),
                    typeof(DestroyItemAfterAnimationCompletedSystem),
                    typeof(DeleteSpawnPositionWhenEntityLoadedSystem),
                    
                    typeof(BoardFillToMatchTransitionSystem),
                    typeof(MatchToBoardFillTransitionSystem),
                    typeof(MatchToInputTransitionSystem),
                    typeof(InputToMatchTransitionSystem)
                )
                .AsSingle()
                .WhenInjectedInto<GameSystemComposer>();

            Container.Bind<GameSystemComposer>().AsSingle();
        }
    }
}