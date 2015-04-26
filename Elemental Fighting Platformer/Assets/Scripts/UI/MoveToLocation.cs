using UnityEngine;
using System.Collections;

// Moves to <endLocation> after waiting <startMoveDelay> over <duration>.
public class MoveToLocation : MonoBehaviour
{

    public Transform endLocation;
    public float startMoveDelay = 0;
    public float duration = 1;
	private Vector2 startLocation;
    private bool moving;
    private bool finished;
    private float startMoveTime;
    private float endMoveTime;

    void Start ()
    {
        this.moving = false;
        this.startMoveTime = Time.time + this.startMoveDelay;
        this.endMoveTime = this.startMoveTime + duration;
		this.startLocation = gameObject.transform.position;
        this.finished = false;
    }

    void startMoving ()
    {
        this.moving = true;
    }

    void move ()
    {
		float percentDone = (Time.time - this.startMoveTime) / duration;
		float newX = Mathf.SmoothStep (this.startLocation.x, this.endLocation.position.x, percentDone);
		float newY = Mathf.SmoothStep (this.startLocation.y, this.endLocation.position.y, percentDone);
		gameObject.transform.position = new Vector2 (newX, newY);
    }

    void Update ()
    {
        if (this.moving) {
            this.move ();
            if (Time.time >= this.endMoveTime) {
                gameObject.transform.position = this.endLocation.position;
                this.moving = false;
                this.finished = true;
            }
        } else if (!(this.finished) && (Time.time >= this.startMoveTime)) {
			Debug.Log(gameObject.transform.position);
            this.moving = true;
        }
    }

}
