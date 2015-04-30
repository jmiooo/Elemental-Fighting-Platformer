using UnityEngine;
using System.Collections;

public class EnemyHover : MonoBehaviour {

	public float angularVelocity;
	public float radius;
	public float offset;
	private float lastHoverTime;

	private Transform parent;

	// Use this for initialization
	void Start () {
		lastHoverTime = Time.fixedTime;
		parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.fixedTime;
		/*gameObject.transform.position += (radius * new Vector3(Mathf.Cos (angularVelocity * currentTime + offset),
		                                                       Mathf.Sin (angularVelocity * currentTime + offset)) -
		                                  radius * new Vector3(Mathf.Cos (angularVelocity * lastHoverTime + offset),
		                     								   Mathf.Sin (angularVelocity * lastHoverTime + offset)));*/
		if (parent)
			gameObject.transform.position =
				parent.position + radius * new Vector3 (Mathf.Cos (angularVelocity * currentTime + offset), 
				                                        Mathf.Sin (angularVelocity * currentTime + offset));
		else
			gameObject.transform.position = radius * new Vector3 (Mathf.Cos (angularVelocity * currentTime + offset), 
				                                        		  Mathf.Sin (angularVelocity * currentTime + offset));
		lastHoverTime = currentTime;
	}
}
