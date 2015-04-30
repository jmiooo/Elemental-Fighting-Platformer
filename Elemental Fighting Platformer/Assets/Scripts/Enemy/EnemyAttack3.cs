using UnityEngine;
using System.Collections;

public class EnemyAttack3 : MonoBehaviour {

	public Rigidbody2D projectile;
	public float angleVel;
	public float cooldown;
	public float startangle;
	
	private float lastFiredTime;
	private float angle;
	
	// Use this for initialization
	void Start () {
		angle = startangle * Mathf.PI/180;
		lastFiredTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - lastFiredTime > cooldown) {
			angle += angleVel * Mathf.PI/180;
			if (angle > (2 * Mathf.PI)) {
				angle -= (2 * Mathf.PI);
			}
			Vector2 projVector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
			Rigidbody2D projectileInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			ProjectileScript projscript = projectileInstance.GetComponent<ProjectileScript>();
			projscript.parentTag = "Enemy";
			projectileInstance.velocity = 10 * projVector.normalized;
			lastFiredTime = Time.fixedTime;
		}
	}
}
