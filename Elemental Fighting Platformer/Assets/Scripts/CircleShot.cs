using UnityEngine;
using System.Collections;

public class CircleShot : MonoBehaviour {
	
	public Rigidbody2D projectile;
	public float number;
	public float cooldown;

	private float angle;
	private float lastFiredTime;
	
	// Use this for initialization
	void Start () {
		angle = (2 * Mathf.PI) / number;
		lastFiredTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - lastFiredTime > cooldown) {
			for (int i = 0; i < number; i++) {
				Vector2 projVector = new Vector2(Mathf.Cos(angle * i), Mathf.Sin(angle * i));
				Rigidbody2D projectileInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				ProjectileScript projscript = projectileInstance.GetComponent<ProjectileScript>();
				projscript.parentTag = "Enemy";
				projectileInstance.velocity = 10 * projVector.normalized;
			}

			lastFiredTime = Time.fixedTime;
		}
	}
}