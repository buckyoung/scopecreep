using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Collectible") {
			Destroy(other.gameObject);
		}
	}
}
