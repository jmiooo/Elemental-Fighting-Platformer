using UnityEngine;
using System.Collections;

public class EnemyRandom : MonoBehaviour {

	public float radius;
	public float speed;
	public float timer;

	private Vector2 direction;
	private Vector2 startpos;
	private float lastTime;

	// Use this for initialization
	void Start () {
		startpos = gameObject.transform.position;
		lastTime = Time.fixedTime;

		direction = Random.insideUnitCircle.normalized;
		gameObject.rigidbody2D.velocity = (speed * direction);
	}
	
	void FixedUpdate () {
		if (Time.fixedTime - lastTime > timer) {
			direction = Random.insideUnitCircle.normalized;
			gameObject.rigidbody2D.velocity = (speed * direction);
			lastTime = Time.fixedTime;
		}
		Vector2 nextStep = ((Vector2) gameObject.transform.position + gameObject.rigidbody2D.velocity);
		if (Vector2.Distance (nextStep, startpos) > radius) {
			direction = Random.insideUnitCircle.normalized;
			gameObject.rigidbody2D.velocity = (speed * direction);
		}
	}
}
