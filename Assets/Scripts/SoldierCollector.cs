using UnityEngine;
using TMPro;

public class SoldierCollector : MonoBehaviour
{
    public int soldierCount = 0;
    public int maxSoldiers = 3;
    public TextMeshProUGUI soldierCounterText;
    public TextMeshProUGUI rescuedCounterText;
    public AudioClip pickupSound; // Assign the sound in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        // Play pickup sound
        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
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



