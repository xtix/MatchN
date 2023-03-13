using App.Ecs.Board;
using App.Ecs.Board.State;
using App.Ecs.Fall;
using FluentAssertions;
using Leopotam.Ecs;
using NUnit.Framework;
using Tests.Ecs.Fall.FallTestCases;
using Tests.TestHelpers;
using Tests.TestHelpers.Builders;
using Tests.TestHelpers.Extensions;

namespace Tests.Ecs.Fall
{
    public class BoardFallSystemTests : EcsTestsFixture
    {
        private readonly BoardParser _boardParser = new();
        
        [SetUp]
        public void SetUp()
        {
            Systems
                .Add(new BoardFallSystem())
                .Init();
        }

        [TestCaseSource(typeof(Board5X5))]
        public void WhenUnderCellIsEmptyThenItemAboveShouldFall(
            string itemsOnBoard,
            string expectedItemsOnBoard
        ) {
            int?[,] itemTypes = _boardParser.Parse(itemsOnBoard);
            EcsEntity board = new BoardBuilder(World)
                .WithSize(
                    itemTypes.GetLength(0),
                    itemTypes.GetLength(1))
                .WithItems(itemTypes)
                .Build();
            board.Get<BoardFillStateTag>();

            Systems.Run();

            board.Get<BoardComponent>().ToItemTypeArray()
                .Should()
                .BeEquivalentTo(
                    _boardParser.Parse(expectedItemsOnBoard));
        }
    }
}