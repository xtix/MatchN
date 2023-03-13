using System.Collections.Generic;

namespace Tests.Ecs.Fall.FallTestCases
{
    public class Board5X5 : BoardTestCasesBase
    {
        protected override IEnumerable<(string itemsOnBoard, string expectedItemsOnBoard)> TestCases()
        {
            yield return (itemsOnBoard: @"
                - - - - -
                - - - - -
                - - - - -
                - 1 - - -
                1 - 1 1 1
            ", expectedItemsOnBoard: @"
                - - - - -
                - - - - -
                - - - - -
                - - - - -
                1 1 1 1 1
            ");
            
            yield return (itemsOnBoard: @"
                - 1 - - 1
                - - 2 1 -
                - - - - -
                2 1 - 2 -
                - - 1 - -
            ", expectedItemsOnBoard: @"
                - - - - -
                - 1 - - 1
                - - 2 1 -
                - - - - -
                2 1 1 2 -
            ");
            
            yield return (itemsOnBoard: @"
                - - - - -
                - - - - -
                2 - - - -
                1 - - 1 -
                2 1 1 2 2
            ", expectedItemsOnBoard: @"
                - - - - -
                - - - - -
                2 - - - -
                1 - - 1 -
                2 1 1 2 2
            ");
        }
    }
}