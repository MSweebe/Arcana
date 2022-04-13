using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Set in Inspector")]

    public float distanceAhead = 1;
    public float reach = 2;
    public float duration = 3f;
    public float size = .5f;
    public float height = .5f;
    float birthTime;
    Vector3 scale;
    Vector3 startingPos;
    Vector3 playerDir;


    void Start()
    {
        //find where the player is facing and positioned
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 playerPos = player.transform.position;
        playerDir = camera.transform.forward;

        //set position of fireball off the ground
        playerPos.y += height * 2f;

        //set position in front of player
        startingPos = playerPos + playerDir * distanceAhead;
        transform.position = startingPos;
        scale = transform.localScale;
        birthTime = Time.time;
    }


    void FixedUpdate()
    {
        float u = (Time.time - birthTime) / duration;
        if (u > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        transform.localScale = scale * (1 + u) * size;
        transform.position += playerDir * Time.deltaTime * reach;
    }

    private void OnTriggerEnter(Collider col)
    {

        GameObject hitGO = col.gameObject;
        if (hitGO.tag == "Environment_Int")
        {
            Interactible hitGOScript = hitGO.GetComponent<Interactible>();

            if (hitGOScript == null)
            {
                return;
            }


            hitGOScript.SetFire();
        }
    }
}
