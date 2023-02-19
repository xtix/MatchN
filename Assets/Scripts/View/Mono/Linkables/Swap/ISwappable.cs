using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.View.Mono.Linkables.Swap
{
    public interface ISwappable
    {
        UniTaskVoid MoveAsync(Vector3 to, bool inFront);
    }
}