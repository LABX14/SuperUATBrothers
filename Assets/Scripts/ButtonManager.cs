using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int currentSceneIndex = 0;

    public void LoadNextScene()
    {
        // this loads the next scene in the build settings
        GameManager.instance.LoadLevel(currentSceneIndex + 1);
    }
    public void LoadGameScene()
    {
        // this loads the main game scene
        GameManager.instance.LoadLevel("Prototype");
    }

    public void LoadMainMenu()
    {
        // this loads the player into the main menu
        GameManager.instance.LoadLevel("TitleScreen");
    }
}
