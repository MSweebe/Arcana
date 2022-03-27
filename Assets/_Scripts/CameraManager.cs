using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform targetTransform;  //object camera will follow
    public Transform cameraPivot;      //object cam uses to pivot (up and down)
    public Transform cameraTransform;  //transform of actual camera object
    public LayerMask collisionLayers;
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;
    
    [Header("Camera Speeds")]
    public float camFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2f;
    public float cameraPivotSpeed = 2f;

    [Header("Camera Collision Variables")]
    public float cameraCollisionRadius = 0.2f;
    public float cameraCollisionOffset = 0.2f; //how much camera will jump off objects it collides with
    public float minCollisionOffset = 0.2f;

    [Header("Camera Angles")]
    public float lookAngle;  //make cam look up and down
    public float pivotAngle; //make cam look left and right
    public float minPivotAngle = -40;
    public float maxPivotAngle = 35;

    private void Awake() 
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }

    public void HandleCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }

    private void FollowTarget()
    {
        Vector3 targetPos = Vector3.SmoothDamp
        (transform.position, targetTransform.position, ref cameraFollowVelocity, camFollowSpeed);

        transform.position = targetPos;
    }

    private void RotateCamera()
    {
        Vector3 rotation;

        lookAngle = lookAngle + (inputManager.camInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.camInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRot = Quaternion.Euler(rotation);
        transform.rotation = targetRot;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRot = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRot;
    }
    
    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;

        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if(Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffset);
        }

        if(Mathf.Abs(targetPosition) < minCollisionOffset)
        {
            targetPosition =- minCollisionOffset;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
    
}
