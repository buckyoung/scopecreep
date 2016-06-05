using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

/* 
 * This script is responsible for setting / unsetting 
 * a targetable entity
 * on an ITarget component. 
 */

namespace ScopeCreep.Enemy {

	[RequireComponent (typeof (ITarget<ITargetable>))]

	public class ITargetHandler : MonoBehaviour {
		public string targetObjectName = "LilGuy";

		private Behavior.ITarget<ITargetable> targetBehavior;
		private int targetObjectId;

		void Start() {
			targetBehavior = GetComponent<Behavior.ITarget<ITargetable>>();

			// Get targetObject ID
			GameObject targetObject = GameObject.Find(targetObjectName);
			if (targetObject == null) {
				Debug.LogError("Error: cannot find a GameObject named " + targetObjectName, this);
			}
			targetObjectId = targetObject.GetInstanceID();
		}

		void OnTriggerEnter2D(Collider2D col) {
			Behavior.ITargetable targetableObject = col.gameObject.GetComponent<Behavior.ITargetable>();

			// Set target if it enters the radar zone
			if (targetableObject != null && !targetableObject.Equals(null)) {

				// Ignore targets that are not `objectToTarget`
				if (targetObjectId != targetableObject.getGameObject().GetInstanceID()) {
					return;
				}

				targetBehavior.setTarget(targetableObject);
			}
		}

		void OnTriggerExit2D(Collider2D col) {
			Behavior.ITargetable targetableObject = col.gameObject.GetComponent<Behavior.ITargetable>();
			Behavior.ITargetable currentTarget = targetBehavior.getTarget();

			// Clear target if it leaves the radar zone
			if (targetableObject != null && !targetableObject.Equals(null) && 
				currentTarget != null && !currentTarget.Equals(null)) {
				if (targetableObject.getGameObject().GetInstanceID() == currentTarget.getGameObject().GetInstanceID()) {
					targetBehavior.clearTarget();
				}
			}
		}

	}
}