using UnityEngine;
using System.Collections;

public class EnemyBoomerang : MonoBehaviour {

	public Vector2 center;
	private Vector2 pos = new Vector2();
	public float aspeed, speed, radius, angle_init;
	private float angle, ang_speed;
	public bool is_clockwise;
	
	private GameObject player;
	private Vector2 target;
	
	// Use this for initialization
	void Start ()
	{
		/* associate the enemy with the player */
		player = GameObject.Find("Player");
		//target = player.transform.position;
		ang_speed = aspeed / radius;
		angle = 0;
		if (is_clockwise)
			ang_speed *= -1;
		Debug.Log ("Starting position: " + pos);
		center = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		center = Vector2.MoveTowards (center, player.transform.position, speed);
		float d_angle = ang_speed * Time.deltaTime;
		pos.x = radius * Mathf.Cos (angle + d_angle) + center.x;
		pos.y = radius * Mathf.Sin (angle + d_angle) + center.y;
		transform.position = pos;
		angle += d_angle;
	}
}
