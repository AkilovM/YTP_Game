using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Creator : MonoBehaviour {

	public GameObject water;

    // Use this for initialization
    void Start()
    {
        for (int j = 0; j < 4; j++)
            for (int i = 0; i < 10; i++)
            {
                var newWater = Instantiate(water, new Vector3(-75 + j * 50, (float)-0.7, (float)i * 100), Quaternion.identity);
                newWater.transform.parent = transform;
            }
        gameObject.SetActive(false);
    }
}
