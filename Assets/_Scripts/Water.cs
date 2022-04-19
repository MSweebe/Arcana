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
    Vector3 playerDirStart;
    Vector3 playerDirEnd;
    float playerTurn = 0;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        // find where the player is facing and positioned
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos = player.transform.position;
        
        // get where camera is facing
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        playerDir = camera.transform.forward;

        //slow down pitch
        AudioSource splash = GetComponent<AudioSource>();
        splash.pitch = (float)0.5;
        

        //set position in front of player
        startingPos = playerPos + playerDir * distanceAhead;

        //setting easing variables for Update
        transform.position = startingPos;
        birthTime = Time.time;

        yPoints[0] = startingPos.y;
        yPoints[2] = startingPos.y - 1;
        yPoints[1] = startingPos.y + yMax / 2f;

        Vector3 startingScale = transform.localScale;
        startingScale.y = yMax + startingPos.y;

        // sets values for player LERP
        playerDirStart = player.transform.forward;
        playerDirEnd = Projection.ProjectXZ();

        

    }

    void FixedUpdate()
    {
        // Player Lerp
        if (playerTurn <= 1)
        {
            player.transform.forward = Vector3.Lerp(playerDirStart, playerDirEnd, playerTurn);
            playerTurn += .2f;
        }

        // easing
        float u = (Time.time - birthTime) / duration;

        if (u > 1)
        {
            Destroy(this.gameObject);
            return;
        }



        // Interpolate the three Bezier curve points

        u = u + 0.2f * Mathf.Sin(u * Mathf.PI * 1.75f);

        float p01 = (1 - u) * yPoints[0] + u * yPoints[1];

        float p12 = (1 - u) * yPoints[1] + u * yPoints[2];

        Vector3 newPos = transform.position;
        newPos.y = (1 - u) * p01 + u * p12;
        transform.position = newPos;

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
            //floods the plane if there is a written flood
            hitGOScript.UnFlood();
        }
    }
}
