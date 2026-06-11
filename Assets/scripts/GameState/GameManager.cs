using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static GameManager instance;
    Vector3 playerTransform;
    string exploration;
    public List<CharacterDefinition> currentEnemies;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEncounter(Vector3 PT, List<CharacterDefinition> enemies)
    {
        Debug.Log("Encounter Started");
        currentEnemies = new List<CharacterDefinition>(enemies);
        exploration = SceneManager.GetActiveScene().name;
        string Sc = exploration + "_Encounter";
        playerTransform = PT;
        SceneManager.LoadScene(Sc, LoadSceneMode.Single);
    }

    public void EndEncounter()
    {
        Debug.Log("Encounter Ended");
        SceneManager.sceneLoaded += OnSceneLoadedAfterEncounter;
        SceneManager.LoadScene(exploration, LoadSceneMode.Single);
    }

    public void SetPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && SceneManager.GetActiveScene().name == exploration)
        {
            player.transform.position = playerTransform;
        }
    }

    private void OnSceneLoadedAfterEncounter(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == exploration)
        {
            SetPlayer();
            SceneManager.sceneLoaded -= OnSceneLoadedAfterEncounter; // Unsubscribe after setting the player
        }
    }
}
