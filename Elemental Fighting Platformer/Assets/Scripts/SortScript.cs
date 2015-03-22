using UnityEngine;
using System.Collections;

public class SortScript : MonoBehaviour {

	// Calculates the sorting layer of a game object using the y-value of tis position
	// Really important to put this with the sprite renderer of any game object in the foreground
	public SpriteRenderer spriteRenderer;

	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void LateUpdate(){
		spriteRenderer.sortingOrder = (int) Camera.main.WorldToScreenPoint(spriteRenderer.bounds.min).y * -1;
	}
}
