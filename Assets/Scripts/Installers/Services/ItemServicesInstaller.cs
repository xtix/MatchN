using System;
using App.Config;
using App.Constants;
using App.Core.Assets;
using App.Core.Object;
using App.Core.Pool;
using App.Core.Pool.Destruct;
using App.Core.Pool.Reinitialize;
using App.Core.Pool.Reset;
using App.Services.Board.Grid;
using App.Services.Item.ColorGenerator;
using App.Services.Item.Type;
using App.Services.Spawner;
using App.View.Mono.Linkables.Item;
using Zenject;

namespace App.Installers.Services
{
    public class ItemServicesInstaller : Installer<ItemServicesInstaller>
    {
        [Inject] private readonly GameConfig _gameConfig;
        
        public override void InstallBindings()
        {
            InstallItemConfigBindings();
            InstallItemSpawnerBindings();
            InstallItemTypePickerBindings();
            InstallItemColorGeneratorBindings();

            Container.BindInterfacesTo<PositionOnBoardService>().AsSingle();
        }

        private void InstallItemConfigBindings()
        {
            Container.BindInstance(_gameConfig.ItemAnimation).AsSingle();
        }

        private void InstallItemSpawnerBindings()
        {
            Container.Bind<IObjectFactory<IItemView, string>>()
                .To<AssetFactory<IItemView, ItemView>>()
                .AsSingle();

            Container.Bind<IObjectPool<IItemView, string>>()
                .To<ObjectPool<IItemView, string>>()
                .AsSingle()
                .WithArguments(CalculateCapacity());
            Container.Decorate<IObjectPool<IItemView, string>>()
                .With<ReinitializableObjectPoolDecorator<IItemView, string>>();
            Container.Decorate<IObjectPool<IItemView, string>>()
                .With<ResettableObjectPoolDecorator<IItemView, string>>();
            Container.Decorate<IObjectPool<IItemView, string>>()
                .With<DestructibleObjectPoolDecorator<IItemView, string>>();

            Container.Bind<ISpawner<IItemView>>()
                .To<PoolableObjectSpawner<IItemView>>()
                .AsSingle()
                .WithArguments(AssetAddress.ItemPrefab);
        }

        private void InstallItemTypePickerBindings()
        {
            Container.BindInstance(_gameConfig.ItemTypesCount).WhenInjectedInto<RandomItemTypePicker>();
            Container.BindInterfacesTo<RandomItemTypePicker>().AsSingle();
        }

        private void InstallItemColorGeneratorBindings()
        {
            Container.BindInstance(_gameConfig.ItemTypesCount).WhenInjectedInto<ItemColorGenerator>();
            Container.BindInterfacesTo<ItemColorGenerator>().AsSingle();
        }

        private int CalculateCapacity()
        {
            return (int) Math.Ceiling(_gameConfig.Board.XSize * _gameConfig.Board.YSize * 0.8);
        }
    }
}