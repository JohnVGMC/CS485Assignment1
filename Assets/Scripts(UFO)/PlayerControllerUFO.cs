using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerUFO : MonoBehaviour {

	public float speed;
	public Text countRemainingText;
	public Text winText;
	public Text timer;

	private float timeElapsed;
	private int minutes;
	private float seconds;
	private int countRemaining;
	private Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		countRemaining = 5;
		winText.text = "";
		SetCountRemainingText ();
	}
	 
	void Update()
	{
		if(countRemaining > 0){
			timeElapsed += Time.deltaTime;
			minutes = Mathf.FloorToInt (timeElapsed / 60);
			seconds = Mathf.Round ((timeElapsed % 60) * 100f) / 100f;
			timer.text = "Time: " + minutes.ToString () + ":";
			if (seconds < 10)
				timer.text += "0";
			timer.text += seconds.ToString ("F");
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);


	}
		
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			countRemaining = countRemaining - 1;
			SetCountRemainingText ();
		} else if (other.gameObject.CompareTag ("SpeedBoosterUp")) {
			rb2d.velocity = new Vector3 (0, 40, 0);
		} else if (other.gameObject.CompareTag ("SpeedBoosterDown")) {
			rb2d.velocity = new Vector3 (0, -40, 0);
		} else if (other.gameObject.CompareTag ("SpeedBoosterLeft")) {
			rb2d.velocity = new Vector3 (-40, 0, 0);
		} else if (other.gameObject.CompareTag ("SpeedBoosterRight")) {
			rb2d.velocity = new Vector3 (40, 0, 0);
		} else if (other.gameObject.CompareTag ("OutOfBounds")) {
			rb2d.position = new Vector2 (0, 0);
			rb2d.velocity = new Vector3 (0, 0, 0);
		}
	} 

	void SetCountRemainingText()
	{
		countRemainingText.text = "Remaining: " + countRemaining.ToString ();
		if (countRemaining <= 0) {
			winText.text = "You Win!";
		}
	}
}
