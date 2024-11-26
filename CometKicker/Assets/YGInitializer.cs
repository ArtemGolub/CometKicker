using UnityEngine;

public class YGInitializer : MonoBehaviour
{
    void Awake()
    {
        ToggleFullscreen();
    }
    private void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
