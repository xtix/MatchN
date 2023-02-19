using App.Constants;
using App.Core.Object;
using App.Services.SystemComposer;
using App.Services.UI.UIRootProvider;
using App.UI.Hud;
using Cysharp.Threading.Tasks;
using Leopotam.Ecs;
#if UNITY_EDITOR
    using Leopotam.Ecs.UnityIntegration;
#endif

namespace App.Services.Game.States
{
    public class InitLevelState : StateBase
    {
        private readonly EcsWorld _world;
        private readonly ISystemComposer _systemComposer;
        private readonly IObjectFactory<IHud, string> _hudFactory;
        private readonly IUIRootProvider _uiRootProvider;

        public InitLevelState(
            EcsWorld world,
            ISystemComposer systemComposer,
            IObjectFactory<IHud, string> hudFactory,
            IUIRootProvider uiRootProvider
        ) {
            _world = world;
            _systemComposer = systemComposer;
            _hudFactory = hudFactory;
            _uiRootProvider = uiRootProvider;
        }

        public override void Enter(Game context)
        {
            base.Enter(context);

            InitAsync().Forget();
        }

        private async UniTaskVoid InitAsync()
        {
            await _uiRootProvider.InitializeAsync();
            InitEcsSystems();
            await _hudFactory.CreateAsync(AssetAddress.HudPrefab);

            Game.ChangeState<GameLoopState>();
        }

        private void InitEcsSystems()
        {
#if UNITY_EDITOR
            EcsWorldObserver.Create(_world);
#endif

            EcsSystems systems = _systemComposer.Systems;
            systems.Init();

#if UNITY_EDITOR
            EcsSystemsObserver.Create(systems);
#endif
        }
    }
}