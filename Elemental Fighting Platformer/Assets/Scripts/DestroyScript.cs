using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	public int loadTimes = 0;

	// Use this for initialization
	void Start () {
	
	}

	void OnLevelWasLoaded() {
		if (Application.loadedLevel == 5 || Application.loadedLevel == 6) {
			Destroy (this.gameObject);
		}
		if (Application.loadedLevel == 0) {
			loadTimes += 1;
		}
		if (loadTimes > 1) {
						Destroy (this.gameObject);
				}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
