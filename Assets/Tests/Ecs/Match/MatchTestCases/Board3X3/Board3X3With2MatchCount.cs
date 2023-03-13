using System.Collections.Generic;

namespace Tests.Ecs.Match.MatchTestCases.Board3X3
{
    public class Board3X3With2MatchCount : BoardTestCasesBase
    {
        protected override int MatchCount => 2;

        protected override IEnumerable<(string itemsOnBoard, string matches)> TestCases()
        {
            yield return (itemsOnBoard: @"
                0 1 2
                3 1 0
                0 1 3
            ", matches: @"
                - 1 -
                - 1 -
                - 1 -
            ");

            yield return (itemsOnBoard: @"
                2 2 1
                1 2 2
                0 1 0
            ", matches: @"
                2 2 -
                - 2 2
                - - -
            ");
            
            yield return (itemsOnBoard: @"
                1 0 1
                2 0 0
                1 0 1
            ", matches: @"
                - 0 -
                - 0 0
                - 0 -
            ");

            yield return (itemsOnBoard: @"
                1 0 1
                0 1 0
                2 0 1
            ", matches: @"
                - - -
                - - -
                - - -
            ");
        }
    }
}