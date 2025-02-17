using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Tree"
        if (collision.CompareTag("Tree"))
        {
            Debug.Log("Game Over! Helicopter hit a tree.");
            EndGame();
        }
    }

    private void EndGame()
    {
        // Add your game over logic here
        // For example, you can stop the game or load a game over scene
        UnityEditor.EditorApplication.isPlaying = false; // Stops the game in the editor
        Application.Quit(); // Quits the game in a build
    }
}
