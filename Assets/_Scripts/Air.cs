using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    [Header("Set in Inspector")]

    public float distanceAhead = 1f;
    public float floatDist = .5f;
    public float duration = 3f;
    public float height = .5f;

    public float size = 1f;


    float birthTime;
    Vector3 scale;
    Vector3 startingPos;
    Vector3 playerDir;

    // Start is called before the first frame update
    void Start()
    {
        // find where the player positioned
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos = player.transform.position;

        // get camera dir
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        playerDir = camera.transform.forward;

        // set position of air off the ground
        playerPos.y += height;

        // set position in front of player
        startingPos = playerPos + playerDir * distanceAhead;

        // setting variables for Update
        transform.position = startingPos;
        scale = transform.localScale;
        birthTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // duration of action
        float u = (Time.time - birthTime) / duration;

        if (u > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        // changing scale

        transform.localScale = scale * (1 + u) * size;

        Vector3 pos = transform.position;

        pos.y = startingPos.y + height + Mathf.Sin(u * 2 * Mathf.PI * 4) * floatDist;

        transform.position = pos;


    }
    private void OnTriggerEnter(Collider col)
    {

        GameObject hitGO = col.gameObject;
        if (hitGO.tag == "Environment_Int")
        {
            //Debug.Log("Interactible");

            Interactible hitGOScript = hitGO.GetComponent<Interactible>();
            if (hitGOScript == null)
            {
                return;
            }

            hitGOScript.PutOutFire();

        }
    }
}
