using UnityEngine;
using System.Collections;

public class ResourceHandler : MonoBehaviour {
	private int total = 0;
	private int maximum = 10;

	void OnTriggerEnter2D(Collider2D other) {
		if (total < maximum && other.gameObject.tag == "Collectible") {
			total++;
			Destroy(other.gameObject);
		}
	}

	/*
	 * User Functions
	 */
	public int getMaximum() {
		return maximum;
	}

	public int getTotal() {
		return total;
	}
}
