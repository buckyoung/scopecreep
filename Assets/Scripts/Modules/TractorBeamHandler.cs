using UnityEngine;
using System.Collections;

public class TractorBeamHandler : MonoBehaviour {
	public bool canInitiateTractorBeam = false; 

	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	public IEnumerator playAnimation_tractorBeam() {
		spriteRenderer.enabled = true; // Turn on the beam
		yield return new WaitForSeconds(3); // Wait X seconds
		// TODO BUCK only turn the beam off if not touching ship
		spriteRenderer.enabled = false; // Turn off the beam
	}
}
