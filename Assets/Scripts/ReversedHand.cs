using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversedHand : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveDir;

    private GameInput gameInput;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
        }
        gameInput.Enable();
    }

    private void OnDisable()
    {
        gameInput.Disable();
    }

    private void Update()
    {
        // Get the movement direction from the input system
        moveDir = gameInput.Player.Custom.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Move the hand object using Rigidbody2D
        Vector2 newPosition = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    
}
