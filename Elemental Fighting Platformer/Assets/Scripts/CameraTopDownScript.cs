using UnityEngine;
using System.Collections;

public class CameraTopDownScript : MonoBehaviour {
	public float distance;
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		distance = -10.0f;
		player = GameObject.Find ("Player");
		transform.position = player.transform.position + new Vector3(0, 0, distance);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 desiredPosition = player.transform.position + new Vector3 (0, 0, distance);
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