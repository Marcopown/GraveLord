using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondaryMenu : MonoBehaviour
{
	bool clicked = false;
	public GameObject Background;
	public Button controllo;

	void Update()
	{	
		if (clicked)
		{
			controllo.interactable = false;
			CreditsPopup ();
		}
		if (Input.anyKey) 
		{
			if (Input.GetMouseButton (0)) 
				return;
			

			CreditsPopout ();
			controllo.interactable = true;
		}
	}

	public void go()
	{
		clicked = true;
	}

	void CreditsPopup()
	{
		Background.SetActive(true);
	}

	void CreditsPopout()
	{
		clicked = false;
		Background.SetActive(false);
	}

}