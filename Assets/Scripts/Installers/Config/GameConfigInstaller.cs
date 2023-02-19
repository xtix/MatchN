using App.Config;
using UnityEngine;
using Zenject;

namespace App.Installers.Config
{
    [CreateAssetMenu(menuName = "Game/Installers/Config/" + nameof(GameConfigInstaller), fileName = nameof(GameConfigInstaller))]
    public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
    {
        [SerializeField] private GameConfig _gameConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameConfig).IfNotBound();
        }
    }
}