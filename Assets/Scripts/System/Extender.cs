using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.System {
	public static class Extender {
		public static IEnumerator moveInSeconds2D(this GameObject objectToMove, Vector3 end, float seconds) {
			float elapsedTime = 0;
			end.z = objectToMove.transform.position.z; // Maintain original z coordinate 

			while (elapsedTime < seconds) {
				objectToMove.transform.position = Vector3.Lerp(objectToMove.transform.position, end, (elapsedTime / seconds));
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			objectToMove.transform.position = end;
		}

		public static IEnumerator moveToObjectWithSpeed2D(this GameObject objectToMove, GameObject target, float speed) {
			Vector3 sourcePosition = objectToMove.transform.position;
			Vector3 targetPosition = target.transform.position;

			targetPosition.z = sourcePosition.z; // Maintain original z coordinate

			while (sourcePosition != targetPosition) {
				objectToMove.transform.position = Vector3.MoveTowards(sourcePosition, targetPosition, speed * Time.deltaTime);
				sourcePosition = objectToMove.transform.position;
				targetPosition = target.transform.position;
				targetPosition.z = sourcePosition.z; // Maintain original z coordinate
				yield return null;
			}
		}

		public static Quaternion getRotationTo(this Vector3 sourcePosition, Vector3 targetPosition, float angleOffset = 0.0f) {
			Vector3 vectorToTarget = targetPosition - sourcePosition;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + angleOffset;
			return Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}