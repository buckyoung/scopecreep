using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {
	// Events
	public delegate void CollectorCollectEvent(Collector eventObject, Collider2D collectible);
	public static event CollectorCollectEvent onCollect; // When implementing: if(this.gameObject.GetInstanceID() == eventObject.gameObject.GetInstanceID())

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Collectible") {
			if (onCollect != null) { onCollect(this, other); }
			Destroy(other.gameObject);
		}
	}
}
