using UnityEngine;
using System.Collections;

public class MovementScript2D : MonoBehaviour {
	public float SLOW_TIME_SCALE = 0.05f;
	public int MAX_HP = 100;
	public float WALK_FORCE = 100.0f;
	public float JUMP_FORCE = 500.0f;
	public float MAX_SPEED = 5.0f;
	public float TRANSITION_TIME = 0.02f;
	
	public int hp;
	private float originalMass;
	private float originalAnimatorSpeed;
	private float currentMaxSpeed;
	private bool _isFrozen;
	public bool isFrozen {
		get { return _isFrozen; }
		set {
			_isFrozen = value;

			if (_isFrozen) {
				Time.timeScale = SLOW_TIME_SCALE;
				Time.fixedDeltaTime = SLOW_TIME_SCALE * 0.02f;

				/*rigidbody2D.mass *= SLOW_TIME_SCALE;
				rigidbody2D.drag /= SLOW_TIME_SCALE;
				rigidbody2D.velocity /= SLOW_TIME_SCALE;
				rigidbody2D.angularVelocity /= SLOW_TIME_SCALE;

				anim.speed /= SLOW_TIME_SCALE;*/

				StartCoroutine (changeFreezeParameters());
			}
			else {
				Time.timeScale = 1f;
				Time.fixedDeltaTime = 0.02f;
				
				currentMaxSpeed = MAX_SPEED;
				
				rigidbody2D.mass = originalMass;
				rigidbody2D.drag *= SLOW_TIME_SCALE;
				rigidbody2D.velocity *= SLOW_TIME_SCALE;
				rigidbody2D.angularVelocity *= SLOW_TIME_SCALE;
				
				anim.speed = originalAnimatorSpeed;
			}
		}
	}
	public bool isGrounded;
	public Constants.Elements element;
	public Constants.Dir direction;
	public bool isShooting;
	public GameObject[] projectiles;

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
	private Combo combo;

	IEnumerator changeFreezeParameters() {
		yield return new WaitForSeconds(TRANSITION_TIME * SLOW_TIME_SCALE);
		if (_isFrozen) {
			currentMaxSpeed /= SLOW_TIME_SCALE;
			
			rigidbody2D.mass *= SLOW_TIME_SCALE;
			rigidbody2D.drag /= SLOW_TIME_SCALE;
			rigidbody2D.velocity /= SLOW_TIME_SCALE;
			rigidbody2D.angularVelocity /= SLOW_TIME_SCALE;
			
			anim.speed /= SLOW_TIME_SCALE;
		}
	}

	// Use this for initialization
	void Start () {
		//playerSprite = transform.FindChild("PlayerSprite").gameObject;
		//playerSprite = gameObject;
		//groundCheck = transform.FindChild("GroundCheck").gameObject;
		hp = MAX_HP;

		esDown = new float[6];
		esLastTime = new float[6];

		anim = GetComponent<Animator>();
		projectile = (GameObject) Resources.Load ("Prefabs/ProjectileE1");
		combo = GetComponent<Combo> ();

		originalMass = rigidbody2D.mass;
		originalAnimatorSpeed = anim.speed;
		currentMaxSpeed = MAX_SPEED;
	}

	void Update () {
		//rigidbody2D.velocity = new Vector3 (0, 0, 0);
		// Activates time freeze
		if (Input.GetKeyDown (Constants.timeFreezeKey)) {
			if (!isFrozen && Time.fixedTime - lastTimeFreezeTime > 0.2) {
				isFrozen = true;
				lastTimeFreezeTime = Time.fixedTime;

				combo.ClearCombo();
			}
			else if (isFrozen && Time.fixedTime - lastTimeFreezeTime > TRANSITION_TIME * SLOW_TIME_SCALE) {
				isFrozen = false;
				lastTimeFreezeTime = Time.fixedTime;

				string combo_current;
				if ((combo_current = combo.GetCombo()) != "")
					Debug.Log ("found combo");
			}
		}

		// Changes the element of the projectiles the player will be shooting
		float[] es = new float[] { 0, 0, 0, 0, 0, 0 };

		if (Input.GetKey (Constants.element1Key)) es[0] = 1;
		if (Input.GetKey (Constants.element2Key)) es[1] = 1;
		if (Input.GetKey (Constants.element3Key)) es[2] = 1;
		if (Input.GetKey (Constants.element4Key)) es[3] = 1;
		if (Input.GetKey (Constants.element5Key)) es[4] = 1;
		if (Input.GetKey (Constants.element6Key)) es[5] = 1;

		for (int i = 0; i < es.Length; i++) {
			if (esDown[i] == 0 && es[i] == 1)
				esLastTime[i] = Time.unscaledTime;

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
				case 5: element = Constants.Elements.E6; break;
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
			hLastTime = Time.unscaledTime;
		hDown = h;

		if (vDown != v)
			vLastTime = Time.unscaledTime;
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
		if ((Mathf.Abs(hDown) > 0 || Mathf.Abs(vDown) > 0) && (Time.fixedTime - lastFiredTime > 0.2) && !isFrozen) {
			isShooting = true;
			//anim.SetTrigger ("Throw");

			GameObject projectile = projectiles[Constants.getElementIndex(element) % 3];
			GameObject projectileClone = (GameObject) GameObject.Instantiate (projectile);
			projectileClone.transform.position = transform.position + (Vector3) Constants.getVectorFromDirection(direction);
			projectileClone.rigidbody2D.velocity = 10 * Constants.getVectorFromDirection(direction);
			projectileClone.GetComponent<ProjectileScript>().element = element;
			projectileClone.GetComponent<ProjectileScript>().parentTag = "Player";
			lastFiredTime = Time.fixedTime;
		}
		else {
			isShooting = false;
		}

		// Makes player sprite either move or stand still
		if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 ||
		    Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0) {
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

		h = Input.GetAxisRaw("Horizontal");
		v = Input.GetAxisRaw("Vertical");

		moveForce = new Vector2(WALK_FORCE * h, WALK_FORCE * v);

		rigidbody2D.AddForce(moveForce, ForceMode2D.Impulse);

		if (rigidbody2D.velocity.magnitude > currentMaxSpeed) {
			rigidbody2D.velocity = currentMaxSpeed * rigidbody2D.velocity.normalized;
		}

		/*if (!isFrozen) {
			if (rigidbody2D.velocity.magnitude > MAX_SPEED) {
				rigidbody2D.velocity = MAX_SPEED * rigidbody2D.velocity.normalized;
			}
		}
		else {
			if (rigidbody2D.velocity.magnitude > MAX_SPEED / SLOW_TIME_SCALE) {
				rigidbody2D.velocity = MAX_SPEED / SLOW_TIME_SCALE * rigidbody2D.velocity.normalized;
			}
		}*/
		/*Debug.Log (isFrozen);
		Debug.Log (Time.unscaledTime);
		Debug.Log (rigidbody2D.transform.position.x);*/
	}

	/*void WaitForFixedUpdate() {
		Debug.Log ();
	}*/

	public void takeDamage(int damage) {
		hp = (hp > damage) ? (hp - damage) : 0;
	}

	public void takeElementAndDamage(Constants.Elements element, int damage) {
		takeDamage (damage);
	}
}