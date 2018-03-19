using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballdestroyer : MonoBehaviour 
{
	public AudioClip Explosion;
	AudioSource Audio;

	void Start ()
	{
		Audio = GetComponent <AudioSource> ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player") 
			if (other.gameObject.tag != "PickUp")
		{
			AudioSource.PlayClipAtPoint (Explosion, transform.position);
			Destroy (gameObject);
		}
	}
}	