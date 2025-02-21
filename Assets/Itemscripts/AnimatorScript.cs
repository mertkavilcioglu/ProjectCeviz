using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    
    
    public Animator animator1;
    public Animator animator2;
    public void BackWalkTimer()
    {
        Invoke(nameof(Walk), 1f);
    }
    public void Walk()
    {
        
        animator1.SetTrigger("WalkTrigger");
        animator2.SetTrigger("WalkTrigger");
    }
    public void Trigger()
    {

        animator1.SetTrigger("readyToShakeTrigger");
        animator2.SetTrigger("readyToShakeTrigger");

    }
    public void ShakeTrigger()
    {
        
        animator1.SetTrigger("shakeTrigger");
        animator2.SetTrigger("shakeTrigger");

    }
    
}
