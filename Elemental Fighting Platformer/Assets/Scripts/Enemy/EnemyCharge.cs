using UnityEngine;
using System.Collections;

public class EnemyCharge : MonoBehaviour {

	public float radius;
	public float speed;
	public float timer;
	public float chargespeed;
	public float chargeTime;

	public bool willRotate;
	public float originalAngle;
	public float angularVelocity;
	
	private Vector2 direction;
	private Vector2 startpos;
	private Vector2 target;
	private Vector2 accel;
	private float lastTime;
	private bool charge;
	private bool reached;
	
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
						reached = false;
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
						reached = false;
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
						reached = false;
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
						reached = false;
					}
				}
			}
		} else {
			gameObject.rigidbody2D.velocity = direction * chargespeed;
			if (Time.fixedTime - lastTime > chargeTime) {
				charge = false;
			}
		}

		if (willRotate) {
			if (charge && !reached) {
				float desiredAngle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI + originalAngle;
				float currentAngle = transform.eulerAngles.z;

				if (Mathf.Abs (desiredAngle - currentAngle) <= 180)
					transform.localEulerAngles = new Vector3(0, 0, currentAngle + (desiredAngle - currentAngle >= 0 ? 1 : -1) * angularVelocity);
				else
					transform.localEulerAngles = new Vector3(0, 0, currentAngle + (desiredAngle + 360 * (currentAngle >= desiredAngle ? 1 : -1) - currentAngle >= 0 ? 1 : -1) * angularVelocity);

				if (Mathf.Abs (desiredAngle - transform.eulerAngles.z) <= 10) {
					transform.localEulerAngles = new Vector3(0, 0, desiredAngle);
					reached = true;
				}
			}
		}

	}
}
