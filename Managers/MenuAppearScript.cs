using UnityEngine;
using System.Collections;

public class MenuAppearScript : MonoBehaviour {

	public GameObject menu;
	private bool Switch = false;

	void Update() {
		if (Input.GetKeyDown("escape")) 
		{
			if (Switch == false) {
				menu.SetActive (true);
				Time.timeScale = 0;
				Switch = true;
				print ("suca");
			} else 
			{
				Time.timeScale = 1;
				menu.SetActive (false);
				Switch = false;
			}
		}
	}
}