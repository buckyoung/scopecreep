using UnityEngine;
using System.Collections;

public class LilGuyMovement : MonoBehaviour {
	public Rigidbody2D rigidbody2D;
	public float speed = 100.0f;

	private BoxCollider2D boxCollider2D;
	private LilGuyModule lilGuyModule;
	private BoxCollider2D msBottomBoxCollider2D;
	
	void Start() {
		boxCollider2D = GetComponent<BoxCollider2D>();
		lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<LilGuyModule>();
		msBottomBoxCollider2D = GameObject.Find("MSBottom").GetComponent<BoxCollider2D>();
		rigidbody2D = GetComponent<Rigidbody2D>();

		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("PlayerCharacter"), LayerMask.NameToLayer("Childship"));
	}

	void FixedUpdate() {
		int activePlayerId = lilGuyModule.activePlayerId;

		if (activePlayerId > 0 && lilGuyModule.canActivePlayerControlModule) {
			var movement = new Vector2(Input.GetAxis(activePlayerId + "_AXIS_X"), Input.GetAxis(activePlayerId + "_AXIS_Y"));
			rigidbody2D.AddRelativeForce(movement * speed * Time.deltaTime);
		}
	}

	public IEnumerator playAnimation_shipEnter() {
		var speed = 2.0f;
		var endPosition = lilGuyModule.transform.position;

		lilGuyModule.canActivePlayerControlModule = false; // Player has no control of childship during animation
		Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership during animation

		yield return StartCoroutine( gameObject.moveObjectWithSpeed2D(endPosition, speed) );

		lilGuyModule.canActivePlayerDisengage = true; // Allow player to exit the childship
	}

	public IEnumerator playAnimation_shipExit() {
		var time = .2f;
		var endPosition = transform.position - new Vector3(0f, 2f, 0f);

		lilGuyModule.canActivePlayerControlModule = false; // Player has no control of childship during animation
		Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, true); // Ship will not collide with bottom of mothership during animation

		yield return StartCoroutine( gameObject.moveObjectInSeconds2D(endPosition, time) ); // Childship exits mothership over T seconds

		lilGuyModule.canActivePlayerControlModule = true; // Return childship control to player
		Physics2D.IgnoreCollision(boxCollider2D, msBottomBoxCollider2D, false); // Reenable collisions with mothership
	}
}