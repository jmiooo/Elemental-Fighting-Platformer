using UnityEngine;
using System.Collections;

public class EnemyAttack2 : MonoBehaviour {
	
	public Rigidbody2D projectile;
	public float cooldown;

	private float lastFiredTime;

	// Use this for initialization
	void Start () {
		lastFiredTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - lastFiredTime > cooldown) {
			Rigidbody2D projectileInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			ProjectileScript projscript = projectileInstance.GetComponent<ProjectileScript>();
			projscript.parentTag = "Enemy";
			Vector2 randomVector = Random.insideUnitCircle.normalized;
			projectileInstance.velocity = 10 * randomVector;
			lastFiredTime = Time.fixedTime;
		}
	}
}
