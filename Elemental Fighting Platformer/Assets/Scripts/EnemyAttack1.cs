using UnityEngine;
using System.Collections;

public class EnemyAttack1 : MonoBehaviour
{

    void Start ()
    {
        StartCoroutine (updateLoop ());
    }

    public IEnumerator updateLoop ()
    {
        GameObject bullet = (GameObject)Resources.Load ("Prefabs/Projectile");
        while (true) {
            bullet.transform.position = transform.position + Vector3.right;

            GameObject.Instantiate(bullet);
            bullet.rigidbody2D.MovePosition(10 * Vector3.right);

            Vector2 nextPosition = new Vector2(Random.Range(-1,1), Random.Range(-1,1));
            rigidbody2D.MovePosition (nextPosition);
            yield return new WaitForSeconds(1);
        }
    }
}
