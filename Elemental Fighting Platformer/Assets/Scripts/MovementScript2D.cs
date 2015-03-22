using UnityEngine;
using System.Collections;

public class MovementScript2D : MonoBehaviour {
	public float WALK_FORCE = 10.0f;
	public float JUMP_FORCE = 200.0f;
	public float MAX_SPEED = 50.0f;
	
	public bool grounded;
	public Constants.Dir direction;
	public float hDown, vDown;
	public float hLastTime, vLastTime;

	private GameObject playerSprite;
	private GameObject groundCheck;
	private Animator anim;

	// Use this for initialization
	void Start () {
		//playerSprite = transform.FindChild("PlayerSprite").gameObject;
		playerSprite = gameObject;
		//groundCheck = transform.FindChild("GroundCheck").gameObject;
		anim = playerSprite.GetComponent<Animator>();
	}

	void Update () {
		// Makes player sprite face the direction he will be shooting
		float h = 0;
		float v = 0;

		if (Input.GetKey (KeyCode.LeftArrow)) h -= 1;
		if (Input.GetKey (KeyCode.UpArrow)) v += 1;
		if (Input.GetKey (KeyCode.RightArrow)) h += 1;
		if (Input.GetKey (KeyCode.DownArrow)) v -= 1;

		if (hDown != h) {
			hDown = h;
			hLastTime = Time.fixedTime;
		}

		if (vDown != v) {
			vDown = v;
			vLastTime = Time.fixedTime;
		}

		if (hDown != 0 && vDown != 0) {
			if (hLastTime >= vLastTime) {
				if (h < 0) direction = Constants.Dir.W;
				else direction = Constants.Dir.E;
			}
			else {
				if (v > 0) direction = Constants.Dir.N;
				else direction = Constants.Dir.S;
			}
		}
		else {
			if (h < 0) direction = Constants.Dir.W;
			else if (v > 0) direction = Constants.Dir.N;
			else if (h > 0) direction = Constants.Dir.E;
			else if (v < 0) direction = Constants.Dir.S;
		}

		switch (direction) {
			case Constants.Dir.W: anim.SetInteger("Direction", 0); break;
			case Constants.Dir.N: anim.SetInteger("Direction", 1); break;
			case Constants.Dir.E: anim.SetInteger("Direction", 2); break;
			case Constants.Dir.S: anim.SetInteger("Direction", 3); break;
		}

		// Makes player shoot projectile
		if (Mathf.Abs(hDown) > 0 || Mathf.Abs(vDown) > 0) {
			Debug.Log ("Blah");
		}

		// Makes player sprite either move or stand still
		if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 ||
		    Mathf.Abs(Input.GetAxis("Vertical")) > 0) {
			anim.SetInteger("Move", 1);
		}
		else {
			anim.SetInteger("Move", 0);
		}
	}
	
	void FixedUpdate() {
		// Updates the player's position
		float h, v;
		Vector2 moveForce;

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		moveForce = new Vector2(WALK_FORCE * h, WALK_FORCE * v);

		
		rigidbody2D.AddForce(moveForce);
	}
}
