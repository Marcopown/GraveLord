using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLvUp : MonoBehaviour {
	
	GameObject player;
	PlayerHealth playerHealth;
	GameObject LVupMenu;
	LevelUp levelUp;
	public float DespawnTime = 10f;

	// Use this for initialization
	void Start () {
		LVupMenu = GameObject.FindGameObjectWithTag ("LevelUp");
		levelUp = LVupMenu.GetComponent <LevelUp> ();

		transform.position += new Vector3 (0, 1f, 0);

		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, DespawnTime);
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			print ("LVUP gratis!");
			levelUp.OpenLVUPMenu();
			Destroy (gameObject);
		}
	}
}
