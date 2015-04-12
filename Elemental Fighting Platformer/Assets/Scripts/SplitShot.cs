using UnityEngine;
using System.Collections;

public class SplitShot : MonoBehaviour {

	public int depth;
	public float timer;
	public Rigidbody2D projectile;

	private float startTime;
	private bool split;
	private string parentTag;
	// Use this for initialization
	void Start () {
		startTime = Time.fixedTime;
		split = false;

		ProjectileScript thisScript = gameObject.GetComponent<ProjectileScript>();
		parentTag = thisScript.parentTag;
	}
	
	// Update is called once per frame
	void Update () {
		if (depth > 0 && !split && Time.fixedTime - startTime > timer) {
			split = true;
			float mag = gameObject.rigidbody2D.velocity.magnitude;
			float angle = Mathf.Atan2(gameObject.rigidbody2D.velocity.y, gameObject.rigidbody2D.velocity.x);

			Vector2 leftVector = new Vector2(Mathf.Cos(angle - Mathf.PI/12), Mathf.Sin(angle - Mathf.PI/12));
			Rigidbody2D leftproj = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			ProjectileScript leftscript = leftproj.GetComponent<ProjectileScript>();
			leftscript.parentTag = parentTag;
			SplitShot leftsplit = leftproj.GetComponent<SplitShot>();
			leftsplit.depth = depth - 1;
			leftproj.velocity = mag * leftVector.normalized;
			
			Vector2 rightVector = new Vector2(Mathf.Cos(angle + Mathf.PI/12), Mathf.Sin(angle + Mathf.PI/12));
			Rigidbody2D rightproj = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			ProjectileScript rightscript = leftproj.GetComponent<ProjectileScript>();
			rightscript.parentTag = parentTag;
			SplitShot rightsplit = rightproj.GetComponent<SplitShot>();
			rightsplit.depth = depth - 1;
			rightproj.velocity = mag * rightVector.normalized;
			Destroy (gameObject);
		}
	}
}
