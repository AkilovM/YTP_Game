using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PogressBar : MonoBehaviour {

	public Slider progressBar;
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.z <= 2500)
			progressBar.value = gameObject.transform.position.z / 2500;
	}
}
