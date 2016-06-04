using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Collider2D))] // Required for collision with ITargetable

	public class TargetObjectOnly : MonoBehaviour, ITarget {
		public GameObject objectToTarget = null;

		private ITargetable _target = null;

		public ITargetable getTarget() {
			return _target;
		}

		public void setTarget(ITargetable target) {
			if (target == null) {
				Debug.LogWarning("The target parameter is null. Did you mean to call ITarget's clearTarget()?", this);
				return;
			}

			if (objectToTarget == null) {
				Debug.LogError("Public variable objectToTarget is null.", this);
				return;
			}

			// Ignore targets that are not `objectToTarget`
			if (objectToTarget.GetInstanceID() != target.getGameObject().GetInstanceID()) {
				return;
			}

			_target = target;
		}

		public void clearTarget() {
			_target = null;
		}
	}
}
