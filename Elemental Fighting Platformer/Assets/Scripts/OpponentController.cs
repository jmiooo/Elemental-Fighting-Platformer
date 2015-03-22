using UnityEngine;
using System.Collections;

public class OpponentController : MonoBehaviour
{
  public uint hp;
  public float speed;
  public GameObject player; /* main player object */
  
  /* initializer */
  void Start ()
  {
    /* associate the enemy with the player */
    player = GameObject.Find("Player");
    hp = 100;
  }
  
  /* updater is called once per frame */
  void Update ()
  {
    
  }
  
  void OnCollisionEnter(/* object */)
  {
    /* implement collision detection */
  }
  
  public void Damage(uint dmg)
  {
    hp = (hp > dmg) ? hp - dmg : 0;
  }
}
