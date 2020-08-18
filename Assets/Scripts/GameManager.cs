using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // This makes instance connected to the game manager
    public int currentSceneIndex = 0; // This sets the current scene index to 0

    public GameObject playerPrefab; // sets as playerPrefab as Game Object
    public GameObject player; // sets player as a Game Object

    public int points = 0; // Set for points

    public int currentSouls; // this determines how many lives the player has at the moment
    public int startSouls; // this determines how many lives the player starts with
    public Vector3 campfire; // this is for the player's checkpoint 

    public AudioClip playerDead; // this is to play the audio for when the player is killed

    void OnEnable()
    {
        // this loads the next scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Awake()
    {
        if (instance == null)
        {
            //this keeps the game manager from being destroyed
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // if instance is not null, then destroy the game manager. 
            Debug.LogError("[GameManager] Attempted to create a second instance of GameManager");
            Destroy(this);
        }
    }

    void Start()
    {
        // this sets the location of the spawn point for the player
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
            // If the current player lives is equal to or less than zero then the player dies
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
        // this will call the level index
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevel(string levelName)
    {
        // this will load the level name 
        SceneManager.LoadScene(levelName);
    }


    /// <summary>
    /// This method is called every time a scene finishes loading.
    /// </summary>
    /// <param name="Scene"></param>
    /// <param name="mode"></param>
    public void OnSceneLoaded(Scene Scene, LoadSceneMode mode)
    {
        // this determines if the scene has loaded
        Debug.Log("Scene finished loading");
        currentSceneIndex = Scene.buildIndex;
    }

    public void LoadNextScene()
    {
        // this loads the next scene in the build settings 
        LoadLevel(currentSceneIndex + 1);
    }
    public void LoadGameScene()
    {
        // this loads the main game scene
        LoadLevel("Prototype");
    }

    public void LoadMainMenu()
    {
        // this loads the player into the main menu
        LoadLevel("TitleScreen");
    }

    public void Victory()
    {
        if (points == 200)
        {
            LoadLevel("Victory");
        }
    }
}
