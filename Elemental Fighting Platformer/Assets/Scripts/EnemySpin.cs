using UnityEngine;
using System.Collections;

public class EnemySpin : MonoBehaviour {
	
	public float angularVelocity;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(new Vector3(0, 0, angularVelocity * Time.deltaTime));
	}
}
