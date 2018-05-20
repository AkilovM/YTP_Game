using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
    public int[] records = new int[10];
	public float speed;
	public Text countText;
	public Text finishText;
	public Text timeText;
    public Text scoresOnFinishText;
    string[] recordsFromFile = new string[10];

	//Time time = (time)(0);
	float time = 0;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int coins;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		coins = 0;

		// Run the SetCountText function to update the UI (see below)
		SetCountText ();

		// Set the text property of our Finish Text UI to an empty string, making the 'Finish' (game over message) blank
		finishText.text = " ";

        scoresOnFinishText.text = " ";

        //recordsFromFile = File.ReadAllLines(Application.streamingAssetsPath + "/MYASSETS/Records.txt");
        //for (var i = 0; i < 10; i++)
        //{
        //    records[i] = recordsFromFile[i];
        //}
    }

    // Each physics step..
    void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal*(float)2.5, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);
        if (finishText.text != "Finish!")
        {
            time += Time.deltaTime;
            timeText.text = "Time: " + time.ToString("#.##");
        }
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			coins = coins + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
        if (other.gameObject.CompareTag("Finish"))
        {
            finishText.text = "Finish!";
        }
    }

    void Update()
    {
        if (gameObject.transform.position.z >= 2497 && finishText.text != "Finish!")
        {
            var scores = 5000 - ((int)time) * 50 + coins * 50;
            if (scores > records[0])
            {
                records[0] = scores;
                Array.Sort(records);
            }
            scoresOnFinishText.text = "Scores: " + scores.ToString();
            finishText.text = "Finish!";
        }
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Coins: " + coins.ToString ();
	}
}
