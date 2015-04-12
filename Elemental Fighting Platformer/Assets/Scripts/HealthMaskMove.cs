using UnityEngine;
using System.Collections;

public class HealthMaskMove : MonoBehaviour
{

	// index of the health bar in children of the mask
	private int BAR_CHILD_INDEX = 0;

	public void MatchMaskToPercentage (float healthPercent) {
		healthPercent = Mathf.Clamp (healthPercent, 0.0f, 1.0f);
		float maxX = gameObject.transform.parent.position.x;
		float minX = maxX - ((RectTransform)(gameObject.transform.parent)).rect.width;
		float x = ((maxX - minX) * healthPercent) + minX;
		float y = gameObject.transform.parent.position.y;
		this.MoveMask (new Vector3 (x, y, 0));
	}

	// Moves the mask without moving the bar underneath
	public void MoveMask (Vector3 toLocation) {
		Vector3 barStartLocation = this.GetBar ().position;
		gameObject.transform.position = toLocation;
		this.GetBar ().position = barStartLocation;
	}

	private Transform GetBar() {
		return gameObject.transform.GetChild (this.BAR_CHILD_INDEX);
	}

}
