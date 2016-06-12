using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module.LilGuy { 

	[RequireComponent (typeof (BoxCollider2D))]
	[RequireComponent (typeof (SpriteRenderer))]

	public class TractorBeam : MonoBehaviour {
		private Animations lilGuyAnimation;
		private bool isChildshipTouching = false;
		private BoxCollider2D boxCollider2D;
		private Module lilGuy;
		private Rigidbody2D lilGuyRigidbody2D;
		private SpriteRenderer spriteRenderer;
		private Vector4 originalColor;

		void Start() {
			boxCollider2D = GetComponent<BoxCollider2D>();
			lilGuy = GameObject.Find("LilGuyModule").GetComponent<Module>();
			lilGuyAnimation = GameObject.Find("LilGuy").GetComponent<Animations>();
			lilGuyRigidbody2D = GameObject.Find("LilGuy").GetComponent<Rigidbody2D>();
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		void OnTriggerEnter2D(Collider2D col) {
			if (col.gameObject.layer == LayerMask.NameToLayer("Childship")) {
				isChildshipTouching = true;
				lilGuyRigidbody2D.velocity = Vector2.zero; // Immediate stop

				originalColor = spriteRenderer.color;
				spriteRenderer.color = originalColor * 1.2f;

				StartCoroutine( lilGuyAnimation.shipEnter() );
			}
		}

		void OnTriggerExit2D(Collider2D col) {
			if (col.gameObject.layer == LayerMask.NameToLayer("Childship")) { 
				isChildshipTouching = false;
				toggleBeam(false);

				spriteRenderer.color = originalColor;
			}
		}

		/*
		 *  User Functions
		 */

		public bool canInitiateTractorBeam() {
			// Ensure that someone is in the childship and that the beam isn't already on
			return lilGuy.activePlayerId > 0 && lilGuy.canActivePlayerControlModule && !boxCollider2D.enabled;
		}

		public IEnumerator playAnimation_tractorBeam() {
			toggleBeam(true);

			yield return new WaitForSeconds(5);

			if (!isChildshipTouching) {
				toggleBeam(false);
			}
		}

		void toggleBeam(bool isOn) {
			spriteRenderer.enabled = isOn;
			boxCollider2D.enabled = isOn;
		}
	}
}