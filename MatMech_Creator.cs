using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatMech_Creator : MonoBehaviour {

    public GameObject matMech;
    public GameObject player;
    bool worked = false;

	// Update is called once per frame
	void Update () {
        if (!worked && player.transform.position.z >= 600)
        {
            matMech.SetActive(true);
            var randomInt = Random.Range(0, 2);
            var rb = matMech.GetComponent<Rigidbody>();
            if (randomInt == 1) // Рандомное появление матмеха слева или справа.
                rb.AddForce(new Vector3(-5000, 0, 0)); // Справа.
            else
            {
                matMech.transform.SetPositionAndRotation(new Vector3(-122, 32, 745), Quaternion.Euler(90, 0, 0));
                rb.AddForce(new Vector3(5000, 0, 0)); // Слева.
            }
            worked = true;
        }
	}
}
