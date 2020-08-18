using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentSceneIndex = 0;

    public GameObject playerPrefab;
    public GameObject player;

    public int points;

    public int currentSouls;
    public int startSouls;
    public Vector3 campfire;

    public AudioClip playerDead;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogError("[GameManager] Attempted to create a second instance of GameManager");
            Destroy(this);
        }
    }

    void Start()
    {
        campfire = new Vector3(0, 0, 0);
        startSouls = currentSouls;
    }

    // if playerDeath activates, 
    // then it will subtract the number of lives from the player and when that number is less than or equal to zero, 
    // then it will bring up the game over screen. 
    public void playerDeath()
    {
        if (currentSouls > 0)
        {
            // If the current player 
            currentSouls -= 1;
            Destroy(player);
            Instantiate(playerPrefab, campfire, playerPrefab.transform.rotation);
            AudioSource.PlayClipAtPoint(playerDead, transform.position);
        }
        else
        {
            // Loads into the Game Over Scene
            SceneManager.LoadScene("GameOver");
        }
    }


    void Update()
    {
       /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadNextScene();
        }*/
    } 
    

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


    /// <summary>
    /// This method is called every time a scene finishes loading.
    /// </summary>
    /// <param name="Scene"></param>
    /// <param name="mode"></param>
    public void OnSceneLoaded(Scene Scene, LoadSceneMode mode)
    {
        Debug.Log("Scene finished loading");
        currentSceneIndex = Scene.buildIndex;
    }

    public void LoadNextScene()
    {
        LoadLevel(currentSceneIndex + 1);
    }
    public void LoadGameScene()
    {
        LoadLevel("Prototype");
    }

    public void LoadMainMenu()
    {
        LoadLevel("TitleScreen");
    }
}
