using App.Constants;
using App.Core.Scene;
using Cysharp.Threading.Tasks;

namespace App.Services.Game.States
{
    public class LoadLevelState : StateBase
    {
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public override void Enter(Game context)
        {
            base.Enter(context);

            LoadAsync().Forget();
        }

        private async UniTaskVoid LoadAsync()
        {
            await _sceneLoader.LoadAsync(AssetAddress.MainLevel);

            Game.ChangeState<InitLevelState>();
        }
    }
}