using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

/* 
 * This script is responsible for IMoveable
 */

namespace ScopeCreep.Enemy {

	[RequireComponent (typeof (IMoveable))]

	public class IMoveableHandler : MonoBehaviour {
		public string moveToGameObjectName = "LilGuy";

		private Behavior.IMoveable moveableBehavior;

		void Start() {
			moveableBehavior = GetComponent<Behavior.IMoveable>();

			ITarget<GameObject> targetBehavior = GetComponent<Behavior.ITarget<GameObject>>();
			targetBehavior.setTarget(GameObject.Find(moveToGameObjectName));
		}

		void Update() {
			moveableBehavior.move();	
		}
	}
}