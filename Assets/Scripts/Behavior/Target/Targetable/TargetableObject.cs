using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Collider2D))] // Required for collision with ITarget

	public class TargetableObject : MonoBehaviour, ITargetable {
		/*
		 * User Functions
		 */

		public GameObject getGameObject() {
			if (this == null) { return null; }

			return this.gameObject;
		}
	}
}
