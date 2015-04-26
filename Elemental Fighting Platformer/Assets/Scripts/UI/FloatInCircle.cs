using UnityEngine;
using System.Collections;

public class FloatInCircle : MonoBehaviour {

	public float radius = 5;
	public float period = 3;
	private float startTime;
	private float lastTime;

	void Start () {
		this.startTime = Time.time;
		this.lastTime = this.startTime;
		gameObject.transform.Translate (new Vector3(radius, 0));
	}

	void Update () {
		Vector3 lastDelta = this.getDelta (this.lastTime);
		Vector3 thisDelta = this.getDelta (Time.time);
		this.lastTime = Time.time;
		Vector3 moveDelta = thisDelta - lastDelta;
		gameObject.transform.Translate (moveDelta);
	}

	Vector3 getDelta(float rawTime) {
		float time = (this.startTime - rawTime) % this.period;
		float x = this.radius * Mathf.Cos (2 * time);
		float y = this.radius * Mathf.Sin (2 * time);
		return new Vector3 (x, y);
	}
}
