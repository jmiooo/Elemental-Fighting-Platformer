using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == "Player" || col.tag == "Prop")
		{
			Destroy (gameObject);
		}
		else if (col.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyScript>().takeDamage(10);
			Destroy(gameObject);
		}
	}
}
