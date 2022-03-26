using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirchTree : MonoBehaviour
{
    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(prefab, new Vector3(Random.Range(-20.0f,20.0f), 0, Random.Range(-20.0f,20.0f)), Quaternion.identity);
        }
    }

}
