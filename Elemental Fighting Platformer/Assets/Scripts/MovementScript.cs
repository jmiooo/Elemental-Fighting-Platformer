using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	public float WALK_FORCE = 10.0f;
	public float JUMP_FORCE = 200.0f;
	public float MAX_SPEED = 50.0f;

	private bool grounded;
	private int direction;

	private GameObject playerSprite;
	private GameObject groundCheck;
	private Animator anim;

	// Use this for initialization
	void Start () {
		playerSprite = transform.FindChild("PlayerSprite").gameObject;
		//groundCheck = transform.FindChild("GroundCheck").gameObject;
		anim = playerSprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	/*void Update () {
		float h, v;

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		if (Mathf.Abs(h) > 0.0f || Mathf.Abs(v) > 0.0f) {
			anim.SetInteger("Move", 1);
			if (Mathf.Abs(h) > 0.0f)
				anim.SetInteger("Direction", h > 0.0f ? 1 : -1);
		}
		else {
			anim.SetInteger("Move", 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			rigidbody.AddForce(new Vector3(0, Mathf.Sin(2 * Mathf.PI / 3) * 100.0f, Mathf.Cos(2 * Mathf.PI / 3) * 100.0f));
		}
	}

	void FixedUpdate() {
		float h, v;

		Vector3 moveForce;

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		moveForce = new Vector3(10.0f * h, Mathf.Sin(Mathf.PI / 6) * 10.0f * v, Mathf.Cos(Mathf.PI / 6) * 10.0f * v);

		rigidbody.AddForce(moveForce);
	}*/
	void Update () {
		//grounded = Physics.Spherecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); 

		float h, v;

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		if (Mathf.Abs(h) > 0.0f || Mathf.Abs(v) > 0.0f) {
			anim.SetInteger("Move", 1);
			if (Mathf.Abs(h) > 0.0f)
				anim.SetInteger("Direction", h > 0.0f ? 1 : -1);
		}
		else {
			anim.SetInteger("Move", 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			rigidbody.AddForce(new Vector3(0, 200.0f, 0));
		}
	}

	void FixedUpdate() {
		float h, v;

		Vector3 moveForce;

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		moveForce = new Vector3(10.0f * h, 0, 10.0f * v);

		rigidbody.AddForce(moveForce);
	}
}
