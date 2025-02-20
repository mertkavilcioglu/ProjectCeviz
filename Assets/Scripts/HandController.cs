using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveDir;
    Animator animator;


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
        moveDir = gameInput.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Movement with rigidbody(2d)
        Vector2 newPosition = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision detection
        Debug.Log($"HandShake! {collision.gameObject.name}");
    }
}
