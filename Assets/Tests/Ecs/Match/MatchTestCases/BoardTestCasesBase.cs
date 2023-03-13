using System.Collections;
using System.Collections.Generic;

namespace Tests.Ecs.Match.MatchTestCases
{
    public abstract class BoardTestCasesBase : IEnumerable
    {
        protected abstract int MatchCount { get; }

        public IEnumerator GetEnumerator()
        {
            foreach ((string itemsOnBoard, string matches) tuple in TestCases())
                yield return new object[] { MatchCount, tuple.itemsOnBoard, tuple.matches };
        }

        protected abstract IEnumerable<(string itemsOnBoard, string matches)> TestCases();
    }
}