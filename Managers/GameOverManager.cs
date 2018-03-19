﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
	GameObject player;
	public PlayerHealth playerHealth;       // Reference to the player's health.

	Animator anim;                          // Reference to the animator component.

	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}


	void Update ()
	{
		// If the player has run out of health...
		if(playerHealth.currentHealth <= 0)
		{
			// ... tell the animator the game is over.
			anim.SetTrigger ("GameOver");

		}
	}
}