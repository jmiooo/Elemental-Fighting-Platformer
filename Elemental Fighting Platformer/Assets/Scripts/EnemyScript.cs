using UnityEngine;
using System.Collections;

public class EnemyScript : Enemy {
	private EnemySpawner enemySpawner = null;
	private int enemySpawnerIndex;

	/* initializer */
	void Start ()
	{
		/* associate the enemy with the player */
		player = GameObject.Find("Player");
		/*
		speed = 0.5f;

		direction = -1;
		lastChange = Time.fixedTime;

		rigidbody2D.velocity = new Vector2(0, direction * speed);
		*/

		hitHistory = new int[] { 0, 0, 0, 0, 0, 0 };

		StartCoroutine (decayResistances ());
	}

	IEnumerator decayResistances() {
		while (true) {
			for (int i = 0; i < hitHistory.Length; i++)
				hitHistory[i] /= 2;

			yield return new WaitForSeconds(1);
		}
	}
	/*
	void Update ()
	{
		if (Time.fixedTime - lastChange > 5) {
			direction = -direction;
			lastChange = Time.fixedTime;
		}
	}

	void FixedUpdate() {
		rigidbody2D.velocity = new Vector2(0, direction * speed);
	}
	*/

	public void setEnemySpawnerAndIndex(EnemySpawner enemySpawner, int enemySpawnerIndex) {
		this.enemySpawner = enemySpawner;
		this.enemySpawnerIndex = enemySpawnerIndex;
	}
	
	public override void takeDamage(int damage)
	{
		hp = (hp > damage) ? hp - damage : 0;
		if (hp == 0) {
			Destroy(gameObject);

			if (enemySpawner) {
				enemySpawner.notifyDeath(enemySpawnerIndex);
			}
		}
	}

	public void takeElementAndDamage(Constants.Elements element, int damage) {
		updateResistances (element);
		int actualDamage = damage / (calculateResistance (element) + 1);
		Debug.Log (actualDamage);

		takeDamage (actualDamage);

	}
}
