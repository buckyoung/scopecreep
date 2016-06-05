using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

/* 
 * This script is responsible for IMoveable
 */

namespace ScopeCreep.Enemy {

	[RequireComponent (typeof (IMoveable))]

	public class IMoveableHandler : MonoBehaviour {
		private Behavior.IMoveable moveableBehavior;

		void Start() {
			moveableBehavior = GetComponent<Behavior.IMoveable>();
		}

		void Update() {
			moveableBehavior.move();	
		}
	}
}