using UnityEngine;
using System.Collections;

public class EnemyCharge : MonoBehaviour {

	public float radius;
	public float speed;
	public float timer;
	public float chargespeed;
	public float chargeTime;
	
	private Vector2 direction;
	private Vector2 startpos;
	private Vector2 target;
	private Vector2 accel;
	private float lastTime;
	private bool charge;
	
	// Use this for initialization
	void Start () {
		startpos = gameObject.transform.position;
		lastTime = Time.fixedTime;
		charge = false;
		
		target = (Vector2)((Random.insideUnitCircle.normalized * radius)) + startpos;
		direction = target - (Vector2)gameObject.transform.position;
		accel = (direction - gameObject.rigidbody2D.velocity).normalized;
		gameObject.rigidbody2D.velocity += (accel * speed);
	}
	
	void FixedUpdate () {
		if (!charge) {
			if (Time.fixedTime - lastTime > timer) {
				target = (Vector2)((Random.insideUnitCircle.normalized * radius)) + startpos;
				lastTime = Time.fixedTime;
			}
			direction = target - (Vector2)gameObject.transform.position;
			accel = (direction - gameObject.rigidbody2D.velocity).normalized;
			gameObject.rigidbody2D.velocity += (accel * speed);
			RaycastHit2D[] downhit = Physics2D.RaycastAll(transform.position, -Vector2.up);
			if (downhit != null) {
				foreach (RaycastHit2D hit in downhit) {
					if(hit.collider.tag == "Player") {
						Debug.Log("HIT");
						charge = true;
						direction = -Vector2.up;
						lastTime = Time.fixedTime;
					}
				}
			}
			RaycastHit2D[] uphit = Physics2D.RaycastAll(transform.position, Vector2.up);
			if (uphit != null) {
				foreach (RaycastHit2D hit in uphit) {
					if(hit.collider.tag == "Player") {
						Debug.Log("HIT");
						charge = true;
						direction = Vector2.up;
						lastTime = Time.fixedTime;
					}
				}
			}
			RaycastHit2D[] righthit = Physics2D.RaycastAll(transform.position, Vector2.right);
			if (righthit != null) {
				foreach (RaycastHit2D hit in righthit) {
					if(hit.collider.tag == "Player") {
						Debug.Log("HIT");
						charge = true;
						direction = Vector2.right;
						lastTime = Time.fixedTime;
					}
				}
			}
			RaycastHit2D[] lefthit = Physics2D.RaycastAll(transform.position, -Vector2.right);
			if (lefthit != null) {
				foreach (RaycastHit2D hit in lefthit) {
					if(hit.collider.tag == "Player") {
						Debug.Log("HIT");
						charge = true;
						direction = -Vector2.right;
						lastTime = Time.fixedTime;
					}
				}
			}
		} else {
			gameObject.rigidbody2D.velocity = direction * chargespeed;
			if (Time.fixedTime - lastTime > chargeTime) {
				charge = false;
			}
		}

	}
}
