using UnityEngine;
using System.Collections;

public class DropResourceOnDestroy : MonoBehaviour {
	public string resourceName = "Resource/SpaceDollar";
	public int amount = 1;

	private bool isApplicationQuitting = false;

	private void OnDestroy() {
		// Spawn in resources upon enemy death
		if (!isApplicationQuitting) { // This is needed if you are going to instantiate objects on an object destroy 
			for (int i = 0; i < amount; i++) {
				Instantiate(
					Resources.Load(resourceName), 
					transform.position,
					transform.rotation
				);
			}
		}
	}

	private void OnApplicationQuit() {
		isApplicationQuitting = true;
	}
}
