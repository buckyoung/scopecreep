using UnityEngine;
using System.Collections;

public static class Utility {
	public static IEnumerator moveObjectInSeconds (GameObject objectToMove, Vector3 end, float seconds) {
		float elapsedTime = 0;
		Vector3 start = objectToMove.transform.position;

		while (elapsedTime < seconds) {
			objectToMove.transform.position = Vector3.Lerp(start, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		objectToMove.transform.position = end;
	}
}
