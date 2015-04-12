using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    
    
    public float zenoCoefficient;

    public float scale;

    public Vector2[] positions;
    public int[] positionIndices;
    public float[] delays;
    public int[] delayIndices;
    
    private Rigidbody2D rb;
    private Vector2 startPosition;
    private Vector2 targetPosition;

    void Start() {
        StartCoroutine(move());
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
    }
    
    void FixedUpdate() {
        Vector2 nextPosition = Vector2.Lerp(rb.position, targetPosition * scale + startPosition, zenoCoefficient);

        rb.MovePosition(nextPosition);
    }

    private IEnumerator move() {
        int i = 0;
        while (true) {
            targetPosition = positions[positionIndices[i % positionIndices.Length] % positions.Length];
            yield return new WaitForSeconds(delays[delayIndices[i++ % delayIndices.Length] % delays.Length]);
        }
    }
}
