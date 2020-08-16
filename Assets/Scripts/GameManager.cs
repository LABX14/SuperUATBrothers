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
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadNextScene();
        }
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
}
