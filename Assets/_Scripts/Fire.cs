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
    Vector3 cameraDir;
    GameObject player;
    Vector3 playerDirStart;
    Vector3 playerDirEnd;
    float playerTurn = 0;


    void Start()
    {
        // find where the player is facing and positioned
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 playerPos = player.transform.position;
        cameraDir = camera.transform.forward;

        // set position of fireball off the ground
        playerPos.y += height * 2f;

        // set position in front of player
        startingPos = playerPos + cameraDir * distanceAhead;
        transform.position = startingPos;
        scale = transform.localScale;
        birthTime = Time.time;

        // sets values for player LERP
        playerDirStart = player.transform.forward;
        playerDirEnd = Projection.ProjectXZ();
    }


    void FixedUpdate()
    {
        // player LERP
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
        transform.localScale = scale * (1 + u) * size;
        transform.position += cameraDir * Time.deltaTime * reach;
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
