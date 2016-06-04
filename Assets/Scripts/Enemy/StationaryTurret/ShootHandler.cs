using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

/*
 * This script is responsible for 
 * shooting and aiming at a ITarget's target.
 */

namespace ScopeCreep.Enemy.StationaryTurret {
	public class ShootHandler : MonoBehaviour {
		private Behavior.ITarget targetBehavior;
		private Behavior.IAimable<ITargetable> aimBehavior;

		void Start() {
			targetBehavior = this.GetComponentInChildren<Behavior.ITarget>();
			aimBehavior = this.GetComponentInChildren<Behavior.IAimable<ITargetable>>();
		}

		void Update() {
			ITargetable target = targetBehavior.getTarget();

			if (target != null) {
				aimBehavior.aimAt(target);
			}
		}
	}
}