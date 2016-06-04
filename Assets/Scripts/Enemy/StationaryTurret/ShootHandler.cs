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
		private Behavior.IShoot shootBehavior;

		void Start() {
			targetBehavior = this.GetComponentInChildren<Behavior.ITarget>();
			aimBehavior = this.GetComponentInChildren<Behavior.IAimable<ITargetable>>();
			shootBehavior = this.GetComponentInChildren<Behavior.IShoot>();
		}

		void Update() {
			ITargetable target = targetBehavior.getTarget();

			if ( target == null || target.Equals(null)) { return; }

			aimBehavior.aimAt(target);
			shootBehavior.shoot();
		}
	}
}