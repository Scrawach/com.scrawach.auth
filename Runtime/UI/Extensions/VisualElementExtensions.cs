using UnityEngine.UIElements;

namespace Plugins.AuthService.Runtime.UI
{
    public static class VisualElementExtensions
    {
        public static void Display(this VisualElement element, bool state) =>
            element.style.display = state ? DisplayStyle.Flex : DisplayStyle.None;
    }
}