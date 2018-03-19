using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHealth : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;
	public int Power;
	public float DespawnTime = 5f;

	// Use this for initialization
	void Start () {
		Power = Random.Range (1, 10);
		transform.localScale += new Vector3 (Power*0.2f, Power*0.2f, Power*0.2f);
		transform.position += new Vector3 (0, 1f, 0);

		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		
	}

	void Update (){
		Destroy(gameObject, DespawnTime);
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
//		print ("curato di" + Power + "con power uguale a " + Power);
			playerHealth.TakeHealth (Power);
			Destroy (gameObject);
		}
	}
}