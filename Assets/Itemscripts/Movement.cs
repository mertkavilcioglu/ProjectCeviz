using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Vector2 moveDirection = Vector2.right;
    public float speed = 1f;
    public float backspeed = -1f;
    private float timer ;
    public bool move=false;
    private int x = 0;
    public void ForwardMovement()
    {
        timer = 1.5f;
        move = true;
        x = 1;
    }
    public void BackMovement()
    {
        Invoke(nameof(MoveBack), 3f);
    }
    public void MoveBack()
    {
        
        timer = 1.5f;
        move = true;
        x = 2;
    }
    public void Update()
    {

        if (timer > 0 && move == true && x==1)
        {
            timer -= Time.deltaTime;
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
        else if (timer > 0 && move == true && x==2)
        {
            timer -= Time.deltaTime;
            transform.Translate(-moveDirection * backspeed * Time.deltaTime);
        }
    }
}
