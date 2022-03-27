using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirchTree : MonoBehaviour
{
    public Transform prefab;
    public float range;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 random = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            if (random.x > -10.0f && random.x < 10.0f || random.z > -10.0f && random.z < 10.0f)
            {
                i--;
                continue;
            }
            Transform newTree = Instantiate(prefab, random, Quaternion.identity);
            newTree.parent = parent.transform;
        }
    }

}
