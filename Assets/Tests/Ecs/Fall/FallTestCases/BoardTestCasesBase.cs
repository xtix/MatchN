using System.Collections;
using System.Collections.Generic;

namespace Tests.Ecs.Fall.FallTestCases
{
    public abstract class BoardTestCasesBase : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            foreach ((string itemsOnBoard, string expectedItemsOnBoard) tuple in TestCases())
                yield return new object[] { tuple.itemsOnBoard, tuple.expectedItemsOnBoard };
        }

        protected abstract IEnumerable<(string itemsOnBoard, string expectedItemsOnBoard)> TestCases();
    }
}