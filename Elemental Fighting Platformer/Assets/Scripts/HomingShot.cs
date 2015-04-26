using UnityEngine;
using System.Collections;

public class HomingShot : MonoBehaviour {
	
	public float timer;
	public float slowDownTimer;
	public float rotationSpeed;

	private float startTime;
	private float lastSlowDownTime;
	public float initVelMag;
	private Vector2 target;
	private Transform targetTrans;
	private string parentTag;
	public bool reached;
	public bool targetSet;
	// Use this for initialization
	void Start () {
		startTime = Time.fixedTime;
		reached = false;
		targetSet = false;

		ProjectileScript thisScript = gameObject.GetComponent<ProjectileScript>();
		parentTag = thisScript.parentTag;
		rotationSpeed = 100.0f;
		initVelMag = gameObject.rigidbody2D.velocity.magnitude;
		if (parentTag == "Enemy") {
			targetTrans = findTransformWithTag("Player");
		} else if (parentTag == "Player") {
			targetTrans = findTransformWithTag("Enemy");
		} else {
			targetTrans = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - startTime > timer) {
			//sets a target if it has not already been set
			if (!targetSet) {
				if (targetTrans != null) {
					target = targetTrans.position;
				}
				targetSet = true;
			}
			//homes the bullet in on the target
			if (!reached) {
				if (targetTrans != null) {
					Vector3 targetdir = (Vector3)target - (Vector3)gameObject.transform.position;
					gameObject.rigidbody2D.velocity = initVelMag *
						(Vector2)Vector3.RotateTowards((Vector3)gameObject.rigidbody2D.velocity, 
						                               targetdir, rotationSpeed * Time.deltaTime, 0.0f).normalized;
					if (targetdir.magnitude < 0.5f) {
						reached = true;
					}
				} else {
					gameObject.rigidbody2D.velocity = initVelMag * gameObject.rigidbody2D.velocity.normalized;
				}
			}
		} else if (Time.fixedTime - lastSlowDownTime > slowDownTimer) {
			//slows the bullet down prior to locking on
			gameObject.rigidbody2D.velocity *= 0.9f;
			lastSlowDownTime = Time.fixedTime;
		}
	}

	//Modified Unity example
	Transform findTransformWithTag(string tag) {
		GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag (tag);
		if (taggedObjects.Length == 0) {
			return null;
		}
		GameObject closest = taggedObjects [0];
		float distance = Mathf.Infinity;
		Vector2 position = transform.position;
		foreach (GameObject go in taggedObjects) {
			Vector2 diff = (Vector2)go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if(curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest.transform;
	}
}
