using UnityEngine;
using System.Collections;

public class EnemyAnimScript : MonoBehaviour {
	private Animator anim;
	private float normalXScale;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		normalXScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody2D.velocity.magnitude > 0) anim.SetInteger ("Move", 1);
		else anim.SetInteger ("Move", 0);

		if (rigidbody2D.velocity.x < 0) transform.localScale = new Vector3(normalXScale, transform.localScale.y, transform.localScale.z);
		else if (rigidbody2D.velocity.x > 0) transform.localScale = new Vector3(-normalXScale, transform.localScale.y, transform.localScale.z);
	}
}
