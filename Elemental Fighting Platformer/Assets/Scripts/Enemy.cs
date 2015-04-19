using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	public int hp;
	public float speed;
	public GameObject player; /* main player object */
	
	public int direction;
	public float lastChange;
	public int[] hitHistory;

	public virtual void takeDamage(int damage) {
		hp = (hp > damage) ? (hp - damage) : 0;
	}

	public virtual void attack() {
		Debug.Log ("Default Attacked");
	}

	public virtual void updateResistances(Constants.Elements element) {
		int elementIndex = Constants.getElementIndex (element);
		hitHistory[elementIndex] += 1;
	}

	public virtual int calculateResistance(Constants.Elements element) {
		int elementIndex = Constants.getElementIndex (element);
		return hitHistory[elementIndex];
	}
}
