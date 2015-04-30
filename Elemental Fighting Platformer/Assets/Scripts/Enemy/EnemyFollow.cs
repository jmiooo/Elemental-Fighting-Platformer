using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {


	private GameObject player;
	public float speed;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		/* associate the enemy with the player */
		player = GameObject.Find("Player");
		direction = (player.transform.position - gameObject.transform.position).normalized;

		gameObject.rigidbody2D.velocity = (speed * direction);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		direction = (player.transform.position - gameObject.transform.position).normalized;
		gameObject.rigidbody2D.velocity = (speed * direction);
	}
}
