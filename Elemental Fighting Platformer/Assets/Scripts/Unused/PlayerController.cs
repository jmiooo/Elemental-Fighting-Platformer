using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
  /* player properties */
  public float WALK_FORCE, JUMP_FORCE, MAX_SPEED;

  private bool grounded;
  private int direction;

  private GameObject playerSprite;
  public GameObject opp;
  private Animator anim;
  public uint hp;
  
  /* initializer */
  void Start()
  {
    playerSprite = transform.FindChild("PlayerSprite").gameObject;
    anim = playerSprite.GetComponent<Animator>();
  }
  
  IEnumerator Attack()
  {
    /* implement attack coroutine */
    yield return null;
  }
    
  /* updater is called once per frame */
  void Update()
  {
    float h, v;

    h = Input.GetAxis("Horizontal");
    v = Input.GetAxis("Vertical");

    if (Mathf.Abs(h) > 0.0f || Mathf.Abs(v) > 0.0f) {
      anim.SetInteger("Move", 1);
      if (Mathf.Abs(h) > 0.0f)
        anim.SetInteger("Direction", h > 0.0f ? 1 : -1);
    }
    else {
      anim.SetInteger("Move", 0);
    }
    if (Input.GetMouseButtonDown(0)) {
      float dist;

      dist = Vector3.Distance(transform.position,
                              opp.transform.position);

      if (dist < 10.0f) {
        opp.GetComponent<OpponentController>().Damage(10);
      }
    }
  }
  
  void FixedUpdate()
  {
    float h, v;
    Vector3 moveForce;

    h = Input.GetAxis("Horizontal");
    v = Input.GetAxis("Vertical");
    if (Input.GetKeyDown(KeyCode.Space))
      moveForce = new Vector3(0, JUMP_FORCE, 0);
    else
      moveForce = new Vector3(WALK_FORCE * h, 0, WALK_FORCE * v);

    rigidbody.AddForce(moveForce);
  }
  
  /* update after all other updates */
  void LateUpdate()
  {
    
  }
  
  /* collision detection */
  void OnCollisionEnter()
  {
    
  }
  
}
