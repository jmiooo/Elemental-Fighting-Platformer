using UnityEngine;
using System.Collections;

public class MoveCircular : MonoBehaviour
{
	public Vector2 center;
	private Vector2 pos = new Vector2();
	public float speed, radius, angle_init;
	private float angle, ang_speed;
	public bool is_clockwise;

	// Use this for initialization
	void Start ()
	{
		ang_speed = speed / radius;
		angle = angle_init * Mathf.PI / 180;
		if (is_clockwise)
			ang_speed *= -1;
		pos.x = radius * Mathf.Cos (angle) + center.x;
		pos.y = radius * Mathf.Sin (angle) + center.y;
		Debug.Log ("Starting position: " + pos);
		transform.position = pos;
	}

	// Update is called once per frame
	void Update ()
	{
		float d_angle = ang_speed * Time.deltaTime;
		pos.x = radius * Mathf.Cos (angle + d_angle) + center.x;
		pos.y = radius * Mathf.Sin (angle + d_angle) + center.y;
		transform.position = pos;
		angle += d_angle;
	}
}
