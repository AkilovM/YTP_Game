using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectsGenerator : MonoBehaviour {

	public GameObject barrierPrefab;
	public GameObject coinPrefab;
	public float range;
	public int amountOfLines;
	public int barriersOnLine;

	// Use this for initialization
	void Start () {
		if (amountOfLines > 0 && range > 0 && barriersOnLine>=0 && barriersOnLine < 4)
        {
            var posY = gameObject.transform.position.y;
			float delta = range / (amountOfLines - 1); // Расстояние между полос.
			for (var i = 0; i < amountOfLines; i++)
            {
				int tempBarriers = barriersOnLine;
				var fourPlaces = new bool[]{false, false, false, false}; // 4 места у полосы.
				for (var j = 0; j < tempBarriers; j++)
                {
					var barOneOfFour = Random.Range(0,4); // Номер места от 0 до 3.
					while (fourPlaces[barOneOfFour])
						barOneOfFour = Random.Range(0,4);
					Instantiate (barrierPrefab, new Vector3 ((float)(-5.625 + barOneOfFour * 3.75), posY + (float)0.5, gameObject.transform.position.z + i * delta), Quaternion.identity);
					fourPlaces [barOneOfFour] = true; // Место занято барьером.
				}
				var coinOneOfFour = Random.Range(0,4);
				while (fourPlaces[coinOneOfFour]) // Если это место занято
					coinOneOfFour = Random.Range(0,4);
				Instantiate (coinPrefab, new Vector3 ((float)(-5.625 + coinOneOfFour * 3.75), posY + (float)0.8, gameObject.transform.position.z + i * delta), Quaternion.identity);
			}
		}
	}
}
