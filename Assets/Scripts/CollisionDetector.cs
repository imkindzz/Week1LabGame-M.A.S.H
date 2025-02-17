using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Tree"
        if (collision.CompareTag("Tree"))
        {
            Debug.Log("Game Over! Helicopter hit a tree.");
            GameManager.Instance.PlayerLost(); // Use PlayerLost from GameManager
        }
    }
}

