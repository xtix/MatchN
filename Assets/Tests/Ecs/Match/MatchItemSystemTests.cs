using App.Ecs.Board;
using App.Ecs.Board.State;
using App.Ecs.Match;
using App.Ecs.Match.Check;
using FluentAssertions;
using Leopotam.Ecs;
using NUnit.Framework;
using Tests.Ecs.Match.MatchTestCases.Board3X3;
using Tests.Ecs.Match.MatchTestCases.Board5x7;
using Tests.TestHelpers;
using Tests.TestHelpers.Builders;
using Tests.TestHelpers.Extensions;

namespace Tests.Ecs.Match
{
    public class MatchItemSystemTests : EcsTestsFixture
    {
        private readonly EcsFilter<MatchedEvent> _matchedItemFilter;
        
        private readonly BoardParser _boardParser = new();

        [TestCaseSource(typeof(Board3X3With2MatchCount))]
        [TestCaseSource(typeof(Board3X3With3MatchCount))]
        [TestCaseSource(typeof(Board7X5With3MatchCount))]
        [TestCaseSource(typeof(Board7X5With4MatchCount))]
        public void WhenItemsInRowVerticallyOrHorizontallyThenItemsShouldBeMatched(
            int matchCount,
            string itemsOnBoard,
            string expectedMatches
        ) {
            Systems
                .Add(new MatchItemSystem(matchCount))
                .Init();
            int?[,] itemTypes = _boardParser.Parse(itemsOnBoard);
            EcsEntity board = new BoardBuilder(World)
                .WithSize(
                    itemTypes.GetLength(0),
                    itemTypes.GetLength(1))
                .WithItems(itemTypes)
                .Build();
            board.Get<MatchStateTag>();
            MarkItemsAsReadyToMatch(board);

            Systems.Run();

            board.Get<BoardComponent>().ToItemTypeArray(e => e.Has<MatchedEvent>())
                .Should()
                .BeEquivalentTo(
                    _boardParser.Parse(expectedMatches));
        }

        private void MarkItemsAsReadyToMatch(in EcsEntity board)
        {
            ref BoardComponent boardComponent = ref board.Get<BoardComponent>();

            for (int x = 0; x < boardComponent.BoardSize.X; x++)
                for (int y = 0; y < boardComponent.BoardSize.Y; y++)
                    boardComponent.ItemsLookupTable[x, y].Get<CheckMatchRequest>();
        }
    }
}