using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton Implementation

    // Singleton instance
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }

    #endregion
    #region Properties and Fields

    // Player reference
    public GameObject playerPrefab;
    private Player playerInstance;

    // Inspector-visible default player state
    [SerializeField] private string playerName = "Player1"; // Default player name
    [SerializeField] private int playerHealth = 100;        // Default health
    [SerializeField] private int score = 0;                 // Default score

    #endregion

    #region Unity Methods
    private void Start()
    {
        // Initialize with default values
        Debug.Log("GameManager initialized with default player state");
    }
    #endregion

    #region Custom Public Methods

    // Method to instantiate the player and keep track of its instance
    public void SpawnPlayer(Vector3 spawnPosition)
    {
        if (playerInstance == null) // Ensure we don't spawn multiple players
        {
            GameObject playerObject = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
            playerInstance = playerObject.GetComponent<Player>();
        }
    }

    #endregion
}
