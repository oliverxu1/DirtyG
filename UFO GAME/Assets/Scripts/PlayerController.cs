﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;

	public int count;

	public Text CountText;
	public Text WinText;

	private Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		count = 0;
		WinText.text = "";
		TextUpdate ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			TextUpdate ();
		}
	}

	void TextUpdate () {
		CountText.text = "Count: " + count.ToString();
		if (count >= 12) {
			WinText.text = "You Win!";
		}
	}

}
