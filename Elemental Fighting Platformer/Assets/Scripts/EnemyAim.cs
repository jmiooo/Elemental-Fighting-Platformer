using UnityEngine;
using System.Collections;

public class EnemyAim : MonoBehaviour {

	public Rigidbody2D projectile;
	public float cooldown;
	
	private float lastFiredTime;
	private GameObject player;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		lastFiredTime = Time.fixedTime;
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		direction = (player.transform.position - gameObject.transform.position).normalized;

		if (Time.fixedTime - lastFiredTime > cooldown) {
			Rigidbody2D projectileInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			ProjectileScript projscript = projectileInstance.GetComponent<ProjectileScript>();
			projscript.parentTag = "Enemy";
			projectileInstance.velocity = 10 * direction;
			lastFiredTime = Time.fixedTime;
		}
	}
}
