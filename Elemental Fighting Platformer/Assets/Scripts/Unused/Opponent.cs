using UnityEngine;
using System.Collections;

namespace Opponent {
  public class Controller : MonoBehaviour {
    public uint hp;
    public float speed;
    public GameObject player; /* main player object */
    
    /* initializer */
    void Start () {
      /* associate the enemy with the player */
      
    }
    
    /* updater is called once per frame */
    void Update () {
      
    }
    
    void OnCollisionEnter(/* object */) {
      /* implement collision detection */
    }
    
  }
}
