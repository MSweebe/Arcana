using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    [Header("Set in Inspector")]

    public float distanceAhead = 1f;
    public float yMax = 1f;
    public float duration = 1;
    public float height = 0;

    public float size = 1f;
    public float sinEccentricity = 0.6f;

    float phase1Start = -1;
    float phase2Start = -1;
    Vector3 startingPos;
    Vector3 playerDir;
    const float Step1Dur = .8f;
    const float pauseHeight = .3f;
    const float PauseDur = .3f;
    const float TopTime = .8f;
    const float Pause2Dur = 1;

    // Start is called before the first frame update
    void Start()
    {
        //find where the player is facing and positioned
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos = player.transform.position;
        playerDir = player.transform.forward;

        //set position of air off the ground
        playerPos.y += height;

        //set position in front of player
        startingPos = playerPos + playerDir * distanceAhead;

        //setting variables for Update
        transform.position = startingPos;
        phase1Start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //duration of action Bezier
        float u = (Time.time - phase1Start) / Step1Dur;
        float v = (Time.time - phase2Start) / TopTime; //scaled so when it is one Ymax is reached

        if (u < 1) // for first rise
        {
            //Easing on both assents
            u = u + sinEccentricity * (Mathf.Sin(u * Mathf.PI));

            Vector3 currentScale = transform.localScale;

            currentScale.y = (1 - u) * 0f + u * (pauseHeight);
            // Interpolate the two linear interpolation points

            transform.localScale = currentScale;
        }
        else if (u >= 1 && u < 1 + PauseDur) // for first pause
        {
            phase2Start = Time.time;
            return;
        }
        else if (v >= 0 && v < TopTime) // for second rise
        {
            v = v + sinEccentricity * (Mathf.Sin(v * Mathf.PI));

            Vector3 currentScale = transform.localScale;

            currentScale.y = (1 - v) * pauseHeight + v * (yMax);
            // Interpolate the two linear interpolation points

            transform.localScale = currentScale;
        }
        else if (v >= TopTime && v < TopTime + Pause2Dur) // for second pause
        {
            return;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
