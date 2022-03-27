using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [Header("Set in Inspector")]

    public float distanceAhead = 1f;
    public float yMax = 1f;
    public float duration = 1;

    public float size = 1f;
    public float sinEccentricity = 01f;

    float birthTime = -1;
    Vector3 startingPos;
    Vector3 playerDir;
    const float Step1Dur = .8f;
    const float pauseHeight = .3f;

    float[] yPoints = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        //find where the player is facing and positioned
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos = player.transform.position;
        playerDir = player.transform.forward;


        //set position in front of player
        startingPos = playerPos + playerDir * distanceAhead;

        //setting variables for Update
        transform.position = startingPos;
        birthTime = Time.time;

        yPoints[0] = startingPos.y;
        yPoints[2] = startingPos.y - 1;
        yPoints[1] = startingPos.y + yMax;

    }

    // Update is called once per frame
    void Update()
    {

        float u = (Time.time - birthTime) / duration;

        if (u > 1)
        {

            // This Enemy_3 has finished its life
            Destroy(this.gameObject);
            return;

        }



        // Interpolate the three Bezier curve points

        u = u + 0.2f * Mathf.Sin(u * Mathf.PI * 1.75f);

        float p01 = (1 - u) * yPoints[0] + u * yPoints[1];

        float p12 = (1 - u) * yPoints[1] + u * yPoints[2];


        Vector3 newScale = transform.localScale;
        newScale.y = (1 - u) * p01 + u * p12;
        transform.localScale = newScale;


    }
    private void OnTriggerEnter(Collider col)
    {

        GameObject hitGO = col.gameObject;
        if (hitGO.tag == "Environment_Int")
        {
            Debug.Log("Interactible");

            Interactible hitGOScript = hitGO.GetComponent<Interactible>();

            if (hitGOScript.canFlood && hitGOScript.isFlooded && Time.time - hitGOScript.intStart > duration)
            {
                hitGOScript.isFlooded = false;
            }
            else if (hitGOScript.canFlood)
            {
                hitGOScript.isFlooded = true;

            }
        }
    }
}
