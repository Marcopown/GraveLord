using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

	public void ClickExit() 
	{
		Application.Quit ();
		print ("quitted");
	}
}