using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //bool walkPress = Input.GetKey("w");
        bool runRight, runLeft, runForward, runBack;
        
        runRight = Input.GetKey(KeyCode.D);
        runLeft = Input.GetKey(KeyCode.A);
        runForward = Input.GetKey(KeyCode.W);
        runBack = Input.GetKey(KeyCode.S);

        if(runForward){
            animator.SetBool("isRunning", true);
        }
        if(runLeft){
            animator.SetBool("isRunning", true);
        }
        if(runRight){
            animator.SetBool("isRunning", true);
        }
        if(runBack){
            animator.SetBool("isRunning", true);
        }

        if(!runForward && !runBack && !runLeft && !runRight){
            animator.SetBool("isRunning", false);
        }
        
    }
}
