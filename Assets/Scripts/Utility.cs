using UnityEngine;
using System.Collections;

public static class Utility {
	public static IEnumerator moveObjectInSeconds2D(this GameObject objectToMove, Vector3 end, float seconds) {
		float elapsedTime = 0;
		end.z = objectToMove.transform.position.z; // Maintain original z coordinate 

		while (elapsedTime < seconds) {
			objectToMove.transform.position = Vector3.Lerp(objectToMove.transform.position, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		objectToMove.transform.position = end;
	}

	public static IEnumerator moveObjectWithSpeed2D(this GameObject objectToMove, Vector3 end, float speed) {
		end.z = objectToMove.transform.position.z; // Maintain original z coordinate 

		while (objectToMove.transform.position != end) {
			objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
			yield return null;
		}

		objectToMove.transform.position = end;
	}
}