using UnityEngine;
using System.Collections;

public class MoveRectPat : MonoBehaviour
{
	public Rect bbox;
	public Vector2 startpos;
	public Vector2 init_dir;
	private Vector2 dir_vec;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		transform.position = startpos;
		dir_vec = init_dir;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var pos = transform.position;
		if (pos.x > bbox.xMax) {
			transform.Translate(bbox.xMax - pos.x, 0, 0);
			dir_vec.x = 0;
			dir_vec.y = 1;
		} else if (pos.x < bbox.xMin) {
			transform.Translate (bbox.xMin - pos.x, 0, 0);
			dir_vec.x = 0;
			dir_vec.y = -1;
		}
		else if (pos.y > bbox.yMax) {
			transform.Translate (0, bbox.yMax - pos.y, 0);
			dir_vec.x = -1;
			dir_vec.y = 0;
		} else if (pos.y < bbox.yMin) {
			transform.Translate (0, bbox.yMin - pos.y, 0);
			dir_vec.x = 1;
			dir_vec.y = 0;
		}
		transform.Translate (speed * dir_vec * Time.deltaTime);
	}
}
