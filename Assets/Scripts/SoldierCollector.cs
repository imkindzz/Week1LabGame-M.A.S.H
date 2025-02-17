using UnityEngine;
using TMPro;

public class SoldierCollector : MonoBehaviour
{
    public int soldierCount = 0;
    public int maxSoldiers = 3;
    public TextMeshProUGUI soldierCounterText;
    public TextMeshProUGUI rescuedCounterText;

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
    }

    private void DropOffSoldiers()
    {
        // Notify GameManager that soldiers have been rescued
        GameManager.Instance.SoldierRescued(soldierCount);
        soldierCount = 0;
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
            rescuedCounterText.text = "Rescued: " + GameManager.Instance.GetRescuedSoldiers();
        }
    }
}



