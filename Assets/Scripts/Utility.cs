using UnityEngine;
using System.Collections;

public static class Utility {
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
}