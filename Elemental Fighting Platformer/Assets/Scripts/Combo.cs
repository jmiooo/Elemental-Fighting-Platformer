using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

public class Combo : MonoBehaviour {
	public int MAXIMUM_COMBO_LENGTH = 6;

	private StringBuilder combo;
	public string CurrentCombo {
		get {
			return combo.ToString ();
		}
	}
	private int combo_count;
	public string[] combo_list;
	public GameObject[] combo_projectile_list;
	private List<GameObject> combo_projectile_history;

	// Use this for initialization
	void Start () {
		combo = new StringBuilder ();
		combo_count = combo_list.Length;
		combo_projectile_history = new List<GameObject> ();
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

		if (Input.GetKeyDown (KeyCode.Return) || combo.Length >= MAXIMUM_COMBO_LENGTH) {
			GameObject combo_projectile = getComboProjectile();
			if (combo_projectile) combo_projectile_history.Add (combo_projectile);
			clearCombo ();
		}
	}
	
	public int getComboIndex(){
		string combo_final = combo.ToString ();
		for (int i = 0; i < combo_count; i++) {
			if (string.Equals (combo_final, combo_list [i])) {
				return i;
			}
		}
		return -1;
	}

	public Boolean isCombo() {
		return getComboIndex () >= 0 ? true : false;
	}

	public GameObject getComboProjectile() {
		int index = getComboIndex ();
		return index >= 0 ? combo_projectile_list [index] : null;
	}

	public GameObject[] getComboProjectileHistory() {
		return combo_projectile_history.ToArray ();
	}

	public void clearCombo() {
		combo.Length = 0;
	}

	public void clearHistory() {
		combo_projectile_history = new List<GameObject> ();
	}
}
