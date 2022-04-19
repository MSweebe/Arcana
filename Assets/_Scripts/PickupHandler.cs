using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PickupHandler : MonoBehaviour
{

    private int count;
    public TextMeshProUGUI counttxt;
    // Start is called before the first frame update
    void Start()
    {
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
        counttxt.text = "Shards: " + count.ToString();
    }
}
