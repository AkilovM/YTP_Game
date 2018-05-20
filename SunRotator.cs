using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotator : MonoBehaviour {

	public GameObject player;
	private float oldPlayerPosZ;
	// Use this for initialization
	void Start () {
		oldPlayerPosZ = player.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float newPlayerPosZ = player.transform.position.z;
		float delta = newPlayerPosZ - oldPlayerPosZ;
		transform.Rotate (delta/5, 0, 0);
		oldPlayerPosZ = newPlayerPosZ;
	}
}
