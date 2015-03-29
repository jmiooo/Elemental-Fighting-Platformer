using UnityEngine;
using System.Collections;

public class SpiralShot : MonoBehaviour
{

		public GameObject bulletPrefab;
		public float angleInc;
		public float delay;
		private float angle = 0;

		void Start ()
		{
				StartCoroutine (shootBullet ());
		}

		private IEnumerator shootBullet ()
		{
				while (true) {
			GameObject newBullet = GameObject.Instantiate(bulletPrefab);
			newBullet.GetComponent<MovementScript>();
						yield return new WaitForSeconds (delay);
				}
		}
}
