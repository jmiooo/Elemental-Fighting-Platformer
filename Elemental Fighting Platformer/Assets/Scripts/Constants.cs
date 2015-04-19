using UnityEngine;
using System.Collections;

public static class Constants{
	
	public enum Dir { W, N, E, S };

	public static Vector2 getVectorFromDirection(Dir direction)
	{
		switch (direction)
		{
			case Dir.N: return new Vector2(0.0f, 1.0f);
			case Dir.E: return new Vector2(1.0f, 0.0f);
			case Dir.S: return new Vector2(0.0f, -1.0f);
			case Dir.W: return new Vector2(-1.0f, 0.0f);
			default: return new Vector2(0.0f, 0.0f);
		}
	}

	public enum Elements { E1, E2, E3, E4, E5, E6 };

	public static int getElementIndex(Constants.Elements element) {
		switch (element) {
			case Constants.Elements.E1: return 0;
			case Constants.Elements.E2: return 1;
			case Constants.Elements.E3: return 2;
			case Constants.Elements.E4: return 3;
			case Constants.Elements.E5: return 4;
			case Constants.Elements.E6: return 5;
			default: return -1;
		}
	}

	public static KeyCode timeFreezeKey = KeyCode.Space;

	public static KeyCode element1Key = KeyCode.Alpha1;
	public static KeyCode element2Key = KeyCode.Alpha2;
	public static KeyCode element3Key = KeyCode.Alpha3;
	public static KeyCode element4Key = KeyCode.Alpha4;
	public static KeyCode element5Key = KeyCode.Alpha5;
	public static KeyCode element6Key = KeyCode.Alpha6;
}
