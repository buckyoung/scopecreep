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
			float totalForce = -speed;

			Vector3 thing = targetObject.transform.TransformDirection(Vector3.down * 10);

			Debug.Log(targetObject.transform.position);

			totalForce *= Mathf.Sign(thing.x - transform.position.x);

			totalForce *= Mathf.Sign(targetObject.transform.position.y);

//			totalForce *= Mathf.Sign(transform.position.y);



			transform.RotateAround(
				Vector3.zero, 
				Vector3.forward, 
				totalForce
			);
		}
	}
}