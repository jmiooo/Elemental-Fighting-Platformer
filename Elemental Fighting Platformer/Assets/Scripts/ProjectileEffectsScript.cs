using UnityEngine;
using System.Collections;

public class ProjectileEffectsScript : MonoBehaviour {
	public bool toRotate;
	public float angularVelocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (toRotate) {
			transform.Rotate(Vector3.forward, Time.deltaTime * angularVelocity);
		}
	}
}
