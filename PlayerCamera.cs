using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	
	//This script is holding camera on player

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.SetPositionAndRotation(new Vector3(player.transform.position.x, player.transform.position.y,player.transform.position.z), Quaternion.identity);
	}
}
