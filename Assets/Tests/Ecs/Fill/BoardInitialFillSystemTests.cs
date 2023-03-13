using App.Ecs.Board;
using App.Ecs.Fill;
using App.Ecs.Item.Spawn;
using App.Services.Board;
using App.Services.Item.Type;
using FluentAssertions;
using Leopotam.Ecs;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Ecs.Fill
{
    public class BoardInitialFillSystemTests : EcsTestsFixture
    {
        private readonly EcsFilter<SpawnItemRequest> _spawnItemRequestFilter;

        [SetUp]
        public void SetUp()
        {
            IItemTypePicker itemTypePicker = Substitute.For<IItemTypePicker>();
            itemTypePicker.GetItemType().Returns(0);

            Systems.Add(new BoardInitialFillSystem(itemTypePicker));
        }

        [Test, Combinatorial]
        public void WhenBoardInitialFillingThenSpawnItemRequestsShouldEqualBoardSize(
            [Range(1, 20)] int x,
            [Range(1, 20)] int y
        ) {
            BoardSize boardSize = new BoardSize(x, y);
            World.NewEntity().Replace(
                new BoardComponent(boardSize));

            Systems.Init();

            int spawnItemRequests = _spawnItemRequestFilter.GetEntitiesCount();
            spawnItemRequests.Should().Be(boardSize.Square());
        }
    }
}