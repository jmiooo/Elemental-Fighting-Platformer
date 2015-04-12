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

	public enum Elements { E1, E2, E3, E4, E5 };

	public static KeyCode timeFreezeKey = KeyCode.Space;

	public static KeyCode element1Key = KeyCode.Alpha1;
	public static KeyCode element2Key = KeyCode.Alpha2;
	public static KeyCode element3Key = KeyCode.Alpha3;
	public static KeyCode element4Key = KeyCode.Alpha4;
	public static KeyCode element5Key = KeyCode.Alpha5;
}
