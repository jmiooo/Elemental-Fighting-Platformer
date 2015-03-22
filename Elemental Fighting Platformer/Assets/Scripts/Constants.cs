using UnityEngine;
using System.Collections;

public static class Constants{
	
	public enum Dir { W, N, E, S };
	
	public static KeyCode element1Key = KeyCode.Alpha1;
	
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
}
