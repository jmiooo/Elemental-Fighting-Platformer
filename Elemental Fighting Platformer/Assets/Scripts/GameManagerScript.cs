using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {

	[System.Serializable]
	public class RoomInfo {
		public Vector2 initPosition;
		public bool isCleared;
	}

	public RoomInfo[] roomInfos;
	private EnemySpawner[] enemySpawners;

	public void Start () {
		Debug.Log (Application.loadedLevel);
		List<EnemySpawner> enemySpawners = new List<EnemySpawner>();
		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			if (go.name == "EnemySpawner") enemySpawners.Add (go.GetComponent<EnemySpawner>());
		}
		this.enemySpawners = enemySpawners.ToArray ();
	}

	public void OnLevelWasLoaded () {
		List<EnemySpawner> enemySpawners = new List<EnemySpawner>();
		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			if (go.name == "EnemySpawner") enemySpawners.Add (go.GetComponent<EnemySpawner>());
		}
		this.enemySpawners = enemySpawners.ToArray ();
	}

	public void reset() {
		for (int i = 0; i < roomInfos.Length; i++)
			roomInfos[i].isCleared = false;
	}

	public void Update() {
		bool allCompleted = true;
		for (int i = 0; i < enemySpawners.Length; i++) {
			allCompleted = allCompleted && enemySpawners[i].completed;
		}
		roomInfos[Application.loadedLevel].isCleared = allCompleted;
		Debug.Log (allCompleted);
	}
}
