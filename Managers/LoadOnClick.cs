using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOnClick : MonoBehaviour
{
	public void LoadScene (int level)
	{
		SceneManager.LoadScene (level);
		Time.timeScale = 0;
	}
}