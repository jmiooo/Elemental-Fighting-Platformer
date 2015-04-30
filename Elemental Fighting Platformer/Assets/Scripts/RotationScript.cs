using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {
	public float originalAngle;

	void Start () {
		float angle = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * 180 / Mathf.PI + originalAngle;
		transform.localEulerAngles = new Vector3(0, 0, angle);
	}
}
