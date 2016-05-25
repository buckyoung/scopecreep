using UnityEngine;
using System.Collections;

public class TractorBeamHandler : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider2D;
	private LilGuyModule lilGuyModule;
	private Rigidbody2D lilGuyRigidbody2D;
	private LilGuyMovement lilGuyMovement;
	private bool isChildshipTouching = false;

	void Start() {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
		lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<LilGuyModule>();
		lilGuyRigidbody2D = GameObject.Find("LilGuy").GetComponent<Rigidbody2D>();
		lilGuyMovement = GameObject.Find("LilGuy").GetComponent<LilGuyMovement>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Childship")) {
			isChildshipTouching = true;
			lilGuyRigidbody2D.velocity = Vector2.zero; // Immediate stop

			StartCoroutine( lilGuyMovement.playAnimation_shipEnter() );
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Childship")) { 
			isChildshipTouching = false;
			toggleBeam(false);
		}
	}

	public bool canInitiateTractorBeam() {
		// Ensure that someone is in the childship and that the beam isn't already on
		return lilGuyModule.activePlayerId > 0 && lilGuyModule.canActivePlayerControlModule && !boxCollider2D.enabled;
	}

	void toggleBeam(bool isOn) {
		spriteRenderer.enabled = isOn;
		boxCollider2D.enabled = isOn;
	}

	public IEnumerator playAnimation_tractorBeam() {
		toggleBeam(true);

		yield return new WaitForSeconds(5);

		if (!isChildshipTouching) {
			toggleBeam(false);
		}
	}
}
