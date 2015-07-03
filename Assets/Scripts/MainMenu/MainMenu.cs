using UnityEngine;
using System.Collections;
using Global;

public class MainMenu : MonoBehaviour 
{
    public void LoadNewLevel(int levelID)
    {
        Application.LoadLevel(levelID);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
