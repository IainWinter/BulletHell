using UnityEngine;
using System.Collections;

public class PlayerController : Damageable {
    public float speed;
    public int dashFrameTotal;
    private int dashFrames;

    public GameManager gameManager;

    void Update() {
        if (gameManager.CanPlay()) {
            Vector3 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (dashFrames > 0) {
                Dash(movement);
            } else {
                if (Input.GetButtonDown("Dash")) {
                    dashFrames = dashFrameTotal;
                } else {
                    transform.position += movement * speed * Time.deltaTime;
                }
            }
        }
    }

    void FixedUpdate() {
        if (dashFrames > 0) {
            dashFrames--;
        }
    }

    void Dash(Vector3 movement) {
        transform.position += movement * speed * dashFrames * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            if (dashFrames > 0) {
                coll.GetComponent<Damageable>().Damage(5, dashFrames == dashFrameTotal - 1, 3f);
                AddPoints(625 * dashFrames + 625);
            } else {
                DamagePlayer(1);
            }
        }

        if (coll.gameObject.tag == "Bullet") {
            DamagePlayer(1);
            coll.GetComponent<Damageable>().Damage(1);

        }
    }

    void AddPoints(int points) {
        gameManager.AddPoints(points);
    }

    //Animate Red flash
    void DamagePlayer(int damage) {
        Damage(damage);
    }
}
