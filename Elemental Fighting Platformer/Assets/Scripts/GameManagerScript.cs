using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	[System.Serializable]
	public class RoomInfo {
		public Vector2 initPosition;
		public bool isCleared;
	}

	public RoomInfo[] roomInfos;

	public void reset() {
		for (int i = 0; i < roomInfos.Length; i++)
			roomInfos[i].isCleared = false;
	}
}
