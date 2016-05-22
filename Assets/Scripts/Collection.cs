using UnityEngine;
using System.Collections;

public class Collection : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Collectible")) {
			Destroy(other.gameObject);
		}
	}
}
