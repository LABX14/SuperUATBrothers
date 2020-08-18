using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int currentSceneIndex = 0;

    public void LoadNextScene()
    {
        GameManager.instance.LoadLevel(currentSceneIndex + 1);
    }
    public void LoadGameScene()
    {
        GameManager.instance.LoadLevel("Prototype");
    }

    public void LoadMainMenu()
    {
        GameManager.instance.LoadLevel("TitleScreen");
    }
}
