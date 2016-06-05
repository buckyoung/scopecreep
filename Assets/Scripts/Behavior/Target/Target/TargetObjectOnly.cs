using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (Collider2D))] // Required for collision with ITargetable

	public class TargetObjectOnly : MonoBehaviour, ITarget<ITargetable> {
		private ITargetable _target = null;

		public ITargetable getTarget() {
			return _target;
		}

		public void setTarget(ITargetable target) {
			if (target == null) {
				Debug.LogWarning("The target parameter is null. Did you mean to call ITarget's clearTarget()?", this);
				return;
			}

			_target = target;
		}

		public void clearTarget() {
			_target = null;
		}
	}
}
