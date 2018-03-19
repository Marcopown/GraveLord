using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination (player.position);

			switch (enemyHealth.startingHealth) 
			{
			case 40:
				nav.speed = 10;
				break;
			case 50:
				nav.speed = 9;
				break;
			case 60:
				nav.speed = 8;
				break;
			case 70:
				nav.speed = 7;
				break;
			case 80:
				nav.speed = 6;
				break;
			case 90:
				nav.speed = 5;
				break;
			default:
				nav.speed = 4;
				break;
			} 
        }
        else
		{
            nav.enabled = false;
        }
    }
}
