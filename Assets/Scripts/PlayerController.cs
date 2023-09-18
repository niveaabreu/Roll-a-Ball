using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;

	public TextMeshProUGUI tempoTexto;

	private float tempo;
	public GameObject winTextObject;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;

	public AudioSource pickupSound;

	public TextMeshProUGUI velocidadeTexto;

	public AudioSource velocidadeSom;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
		velocidadeTexto.text = "Velocidade: "+ this.speed.ToString();

		// Set the count to zero 
		count = 0;

		tempo = 40.0f;

		SetCountText ();

                // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);

		pickupSound.Stop();
		velocidadeSom.Stop();
	}

	void Update(){
		if (tempo > 0){
			tempo = tempo - Time.deltaTime;
			tempoTexto.text = "Tempo: "+Convert.ToInt32(tempo).ToString();
		}
		else{
			SceneManager.LoadScene("Scenes/over");
		}
		
	}

	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.CompareTag("Collision"))
		{

			// Add one to the score variable 'count'
			this.speed -= (float) 2.5;
			velocidadeTexto.color = Color.red;
			velocidadeTexto.text = "Velocidade: "+ this.speed.ToString();
			velocidadeSom.Play();
			if (this.speed <= 0 ){
				SceneManager.LoadScene("Scenes/over");
			}
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			this.speed += (float) 0.25;
			velocidadeTexto.color = Color.green;
			velocidadeTexto.text = "Velocidade: "+ this.speed.ToString();

			pickupSound.Play();

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
	}

        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }

        void SetCountText()
	{
		countText.text = "Coconuts: " + count.ToString() +"/12";

		if (count >= 12) 
		{
			// Set the text value of your 'winText'
			winTextObject.SetActive(true);
			SceneManager.LoadScene("Scenes/won");
		}
	}
}
