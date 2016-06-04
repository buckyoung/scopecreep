using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

/* 
 * This script is responsible for setting / unsetting 
 * a targetable entity
 * on an ITarget component. 
 */

namespace ScopeCreep.Enemy.StationaryTurret {

	[RequireComponent (typeof (ITarget))]

	public class Radar : MonoBehaviour {
		private Behavior.ITarget targetBehavior;

		void Start() {
			targetBehavior = GetComponent<Behavior.ITarget>();
		}

		void OnTriggerEnter2D(Collider2D col) {
			Behavior.ITargetable targetableObject = col.gameObject.GetComponent<Behavior.ITargetable>();

			// Set target if it enters the radar zone
			if (targetableObject != null) {
				targetBehavior.setTarget(targetableObject);
			}
		}

		void OnTriggerExit2D(Collider2D col) {
			Behavior.ITargetable targetableObject = col.gameObject.GetComponent<Behavior.ITargetable>();
			Behavior.ITargetable currentTarget = targetBehavior.getTarget();

			// Clear target if it leaves the radar zone
			if (targetableObject != null && currentTarget != null) {
				if (targetableObject.getGameObject().GetInstanceID() == currentTarget.getGameObject().GetInstanceID()) {
					targetBehavior.clearTarget();
				}
			}
		}

	}
}