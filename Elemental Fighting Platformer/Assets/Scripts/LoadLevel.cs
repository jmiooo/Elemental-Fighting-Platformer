using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string destination;

	private int level;
	private GameManagerScript gameManager;
	private SpriteRenderer spriteRenderer;

	public void Start() {
		level = Application.loadedLevel;
		if (level != 5 && level != 6) {
			gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript>();
			spriteRenderer = GetComponentsInChildren<SpriteRenderer> ()[0];
			spriteRenderer.enabled = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player" && gameManager.roomInfos[level].isCleared) gotoScene (destination);
	}

	public void Update() {
		if (level != 5 && level != 6) {
			if (gameManager.roomInfos[level].isCleared) spriteRenderer.enabled = true;
		}
	}

	public void gotoScene(string name) {
		Debug.Log (name);
		if (name == "title-mark") {
			GameObject player = GameObject.Find ("Player");
			if (player) Destroy (player);
			GameObject gameManager = GameObject.Find ("GameManager");
			if (gameManager) Destroy (gameManager);
			Application.LoadLevel (name);
		}
		else {
			Application.LoadLevel (name);
		}
	}
}
