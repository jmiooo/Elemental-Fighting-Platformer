using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	
	public Constants.Elements element;
	public int damage;
	public float timer;

	private bool collided;
	private MovementScript2D playerScript;
	private float lastTime;

	void Start() {
		collided = false;
		lastTime = Time.fixedTime;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Player") {
			collided = true;
			lastTime -= timer;
			playerScript = col.gameObject.GetComponent<MovementScript2D>();
		}
	}
	void OnCollisionExit2D (Collision2D col) {
		if(col.gameObject.tag == "Player") {
			collided = false;
		}
	}

	void FixedUpdate() {
		if (collided && Time.fixedTime - lastTime > timer) {
			playerScript.takeElementAndDamage(element, damage);
			lastTime = Time.fixedTime;
		}
	}
}
