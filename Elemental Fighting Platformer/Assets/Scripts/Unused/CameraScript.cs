using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public float distance;
	private GameObject player;

	// Use this for initialization
	void Start () {
		distance = 30.0f;
		player = GameObject.Find ("Player");
		transform.position = player.transform.position + new Vector3(0, distance * Mathf.Sin(Mathf.PI / 4), -distance * Mathf.Cos(Mathf.PI / 4));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 desiredPosition = player.transform.position + new Vector3 (0, distance * Mathf.Sin (Mathf.PI / 4), -distance * Mathf.Cos (Mathf.PI / 4));
		if (transform.position != desiredPosition)
		{
			rigidbody.velocity = 5.0f * (desiredPosition - transform.position);
		}
		else
		{
			rigidbody.velocity.Set(0.0f, 0.0f, 0.0f);
		}
	}
}
