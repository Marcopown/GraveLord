using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	public int enemyAlive;
	public Text WaveNumberText;
	int WaveNumber;
	GameObject player;

    void Start ()
    {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		InvokeRepeating ("Spawn", spawnTime, spawnTime);			//Invoca ripetutamente la funzione ("Spawn", tempo prima di invocarla, tempo tra una ripetizione e l'altra)
    }


    void Spawn ()
    {		
		WaveNumber = int.Parse(WaveNumberText.text);
		if(playerHealth.currentHealth <= 0f)			//Se il player è morto finisce
            return;
        
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);			//spawnPointIndex ' il contatore dell'array spawnPoints, l'Index. Lo impostiamo ad un numero random tra 0 e la lunghezza dell'array

		if (enemyAlive < WaveNumber * 5) 
		{
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			enemyAlive++;
		}
    }

	public void ResetEnemy()
	{
		enemyAlive = 0;
	}
}
