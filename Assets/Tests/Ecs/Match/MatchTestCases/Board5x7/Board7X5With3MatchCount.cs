using System.Collections.Generic;

namespace Tests.Ecs.Match.MatchTestCases.Board5x7
{
    public class Board7X5With3MatchCount : BoardTestCasesBase
    {
        protected override int MatchCount => 3;

        protected override IEnumerable<(string itemsOnBoard, string matches)> TestCases()
        {
            yield return (itemsOnBoard: @"
                0 1 2 2 1
                1 1 2 3 1
                2 2 2 0 1
                0 1 2 2 3
                1 2 1 1 0
                0 1 1 0 1
                0 1 1 0 1
            ", matches: @"
                - - 2 - 1
                - - 2 - 1
                2 2 2 - 1
                - - 2 - -
                - - 1 - -
                - - 1 - -
                - - 1 - -
            ");

            yield return (itemsOnBoard: @"
                0 1 1 2 1
                1 1 2 3 0
                2 2 1 0 1
                0 1 2 2 3
                1 2 1 1 0
                0 1 2 0 1
                0 1 1 0 1
            ", matches: @"
                - - - - -
                - - - - -
                - - - - -
                - - - - -
                - - - - -
                - - - - -
                - - - - -
            ");
        }
    }
}