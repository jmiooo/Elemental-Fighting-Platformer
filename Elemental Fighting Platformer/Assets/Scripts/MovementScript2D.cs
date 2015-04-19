using UnityEngine;
using System.Collections;

public class MovementScript2D : MonoBehaviour {
	public float WALK_FORCE = 100.0f;
	public float JUMP_FORCE = 500.0f;
	public float MAX_SPEED = 5.0f;
	
	public bool isFrozen;
	public bool isGrounded;
	public Constants.Elements element;
	public Constants.Dir direction;
	public bool isShooting;

	private float lastTimeFreezeTime;
	private float[] esDown;
	private float[] esLastTime;
	private float hDown, vDown;
	private float hLastTime, vLastTime;
	private float lastFiredTime;

	private GameObject playerSprite;
	private GameObject groundCheck;
	private Animator anim;
	private GameObject projectile;

	// Use this for initialization
	void Start () {
		//playerSprite = transform.FindChild("PlayerSprite").gameObject;
		//playerSprite = gameObject;
		//groundCheck = transform.FindChild("GroundCheck").gameObject;
		esDown = new float[5];
		esLastTime = new float[5];

		anim = GetComponent<Animator>();
		projectile = (GameObject) Resources.Load ("Prefabs/SplitShot");
	}

	void OnGUI() {
		if (isFrozen && Input.GetKeyDown (Constants.timeFreezeKey)) {
			Debug.Log (1);
			Time.timeScale = 1;
			isFrozen = false;
		}
	}
		
	void Update () {
		// Activates time freeze
		if (Input.GetKeyDown (Constants.timeFreezeKey) && Time.fixedTime - lastTimeFreezeTime > 0.2) {
			Debug.Log (1);
			Time.timeScale = 0;
			lastTimeFreezeTime = Time.fixedTime;
			isFrozen = true;
		}

		// Changes the element of the projectiles the player will be shooting
		float[] es = new float[] { 0, 0, 0, 0, 0 };

		if (Input.GetKey (Constants.element1Key)) es[0] = 1;
		if (Input.GetKey (Constants.element2Key)) es[1] = 1;
		if (Input.GetKey (Constants.element3Key)) es[2] = 1;
		if (Input.GetKey (Constants.element4Key)) es[3] = 1;
		if (Input.GetKey (Constants.element5Key)) es[4] = 1;

		for (int i = 0; i < es.Length; i++) {
			if (esDown[i] == 0 && es[i] == 1)
				esLastTime[i] = Time.fixedTime;

			esDown[i] = es[i];
		}

		int eIndex = -1;
		float eLastTime = 0;

		for (int i = 0; i < es.Length; i++) {
			if (esDown[i] == 1 && esLastTime[i] > eLastTime) {
				eIndex = i;
				eLastTime = esLastTime[i];
			}
		}

		if (eIndex != -1) {
			switch (eIndex) {
				case 0: element = Constants.Elements.E1; break;
				case 1: element = Constants.Elements.E2; break;
				case 2: element = Constants.Elements.E3; break;
				case 3: element = Constants.Elements.E4; break;
				case 4: element = Constants.Elements.E5; break;
				default: break;
			}
		}

		// Makes player sprite face the direction he will be shooting
		float h = 0;
		float v = 0;

		if (Input.GetKey (KeyCode.LeftArrow)) h -= 1;
		if (Input.GetKey (KeyCode.UpArrow)) v += 1;
		if (Input.GetKey (KeyCode.RightArrow)) h += 1;
		if (Input.GetKey (KeyCode.DownArrow)) v -= 1;

		if (hDown != h)
			hLastTime = Time.fixedTime;
		hDown = h;

		if (vDown != v)
			vLastTime = Time.fixedTime;
		vDown = v;

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

			GameObject projectileClone = (GameObject) GameObject.Instantiate (projectile);
			projectileClone.transform.position = transform.position + (Vector3) Constants.getVectorFromDirection(direction);
			projectileClone.rigidbody2D.velocity = 10 * Constants.getVectorFromDirection(direction);
			projectileClone.GetComponent<ProjectileScript>().element = element;

			/*Rigidbody2D projectileInstance = Instantiate(projectile, transform.position + (Vector3) Constants.getVectorFromDirection(direction), Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			ProjectileScript projscript = projectileInstance.GetComponent<ProjectileScript>();
			projscript.parentTag = "Player";
			projectileInstance.velocity = 10 * Constants.getVectorFromDirection(direction);*/

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
