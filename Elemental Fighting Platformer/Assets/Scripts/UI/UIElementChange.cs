using UnityEngine;
using System.Collections;

public class UIElementChange : MonoBehaviour {
	
	private static readonly int elementCount = 6;
	public Sprite[] elementSprites = new Sprite[elementCount];

	private GameObject player;
	private MovementScript2D movementScript2D;

	public void Start() {
		if (this.elementSprites.Length != UIElementChange.elementCount) {
			throw new MissingComponentException("Invalid number of element sprites - should be " + UIElementChange.elementCount + "; found " + this.elementSprites.Length);
		}

		player = GameObject.Find("Player");
		movementScript2D = player.GetComponent<MovementScript2D>();
	}

	public void ChangeToElement(Constants.Elements element) {
		int spriteIndex;
		switch (element) {
			case Constants.Elements.E1:
				spriteIndex = 0; 
				break;
			case Constants.Elements.E2:
				spriteIndex = 1;
				break;
			case Constants.Elements.E3:
				spriteIndex = 2;
				break;
			case Constants.Elements.E4:
				spriteIndex = 3;
				break;
			case Constants.Elements.E5:
				spriteIndex = 4;
				break;
			case Constants.Elements.E6:
				spriteIndex = 5;
				break;
			default:
				spriteIndex = -1;
				break;
		}
		if (spriteIndex == -1) {
			Debug.LogError("Didn't recognize element: " + element.ToString());
		} else {
			gameObject.GetComponent<UnityEngine.UI.Image>().sprite = this.elementSprites[spriteIndex];
		}
	}

	public void Update() {
		ChangeToElement (movementScript2D.element);
	}
}