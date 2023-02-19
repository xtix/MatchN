using UniRx;

namespace App.Core.Reactivity
{
    public interface IReactiveObservable<T>
    {
        IReadOnlyReactiveProperty<T> Observable { get; }
    }
}