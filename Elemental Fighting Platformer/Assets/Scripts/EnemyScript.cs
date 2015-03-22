﻿using UnityEngine;
using System.Collections;

public class EnemyScript : Enemy {

	/* initializer */
	void Start ()
	{
		/* associate the enemy with the player */
		player = GameObject.Find("Player");
		speed = 0.5f;
		hp = 100;

		direction = -1;
		lastChange = Time.fixedTime;
		rigidbody2D.velocity = new Vector2(0, direction * speed);
	}
	
	/* updater is called once per frame */
	void Update ()
	{
		if (Time.fixedTime - lastChange > 5) {
			direction = -direction;
			lastChange = Time.fixedTime;
		}
	}

	void FixedUpdate() {
		rigidbody2D.velocity = new Vector2(0, direction * speed);
	}
	
	public override void takeDamage(int dmg)
	{
		hp = (hp > dmg) ? hp - dmg : 0;
		if (hp == 0) {
			Destroy(gameObject);
		}
	}
}
