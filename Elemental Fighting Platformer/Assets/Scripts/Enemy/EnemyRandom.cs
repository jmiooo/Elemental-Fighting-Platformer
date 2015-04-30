using UnityEngine;
using System.Collections;

public class EnemyRandom : MonoBehaviour {

	public float radius;
	public float speed;
	public float timer;

	private Vector2 direction;
	private Vector2 startpos;
	private Vector2 target;
	private Vector2 accel;
	private float lastTime;

	// Use this for initialization
	void Start () {
		startpos = gameObject.transform.position;
		lastTime = Time.fixedTime;

		target = (Vector2)((Random.insideUnitCircle.normalized * radius)) + startpos;
		direction = target - (Vector2)gameObject.transform.position;
		accel = (direction - gameObject.rigidbody2D.velocity).normalized;
		gameObject.rigidbody2D.velocity += (accel * speed);
	}
	
	void FixedUpdate () {
		if (Time.fixedTime - lastTime > timer) {
			target = (Vector2)((Random.insideUnitCircle.normalized * radius)) + startpos;
			lastTime = Time.fixedTime;
		}
		/*
		Vector2 nextStep = ((Vector2) gameObject.transform.position + gameObject.rigidbody2D.velocity);
		if (Vector2.Distance (nextStep, startpos) > radius) {
			direction *= -1;
			lastTime = Time.fixedTime;
		}
		*/
		direction = target - (Vector2)gameObject.transform.position;
		accel = (direction - gameObject.rigidbody2D.velocity).normalized;
		gameObject.rigidbody2D.velocity += (accel * speed);
	}
}
