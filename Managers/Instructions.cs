using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

	public GameObject menu;

	void Update() {
		if (Input.anyKey) 
		{
				Time.timeScale = 1;
				menu.SetActive (false);
		}
	}
}
