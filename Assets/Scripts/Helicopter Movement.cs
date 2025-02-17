using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of the helicopter's movement
    public float liftSpeed = 5f;  // Speed of vertical movement (up and down)

    void Update()
    {
        // Horizontal movement (left and right)
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Vertical movement (up and down)
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Upward and downward movement with arrow keys (Page Up / Page Down or "W" and "S" can be used as alternatives)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * liftSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * liftSpeed * Time.deltaTime);
        }

        // Apply horizontal and vertical movement
        transform.Translate(new Vector3(moveHorizontal, 0, moveVertical));
    }
}

