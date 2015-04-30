using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string destination;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") gotoScene (destination);
	}

	public void gotoScene(string name) {
		Application.LoadLevel (name);
	}
}
