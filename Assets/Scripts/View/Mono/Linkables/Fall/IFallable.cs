using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.View.Mono.Linkables.Fall
{
    public interface IFallable
    {
        UniTaskVoid FallAsync(Vector3 to);
    }
}