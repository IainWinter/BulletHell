using UnityEngine;
using System.Collections;

public class MovingEnemy : Damageable {
    public Vector3 positionStart;
    public Vector3 positionEnd;
    public float speed;

    void Update() {
        transform.position = Vector3.Lerp(positionStart, positionEnd, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}