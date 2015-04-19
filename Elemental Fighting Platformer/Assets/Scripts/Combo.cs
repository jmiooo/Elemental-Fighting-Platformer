using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class Combo : MonoBehaviour {
	private StringBuilder combo;
	public string CurrentCombo {
		get {
			return combo.ToString ();
		}
	}
	private int combo_count;
	public string[] combo_list;

	// Use this for initialization
	void Start () {
		combo = new StringBuilder ();
		combo_count = combo_list.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1))
			combo.Append ("1");
		else if (Input.GetKeyDown (KeyCode.Alpha2))
			combo.Append ("2");
		else if (Input.GetKeyDown (KeyCode.Alpha3))
			combo.Append ("3");
		else if (Input.GetKeyDown (KeyCode.Alpha4))
			combo.Append ("4");
		else if (Input.GetKeyDown (KeyCode.Alpha5))
			combo.Append ("5");
		else if (Input.GetKeyDown (KeyCode.Alpha6))
			combo.Append ("6");
	}

	public string GetCombo(){
		string combo_final = combo.ToString ();
		for (int i = 0; i < combo_count; i++) {
			if (string.Equals (combo_final, combo_list [i])) {
				Debug.Log ("valid combo");
				return combo_final;
			}
		}
		return "";
	}

	public void ClearCombo() {
		combo.Length = 0;
	}
}
