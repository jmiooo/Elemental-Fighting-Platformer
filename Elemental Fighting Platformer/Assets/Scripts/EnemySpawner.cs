using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyInit {
	public GameObject enemy;
	public Vector2 position;
	public float timer;

	private float lastTime;
	private bool spawned = false;

	public void setTime(float time) {
		lastTime = time;
	}

	public float getTime() {
		return lastTime;
	}

	public void setSpawned (bool spawn) {
		spawned = spawn;
	}

	public bool getSpawned () {
		return spawned;
	}

	public bool checkTime () {
		if (Time.fixedTime - lastTime > timer) {
			lastTime = Time.fixedTime;
			return true;
		} else {
			return false;
		}
	}

}

public class EnemySpawner : MonoBehaviour {

	//public GameObject[] enemies = new GameObject[enemyCount];
	public EnemyInit[] enemies;

	void Start() {
		for (int i = 0; i < enemies.Length; i++) {
			enemies [i].setTime (Time.fixedTime);
			enemies [i].setSpawned (false);
		}
	}

	void Update () {
		for (int i = 0; i < enemies.Length; i++) {
			if (enemies[i].enemy != null && !enemies[i].getSpawned() &&
			    Time.fixedTime - enemies[i].getTime() > enemies[i].timer) {
				Instantiate(enemies[i].enemy, enemies[i].position, 
				            Quaternion.Euler(new Vector3(0,0,0)));
				enemies[i].setSpawned(true);
			}
		}
	}
}
