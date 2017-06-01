using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class DefaultEnemy : Damageable {
	public int rotationSpeed;

	void FixedUpdate() {
		transform.Rotate (Vector3.forward * rotationSpeed);
	}
}