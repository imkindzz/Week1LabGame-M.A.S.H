using UnityEngine;
using TMPro; // Import TextMeshPro for UI

public class SoldierCollector : MonoBehaviour
{
    public int soldierCount = 0; // Tracks the number of soldiers collected
    public int maxSoldiers = 3;  // Maximum number of soldiers that can be collected
    public TextMeshProUGUI soldierCounterText; // Reference to UI Text

    private void Start()
    {
        UpdateUI(); // Update UI at the start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Soldier"
        if (collision.CompareTag("Soldier") && soldierCount < maxSoldiers)
        {
            CollectSoldier(collision.gameObject);
        }

        // Check if the collided object has the tag "Hospital"
        if (collision.CompareTag("Hospital") && soldierCount > 0)
        {
            DropOffSoldiers();
        }
    }

    private void CollectSoldier(GameObject soldier)
    {
        // Destroy the soldier GameObject
        Destroy(soldier);

        // Increase the soldier count
        soldierCount++;

        // Update UI
        UpdateUI();

        Debug.Log("Soldier collected! Total soldiers: " + soldierCount);

        // Check if the maximum number of soldiers has been collected
        if (soldierCount >= maxSoldiers)
        {
            Debug.Log("Maximum soldiers collected!");
        }
    }

    private void DropOffSoldiers()
    {
        Debug.Log("Dropping off " + soldierCount + " soldiers at the hospital!");

        // Reset the soldier count
        soldierCount = 0;

        // Update UI after drop-off
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (soldierCounterText != null)
        {
            soldierCounterText.text = "Soldiers: " + soldierCount + "/" + maxSoldiers;
        }
    }
}
