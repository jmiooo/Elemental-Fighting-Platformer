using UnityEngine;
using System.Collections;

public class MaskRotate : MonoBehaviour {
	
	
	// index of the underlying image in children of the mask
	public GameObject childImage;
	
	public void MatchMaskToPercentage (float rotatePercent) {
		rotatePercent = Mathf.Clamp (rotatePercent, 0.0f, 1.0f);
		float maxRotate = 0.0f;
		float minRotate = 90.0f;
		float rotate = ((maxRotate - minRotate) * rotatePercent) + minRotate;
		this.RotateMaskTo (rotate);
	}
	
	// Moves the mask without rotating the image underneath
	public void RotateMaskTo (float newZ) {
		Vector3 imageStartAngles = childImage.transform.localEulerAngles;
		Vector3 oldAngles = gameObject.transform.eulerAngles;
		float diffInZ = newZ - oldAngles.z;
		gameObject.transform.eulerAngles = new Vector3 (oldAngles.x, oldAngles.y, oldAngles.z + diffInZ);
		childImage.transform.localEulerAngles = new Vector3 (imageStartAngles.x, imageStartAngles.y, imageStartAngles.z - diffInZ);
	}
}
