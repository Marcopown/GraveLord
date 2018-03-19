using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelUp : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;
	PlayerShooting playerShooting;
	PlayerMovement playerMovement;
	public GameObject LVUPmenu;
	public Button Health;
	public Button Attack;
	public Button AttackSpeed;
	public Button MovementSpeed;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		playerShooting = player.GetComponent <PlayerShooting> ();
		playerMovement = player.GetComponent <PlayerMovement> ();
	}

	public void HPUp()
	{
		playerHealth.MaxHealth += 10; 

		CloseLVUPMenu ();
	}

	public void ATKUp()
	{
		playerShooting.damagePerShot += 10;
		CloseLVUPMenu ();
	}

	public void ATKSPDUp()
	{
		playerShooting.timeBetweenFireballs = playerShooting.timeBetweenFireballs * 0.9f;
		CloseLVUPMenu ();
	}

	public void MOVSPDUp()
	{
		playerMovement.speed += 3;
		CloseLVUPMenu ();
	}

	void CloseLVUPMenu ()
	{
		Replenish ();
		Time.timeScale = 1;
		LVUPmenu.SetActive (false);
	}

	public void OpenLVUPMenu ()
	{
		Time.timeScale = 0;
		LVUPmenu.SetActive (true);	
	}

	void Replenish()
	{
		playerHealth.currentHealth = playerHealth.MaxHealth;
		playerHealth.healthSlider.value = playerHealth.currentHealth;
	}
}