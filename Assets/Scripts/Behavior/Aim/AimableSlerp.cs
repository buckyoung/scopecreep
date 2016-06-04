using UnityEngine;
using System.Collections;
using ScopeCreep.System;

namespace ScopeCreep.Behavior {
	public class AimableSlerp: MonoBehaviour, IAimable<ITargetable> {
		public float rotationSpeed = 1.0f;

		public void aimAt(ITargetable target) {
			if (target.getGameObject() == null) { return; }

			transform.rotation = Quaternion.SlerpUnclamped(
				transform.rotation,
				transform.position.getRotationTo(target.getGameObject().transform.position), 
				Time.deltaTime * rotationSpeed
			);
		}
	}
}