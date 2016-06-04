using UnityEngine;
using System.Collections;

namespace ScopeCreep.Planet {
	public class Core : MonoBehaviour {
		void OnTriggerEnter2D(Collider2D col) {
			Destroy(col.gameObject);
		}
	}
}