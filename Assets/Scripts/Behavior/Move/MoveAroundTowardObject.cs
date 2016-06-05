using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public class MoveAroundTowardObject : MonoBehaviour, IMoveable {
		public float speed = 0.05f;
		public GameObject targetObject;

		void Update() {
			move();
		}

		/*
		 * User Functions
		 */

		public void move() {
//			float totalForce = -speed;
//
//			Vector3 thing = targetObject.transform.TransformDirection(Vector3.down * 10);
//
//			Debug.Log(targetObject.transform.position);
//
//			totalForce *= Mathf.Sign(thing.x - transform.position.x);
//
//			totalForce *= Mathf.Sign(targetObject.transform.position.y);
//
////			totalForce *= Mathf.Sign(transform.position.y);
//
//
//
//			transform.RotateAround(
//				Vector3.zero, 
//				Vector3.forward, 
//				totalForce
//			);

			// Should I move at all?
			Vector3 thisPos = this.transform.position;
			Vector3 lilGuyPos = targetObject.transform.position;
			float angle = AngleSigned(thisPos, lilGuyPos, Vector3.forward);
			float absAngle = Mathf.Abs(angle);

			if (absAngle < 2 || absAngle > 90) {
				return; // Dont move!
			}

			// Should I move left or right?
			float totalForce = speed * Mathf.Sign(angle);
				
			// Move
			transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				totalForce
			);
		}

		public float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n){
			return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
		}
	}
}