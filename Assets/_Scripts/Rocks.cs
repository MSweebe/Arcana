using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public float range;
    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 random = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            if (random.x > (range * -1f) && random.x < range || random.z > range * (-1) && random.z < range)
            {
                i--;
                continue;
            }
            Instantiate(prefab, random, Quaternion.identity);
        }
    }

}
