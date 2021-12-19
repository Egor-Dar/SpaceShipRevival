using CorePlugin.Extensions;
using UnityEngine;

namespace ScreenSystem
{
    public class ScreenState
    {
        private CanvasGroup _currentScreen;

        public void SetScreen(CanvasGroup screen)
        {
            if (_currentScreen != null)
            {
                _currentScreen.ChangeGroupState(false);
            }
            screen.ChangeGroupState(true);
            _currentScreen = screen;
        }
    }
}
