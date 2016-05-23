using UnityEngine;
using System.Collections;

public class Collection : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Collectible") {
			Destroy(other.gameObject);
		}
	}
}
