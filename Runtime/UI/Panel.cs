using UnityEngine.UIElements;

namespace Plugins.AuthService.Runtime.UI
{
    public abstract class Panel
    {
        private readonly VisualElement _root;

        protected Panel(VisualElement root) => 
            _root = root;

        public void Show() => 
            _root.Display(true);

        public void Hide() => 
            _root.Display(false);
    }
}