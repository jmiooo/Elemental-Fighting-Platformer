using UnityEngine;
using System.Collections;

public class EnemyHover : MonoBehaviour {

	public float angularVelocity;
	public float radius;
	private float lastHoverTime;

	// Use this for initialization
	void Start () {
		lastHoverTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.fixedTime;
		gameObject.transform.position += (radius * new Vector3(Mathf.Cos (currentTime), Mathf.Sin (currentTime)) -
		                                  radius * new Vector3(Mathf.Cos (lastHoverTime), Mathf.Sin (lastHoverTime)));
		lastHoverTime = currentTime;
	}
}
