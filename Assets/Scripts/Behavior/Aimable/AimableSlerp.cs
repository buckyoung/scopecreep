using UnityEngine;
using System.Collections;
using ScopeCreep.System;

namespace ScopeCreep.Behavior {
	public class AimableSlerp : MonoBehaviour, IAimable {
		public float rotationSpeed = 1.0f;

		public void aimAt(GameObject target) {
			transform.rotation = Quaternion.SlerpUnclamped(
				transform.rotation,
				transform.position.getRotationTo(target.transform.position), 
				Time.deltaTime * rotationSpeed
			);
		}
	}
}