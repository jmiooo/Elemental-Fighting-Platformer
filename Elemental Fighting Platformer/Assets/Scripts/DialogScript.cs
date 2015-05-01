using UnityEngine;
using System.Collections;

public class DialogScript : MonoBehaviour {

	private GUIStyle style;

	// Use this for initialization
	void Start () {
		style = new GUIStyle ();
		style.normal.textColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (Application.loadedLevel == 0) {
			GUI.Label(new Rect(125, 700, 225, 800),
		          	"You have three available combos:\n'123' for split shot\n'456' for big shot\n'321' for exploding shot\n", style);
		}
	}
}
