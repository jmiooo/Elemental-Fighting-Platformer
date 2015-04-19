using UnityEngine;
using System.Collections;

public class ExplodingShot : MonoBehaviour {
	
	public Rigidbody2D projectile;
	public int projectileCount;
	public float timer;

	private float startTime;
	private string parentTag;

	// Use this for initialization
	void Start () {
		startTime = Time.fixedTime;
		
		ProjectileScript thisScript = gameObject.GetComponent<ProjectileScript>();
		parentTag = thisScript.parentTag;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - startTime > timer) {
			float mag = gameObject.rigidbody2D.velocity.magnitude;
			//creates projectileCount projectiles moving in an outward circle with same velocity
			for (int i = 0; i < projectileCount; i++) {
				Vector2 dir = new Vector2(Mathf.Cos(i * Mathf.PI * 2/projectileCount), 
				                          Mathf.Sin(i * Mathf.PI * 2/projectileCount));
				Rigidbody2D newBullet = Instantiate(projectile, transform.position, 
				                                    Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				ProjectileScript newBulletScript = newBullet.GetComponent<ProjectileScript>();
				newBulletScript.parentTag = parentTag;
				newBullet.velocity = mag * dir.normalized;
			}
			//destroys this bullet since it has now exploded
			Destroy (gameObject);
		}
	}
}
