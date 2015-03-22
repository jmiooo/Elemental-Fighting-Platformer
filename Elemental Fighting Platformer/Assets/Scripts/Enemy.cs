using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	public int hp;
	public float speed;
	public GameObject player; /* main player object */
	
	public int direction;
	public float lastChange;

	public abstract void takeDamage(int dmg);

	public virtual void attack() {
		Debug.Log ("Attacked");
	}
}
