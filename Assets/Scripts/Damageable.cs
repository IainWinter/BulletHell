using UnityEngine;

public class Damageable : MonoBehaviour {
    public int health;
    public ParticleSystem deathParticleSystem;
    public ParticleSystem critDeathParticleSystem;

    public void Damage(int amount) {
        Damage(amount, false, 0f);
    }

    public void Damage(int amount, bool crit, float radius) {
        health -= amount;
        if (health <= 0) {
            Kill(gameObject, crit, radius);
        }
    }

    private void Kill(GameObject go, bool crit, float radius) {
        if (crit) {
            Instantiate(critDeathParticleSystem, go.transform.position, Quaternion.Euler(Vector3.zero));
        } else {
            Instantiate(deathParticleSystem, go.transform.position, Quaternion.Euler(Vector3.zero));
        }

        if (radius > 0) {
            Vector2 pos = new Vector2(go.transform.position.x, go.transform.position.y);
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(pos, radius);
            foreach (Collider2D c in hitColliders) {
                if (c.gameObject.tag == "Bullet") {
                    c.GetComponent<Damageable>().Damage(1);
                }
            }
        }
        Destroy(go);
    }

    public void Kill() {
        Damage(health);
    }
}