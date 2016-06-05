using UnityEngine;
using System.Collections;
using ScopeCreep.System;

/*
 * This behavior will move `this` in an arc around the planet
 * left and right towards `targetObject`.
 * 
 * It will stop moving when it is within `minDegrees` of the target
 * 
 * It will also not move when it is farther than `maxDegrees` away
 * 
 * Thus, a call to move() does NOT guarentee `this` will move
 */

namespace ScopeCreep.Behavior {
	public class MoveArcTowardObject : MonoBehaviour, IMoveable {
		public float speed = 0.05f;
		public GameObject targetObject;
		public float minDegrees = 2.0f;
		public float maxDegrees = 70.0f;

		/*
		 * User Functions
		 */

		public void move() {
			Vector3 thisPos = this.transform.position;
			Vector3 lilGuyPos = targetObject.transform.position;
			float angle = Util.angleSigned(thisPos, lilGuyPos, Vector3.forward);
			float absAngle = Mathf.Abs(angle);

			// Determine if `this` should move
			if (absAngle < minDegrees || absAngle > maxDegrees) {
				return; // Dont move!
			}
				
			// Move
			transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				speed * Mathf.Sign(angle) // Move left or right depending on sign of angle
			);
		}
	}
}