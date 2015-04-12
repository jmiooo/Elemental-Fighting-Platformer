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
		int elementIndex = -1;

		switch (element) {
			case Constants.Elements.E1: elementIndex = 0; break;
			case Constants.Elements.E2: elementIndex = 1; break;
			case Constants.Elements.E3: elementIndex = 2; break;
			case Constants.Elements.E4: elementIndex = 3; break;
			case Constants.Elements.E5: elementIndex = 4; break;
			default: break;
		}

		hitHistory[elementIndex] += 1;
	}

	public virtual int calculateResistance(Constants.Elements element) {
		int elementIndex = -1;
		
		switch (element) {
			case Constants.Elements.E1: elementIndex = 0; break;
			case Constants.Elements.E2: elementIndex = 1; break;
			case Constants.Elements.E3: elementIndex = 2; break;
			case Constants.Elements.E4: elementIndex = 3; break;
			case Constants.Elements.E5: elementIndex = 4; break;
			default: break;
		}
		
		return hitHistory[elementIndex];
	}
}
