using UnityEngine;

public class ScreenState
{
    private GameObject _currentScreen;

    public void SetScreen(GameObject screen)
    {
        if (_currentScreen != null)
        {
            GameObject.Destroy(_currentScreen);
        }
        _currentScreen =  GameObject.Instantiate(screen);
    }
}