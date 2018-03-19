using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {

	public GameObject LifeGlobe;
	public GameObject LV;
	public int NoDrop = 60;
	public int HealthDrop = 95;
	int random;

	public void go ()
	{
		random = Random.Range (0, 100);
		if (random <= NoDrop) 
			print ("no drop " + random);
			else if (random <= HealthDrop)
					DropHealth ();
					else
						DropLV ();

	}

	void DropHealth()
	{
		print ("vita droppata "+ random);
		var LifeOBJ = (GameObject)Instantiate (LifeGlobe, transform.position + this.transform.forward, this.transform.rotation);
	}

	void DropLV()
	{
		var LVOBJ = (GameObject)Instantiate (LV, transform.position + this.transform.forward, this.transform.rotation);
		LVOBJ.transform.Rotate(Vector3.right * Time.deltaTime);

	}
}
