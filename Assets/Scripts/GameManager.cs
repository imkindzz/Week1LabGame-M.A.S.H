using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton pattern

    private int totalSoldiers;  // Total soldiers in the scene
    private int rescuedSoldiers = 0;  // Tracks soldiers rescued (dropped off at the hospital)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Count the total number of soldiers in the scene at the start
        totalSoldiers = GameObject.FindGameObjectsWithTag("Soldier").Length;
        Debug.Log("Total Soldiers in Scene: " + totalSoldiers);
    }

    private void Update()
    {
        // Check for "R" key press in any scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void SoldierRescued(int count) 
    {
        rescuedSoldiers += count;

        if (rescuedSoldiers >= totalSoldiers)
        {
            WinGame();
        }
    }

    public int GetRescuedSoldiers()
    {
        return rescuedSoldiers;
    }

    public void PlayerLost()
    {
        Debug.Log("Player hit a tree! Game Over.");
        SceneManager.LoadScene("LoseScene"); // Load losing scene
    }

    public void WinGame()
    {
        Debug.Log("All soldiers rescued! You win!");
        SceneManager.LoadScene("WinScene"); // Load winning scene
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
}


