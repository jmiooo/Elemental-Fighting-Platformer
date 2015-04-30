using UnityEngine;
using System.Collections;

public class UIElementCombo : MonoBehaviour {
	
	private static readonly int elementCount = 6;
	private static int comboElementCount = 6;
	public Sprite[] elementSprites = new Sprite[elementCount];
	
	private GameObject player;
	private MovementScript2D movementScript2D;
	private Combo combo;
	private GameObject[] comboElements;
	private GameObject comboBar;
	
	public void Start() {
		if (this.elementSprites.Length != UIElementCombo.elementCount) {
			throw new MissingComponentException("Invalid number of element sprites - should be " + UIElementCombo.elementCount + "; found " + this.elementSprites.Length);
		}
		
		player = GameObject.Find("Player");
		movementScript2D = player.GetComponent<MovementScript2D>();
		combo = player.GetComponent<Combo> ();

		comboElements = new GameObject[6];
		for (int i = 0; i < comboElements.Length; i++)
			comboElements[i] = GameObject.Find ("ComboElement" + (i + 1).ToString ());
		GameObject comboBar = GameObject.Find ("ComboBar");
	}
	
	public void ChangeToElement(GameObject comboElement, Constants.Elements element) {
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
			comboElement.GetComponent<UnityEngine.UI.Image>().sprite = this.elementSprites[spriteIndex];
		}
	}
	
	public void Update() {
		if (movementScript2D.isFrozen) {
			for (int i = 0; i < comboElements.Length; i++) {
				GameObject comboElement = comboElements[i];
				if (i < combo.CurrentCombo.Length) {
					comboElement.SetActive (true);
					int elementIndex = int.Parse(combo.CurrentCombo.Substring (i, 1)) - 1;
					ChangeToElement (comboElement, Constants.getElementByIndex(elementIndex));
				}
				else
					comboElement.SetActive (false);
			}
			//comboBar.SetActive (true);
		}
		else {
			for (int i = 0; i < comboElements.Length; i++) {
				GameObject comboElement = comboElements[i];
				if (i < combo.CurrentCombo.Length) {
					Debug.Log (i);
					comboElement.SetActive (false);
				}
				else
					comboElement.SetActive (false);
			}
			//comboBar.SetActive (false);
		}
	}
}