using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PickupHandler : MonoBehaviour
{

    private int count;
    private int totalNum;
    public TextMeshProUGUI counttxt;
    // Start is called before the first frame update
    void Start()
    {
        //totalNum = GameObject.FindGameObjectsWithTag("Collectibles", true).Length;
        totalNum = GameObject.FindObjectsOfType<PickupFloat>(true).Length;

        //to prevent it from including the UI shard
        totalNum -= 1;

        // set count to zero
        count = 0;
        UpdateCount();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectibles"))
        {
            other.gameObject.SetActive(false);
            count++;
            UpdateCount();
        }
    }
    void UpdateCount()
    {
        counttxt.text = count.ToString() + " / " + totalNum.ToString();
    }
}
