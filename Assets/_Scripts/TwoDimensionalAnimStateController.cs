using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimStateController : MonoBehaviour
{
    Animator animator;
    public static float velocityZ = 0.0f;
    public static float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maxWalkVelocity = 0.5f;
    public float maxRunVelocity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed   = Input.GetKey("w");
        bool leftPressed      = Input.GetKey("a");
        //bool backwardsPressed = Input.GetKey("s");
        bool rightPressed     = Input.GetKey("d");
        bool runPressed       = Input.GetKey("left shift");

        float currentMaxVelocity = runPressed ? maxRunVelocity : maxWalkVelocity;

        //update z direction velocity when 'w' is pressed
        if (forwardPressed && velocityZ < currentMaxVelocity){
            velocityZ += Time.deltaTime * acceleration;
        }
        
        //decrease velocityZ when not pressing 'w'
        if(!forwardPressed && velocityZ > 0.0f) {
            velocityZ -= Time.deltaTime * deceleration;
            
        }

        /*********************************************************************************************************/

        //if (backwardsPressed && velocityZ > -currentMaxVelocity){
        //    velocityZ -= Time.deltaTime * acceleration;
        //}

        //if(!backwardsPressed && velocityZ < 0.0f){
        //    velocityZ += Time.deltaTime * deceleration;
        //}

        /*********************************************************************************************************/

        //reset velocityZ 
        if(!forwardPressed && velocityZ < 0.0f){
            velocityZ = 0;
        }

        
        /*********************************************************************************************************/

        if (leftPressed && velocityX > -currentMaxVelocity){
            velocityX -= Time.deltaTime * acceleration;
        }

        //decrease velocityX for left not pressed
        if(!leftPressed && velocityX < 0.0f){
            velocityX += Time.deltaTime * deceleration;
        }

        /*********************************************************************************************************/

        if (rightPressed && velocityX < currentMaxVelocity){
            velocityX += Time.deltaTime * acceleration;
        }

        //decrease velocityX for right not being pressed
        if(!rightPressed && velocityX > 0.0f){
            velocityX -= Time.deltaTime * deceleration;
        }

        /*********************************************************************************************************/

        if(!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f)){
            velocityX = 0.0f;
        }

        /*********************************************************************************************************/

        if(forwardPressed && runPressed && velocityZ > currentMaxVelocity){
            velocityZ = currentMaxVelocity;
        } 
        else if (forwardPressed && velocityZ > currentMaxVelocity){
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f)){
                velocityZ = currentMaxVelocity;
            }
        } 
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f)) {
            velocityZ = currentMaxVelocity;
        }

        /*********************************************************************************************************/

        if(rightPressed && runPressed && velocityX > currentMaxVelocity){
            velocityX = currentMaxVelocity;
        } 
        else if (rightPressed && velocityX > currentMaxVelocity){
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f)){
                velocityX = currentMaxVelocity;
            }
        } 
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f)) {
            velocityX = currentMaxVelocity;
        }

        /*********************************************************************************************************/

        if(leftPressed && runPressed && velocityX < -currentMaxVelocity){
            velocityX = currentMaxVelocity;
        } 
        else if (leftPressed && velocityX < -currentMaxVelocity){
            velocityX += Time.deltaTime * deceleration;
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f)){
                velocityX = -currentMaxVelocity;
            }
        } 
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f)) {
            velocityX = -currentMaxVelocity;
        }

        /*********************************************************************************************************/

        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }
}
