using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth;
    public int currentHealth;
    public float sinkSpeed = 2.5f;	
//    public int scoreValue = 10;

	GameObject player;
	PlayerShooting playerShooting;
	EnemyDrop drop;
    Animator anim;
	int playerdamage;
    AudioSource enemyAudio;
//    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
	public int EnemiesForLvUp =10;
	GameObject LVupMenu;
	LevelUp levelUp;




    void Awake ()
    {
		LVupMenu = GameObject.FindGameObjectWithTag ("LevelUp");
		levelUp = LVupMenu.GetComponent <LevelUp> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		playerShooting = player.GetComponent <PlayerShooting> ();
		playerdamage = playerShooting.damagePerShot;

        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
 //       hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

		drop = GetComponent <EnemyDrop> ();


		startingHealth = Random.Range (4, 10)*10;
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

	//Il nemico viene danneggiato
	void OnTriggerEnter(Collider rigidbody)
	{
		if (rigidbody.gameObject.tag == "Fireball") 
			TakeDamage (playerdamage);	

	}

    void TakeDamage (int amount)
    {
        if(isDead)
            return;
        currentHealth -= amount;
            
 //       hitParticles.transform.position = hitPoint;
 //       hitParticles.Play();

        if(currentHealth <= 0)      
            Death ();
        
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");
		enemyAudio.Play ();

		player.GetComponent<PlayerHealth>().EnemyKilled= player.GetComponent<PlayerHealth>().EnemyKilled+1;
		player.GetComponent<PlayerHealth> ().EnemyKilledforLvUp = player.GetComponent<PlayerHealth> ().EnemyKilledforLvUp + 1;
		drop.go ();

	//	print ("lvup   " + player.GetComponent<PlayerHealth>().EnemyKilled % EnemiesForLvUp);
		if (player.GetComponent<PlayerHealth>().EnemyKilledforLvUp % EnemiesForLvUp == 0)
			levelUp.OpenLVUPMenu();

   //     enemyAudio.clip = deathClip;
   //     enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
		GetComponent <CapsuleCollider>().enabled = false;
		GetComponent <SphereCollider>().enabled = false;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}