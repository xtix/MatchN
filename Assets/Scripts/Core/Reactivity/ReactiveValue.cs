using UniRx;

namespace App.Core.Reactivity
{
    public class ReactiveValue<T> : IReactiveObservable<T>, IReactiveNotifier<T>
    {
        public IReadOnlyReactiveProperty<T> Observable => _observable;

        private readonly IReactiveProperty<T> _observable;

        public ReactiveValue() : this(default(T))
        {
        }

        public ReactiveValue(T value)
        {
            _observable = new ReactiveProperty<T>(value);
        }

        public void Notify(T value)
        {
            _observable.Value = value;
        }
    }
}