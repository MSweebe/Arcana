using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cam;
    public CharacterController controller; 
    private Rigidbody rb;
    private Animator anim;
    RaycastHit hit;

    public float speed = 6.0f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public float jumpForce;
    private float ySpeed;
    private float distanceToGround = 0.5f;
    bool isGrounded = true;

    Vector3 moveVector;
    
    void Start() {
        rb = GetComponent<Rigidbody>();   
        Debug.Log(anim);
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero; //reset gravity vector
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if(direction.magnitude >= 0.1f){
            //returns angle from x-axis to line starting at x and ending at y (in rads)
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
            
        }
    }
}
