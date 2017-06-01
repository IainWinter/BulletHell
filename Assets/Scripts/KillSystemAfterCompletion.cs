using UnityEngine;
using System.Collections;

public class KillSystemAfterCompletion : MonoBehaviour {
	void LateUpdate () {
		if (!GetComponent<ParticleSystem> ().IsAlive()) {
			Destroy (gameObject);
		}
	}
}
