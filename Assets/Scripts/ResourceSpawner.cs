using UnityEngine;
using System.Collections;

public class ResourceSpawner : MonoBehaviour {
	private GameObject mothership;

	void Start() {
		mothership = GameObject.Find("Mothership");
	}

	void Update () {
		if (Input.GetButton("DebugButton")) {
			GameObject resource = (GameObject)Instantiate(
				Resources.Load("ResourcePrefab"), 
				mothership.transform.position - (mothership.transform.up * 2.0f), 
				Quaternion.identity
			);

			resource.transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);
		}
	}
}