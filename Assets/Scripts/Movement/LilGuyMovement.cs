using UnityEngine;
using System.Collections;

public class LilGuyMovement : MonoBehaviour {
	public Rigidbody2D rb;
	public float speed = 100.0f;

	private LilGuyModule lilGuyModule;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<LilGuyModule>();
		Physics2D.IgnoreLayerCollision(8, 9); // "PlayerCharacter", "Childship"
	}

	void FixedUpdate() {
		int activePlayerId = lilGuyModule.activePlayerId;

		if (activePlayerId > 0 && lilGuyModule.canActivePlayerControlModule) {
			var movement = new Vector2(Input.GetAxis(activePlayerId + "_AXIS_X"), Input.GetAxis(activePlayerId + "_AXIS_Y"));
			rb.AddRelativeForce(movement * speed * Time.deltaTime);
		}
	}
}