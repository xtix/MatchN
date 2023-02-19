using App.Core.Assets.Provider;
using Cysharp.Threading.Tasks;

namespace App.Services.Game.States
{
    public class BootstrapState : StateBase
    {
        private readonly IAssetProvider _assetProvider;

        public BootstrapState(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public override void Enter(Game context)
        {
            base.Enter(context);

            InitAsync().Forget();
        }

        private async UniTaskVoid InitAsync()
        {
            await _assetProvider.InitializeAsync();
            
            Game.ChangeState<LoadLevelState>();
        }
    }
}