using UnityEngine;
using System.Collections;

public class AutoDestroyAfterAnimation : MonoBehaviour {
	void Start () {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
