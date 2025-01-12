using UniRx;
using static Newspaper.Windows.WindowView;

namespace Newspaper.Windows
{
    public class WindowModel
    {
        public ReactiveProperty<WindowType> CurrentWindow { get; } = new ReactiveProperty<WindowType>();
    }
}