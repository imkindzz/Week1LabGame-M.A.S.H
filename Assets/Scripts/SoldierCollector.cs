using UnityEngine;
using TMPro; // Import TextMeshPro for UI

public class SoldierCollector : MonoBehaviour
{
    public int soldierCount = 0;          // Tracks the number of soldiers collected
    public int maxSoldiers = 3;           // Maximum number of soldiers that can be collected
    public int rescuedSoldiers = 0;       // Total number of soldiers rescued
    public TextMeshProUGUI soldierCounterText;    // UI for current soldiers
    public TextMeshProUGUI rescuedCounterText;    // UI for rescued soldiers

    private void Start()
    {
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Soldier") && soldierCount < maxSoldiers)
        {
            CollectSoldier(collision.gameObject);
        }

        if (collision.CompareTag("Hospital") && soldierCount > 0)
        {
            DropOffSoldiers();
        }
    }

    private void CollectSoldier(GameObject soldier)
    {
        Destroy(soldier);
        soldierCount++;
        UpdateUI();

        Debug.Log("Soldier collected! Total soldiers: " + soldierCount);
    }

    private void DropOffSoldiers()
    {
        rescuedSoldiers += soldierCount;  // Add current soldiers to rescued total
        Debug.Log("Dropped off " + soldierCount + " soldiers at the hospital! Total rescued: " + rescuedSoldiers);

        soldierCount = 0;  // Reset current soldier count
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (soldierCounterText != null)
        {
            soldierCounterText.text = "Soldiers: " + soldierCount + "/" + maxSoldiers;
        }
        if (rescuedCounterText != null)
        {
            rescuedCounterText.text = "Rescued: " + rescuedSoldiers;
        }
    }
}

