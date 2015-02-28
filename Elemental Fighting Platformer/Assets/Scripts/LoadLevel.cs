using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	public void gotoScene(string name) {
		Application.LoadLevel (name);
	}
}
