using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour 
{
	public int damagePerShot;				//Danni
	public float timeBetweenFireballs = 5.0f; 	//Tempo di "ricarica"
	public float FireballSpeed = 30; 			//Velocità dal proiettile
	public GameObject fireball;

	float timer;
	GameObject player;
	Vector3 StaffPos = new Vector3 (-2.0f,5.0f,0);

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		if (Time.timeScale == 1) {
			
			timer += Time.deltaTime;

			if (Input.GetButton ("Fire1") && timer >= timeBetweenFireballs) {
				Fire ();
			}
		}
	}

	void Fire()
	{
		//resetto il timer per il delay degli spari
		timer = 0f;

		//Istanzio il proiettile
		var projectile = (GameObject)Instantiate (fireball, transform.position + player.transform.forward + StaffPos, player.transform.rotation);

		// Aggiungo velocità
		projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * FireballSpeed;

		// Distruggere il proiettile dopo 3 sec
		Destroy(projectile, 3.0f);
		}
}