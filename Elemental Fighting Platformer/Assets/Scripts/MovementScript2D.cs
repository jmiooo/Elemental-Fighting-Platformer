using UnityEngine;
using System.Collections;

public class MovementScript2D : MonoBehaviour {
	public float WALK_FORCE = 100.0f;
	public float JUMP_FORCE = 500.0f;
	public float MAX_SPEED = 5.0f;
	
	public bool isGrounded;
	public Constants.Dir direction;
	public bool isShooting;
	public int element;
	public Rigidbody2D projectile;

	private float hDown, vDown;
	private float hLastTime, vLastTime;
	private float lastFiredTime;

	private GameObject playerSprite;
	private GameObject groundCheck;
	private Animator anim;

	// Use this for initialization
	void Start () {
		//playerSprite = transform.FindChild("PlayerSprite").gameObject;
		//playerSprite = gameObject;
		//groundCheck = transform.FindChild("GroundCheck").gameObject;
		anim = GetComponent<Animator>();
	}

	void Update () {
		// Changes the element of the projectiles the player will be shooting

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
			case Constants.Dir.W: anim.SetFloat("Horizontal", -1); anim.SetFloat("Vertical", 0); break;
			case Constants.Dir.N: anim.SetFloat("Horizontal", 0); anim.SetFloat("Vertical", 1); break;
			case Constants.Dir.E: anim.SetFloat("Horizontal", 1); anim.SetFloat("Vertical", 0); break;
			case Constants.Dir.S: anim.SetFloat("Horizontal", 0); anim.SetFloat("Vertical", -1); break;
		}

		// Makes player shoot projectile
		if ((Mathf.Abs(hDown) > 0 || Mathf.Abs(vDown) > 0) && (Time.fixedTime - lastFiredTime > 0.2)) {
			isShooting = true;
			Rigidbody2D projectileInstance = Instantiate(projectile, transform.position + (Vector3) Constants.getVectorFromDirection(direction), Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			projectileInstance.velocity = 10 * Constants.getVectorFromDirection(direction);
			lastFiredTime = Time.fixedTime;
		}
		else {
			isShooting = false;
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
		Vector2 moveForce = new Vector2(0, 0);

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		moveForce = new Vector2(WALK_FORCE * h, WALK_FORCE * v);

		rigidbody2D.AddForce(moveForce);

		if (rigidbody2D.velocity.magnitude > MAX_SPEED) {
			rigidbody2D.velocity = MAX_SPEED * rigidbody2D.velocity.normalized;
		}
	}
}
