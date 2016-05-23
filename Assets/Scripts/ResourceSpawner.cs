using UnityEngine;
using System.Collections;

public class ResourceSpawner : MonoBehaviour {
	private GameObject mothership;

	void Start() {
		mothership = GameObject.Find("Mothership");
	}

	void Update () {
		if (Input.GetKeyDown("p")) {
			GameObject resource = (GameObject)Instantiate(
				Resources.Load("ResourcePrefab"), 
				mothership.transform.position - new Vector3(0, 5, 0), 
				Quaternion.identity
			);

			resource.transform.localScale = new Vector3 (0.5f, 0.5f, 0.0f);
		}
	}
}
