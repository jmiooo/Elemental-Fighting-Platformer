using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	public Constants.Elements element;

	public string parentTag;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (parentTag == "Enemy" && col.tag == "Player") {
			Destroy (gameObject);
		} else if (parentTag == "Player" && col.tag == "Enemy") {
			//col.gameObject.GetComponent<EnemyScript>().takeDamage(10);
			col.gameObject.GetComponent<EnemyScript> ().takeElementAndDamage (element, 10);
			Destroy (gameObject);
		} else if (col.tag == "Prop") {
			Destroy (gameObject);
		}
	}
}
