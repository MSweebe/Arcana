using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Checks if all candles assigned to it are lit.
/// </summary>
/// <para>
/// Must put all candles attached into the array in unity.
/// Must have all triggers set in unity.  When all gameobjects are lit, all triggers are set.
/// </para>
public class CheckLit : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject[] triggersGO;


    private SpriteRenderer[] sprites;
    private Trigger[] triggers;

    public void Start()
    {

        sprites = new SpriteRenderer[gameObjects.Length];
        for (int i = 0; i < sprites.Length; i++)
        {
            // gets flame in candle object
            GameObject child = gameObjects[i].transform.GetChild(0).gameObject;
            if (child != null)
            {
                sprites[i] = child.GetComponent<SpriteRenderer>();
                Debug.Log(sprites[i]);
            }
            else
            {
                Debug.Log("child null");
            }

        }

        triggers = new Trigger[triggersGO.Length];
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i] = triggersGO[i].GetComponent<Trigger>();
        }
    }
    public void Update()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i].enabled == false)
            { // one is not lit
                return;
            }
        }

        // code only reached if all objects renderers in active
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].SetTrigger();
        }
    }

}