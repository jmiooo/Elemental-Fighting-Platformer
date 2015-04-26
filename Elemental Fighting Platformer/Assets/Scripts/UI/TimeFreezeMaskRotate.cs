using UnityEngine;
using System.Collections;

public class TimeFreezeMaskRotate : MonoBehaviour {

	public GameObject topRight;
	public GameObject bottomRight;
	public GameObject bottomLeft;
	public GameObject topLeft;

	public void MatchMaskToPercentage(float rotatePercent) {
		rotatePercent = Mathf.Clamp (rotatePercent, 0.0f, 1.0f);
		float topRightPercent = Mathf.Clamp (rotatePercent, 0.0f, 0.25f) * 4;
		float bottomRightPercent = Mathf.Clamp (rotatePercent - 0.25f, 0.0f, 0.25f) * 4;
		float bottomLeftPercent = Mathf.Clamp (rotatePercent - 0.50f, 0.0f, 0.25f) * 4;
		float topLeftPercent = Mathf.Clamp (rotatePercent - 0.75f, 0.0f, 0.25f) * 4;
		this.topRight.GetComponentInChildren<MaskRotate> ().MatchMaskToPercentage (topRightPercent);
		this.bottomRight.GetComponentInChildren<MaskRotate> ().MatchMaskToPercentage (bottomRightPercent);
		this.bottomLeft.GetComponentInChildren<MaskRotate> ().MatchMaskToPercentage (bottomLeftPercent);
		this.topLeft.GetComponentInChildren<MaskRotate> ().MatchMaskToPercentage (topLeftPercent);
	}
}
