using UnityEngine;
using System.Collections;

public class LilGuyMovement : MonoBehaviour {
	public Rigidbody2D rb;
	public float speed = 100.0f;

	private LilGuyModule lilGuyModule;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		lilGuyModule = GameObject.Find("LilGuyModule").GetComponent<LilGuyModule>();
	}

	void FixedUpdate() {
		int playerId = lilGuyModule.activePlayerId;

		if (playerId > 0) {
			var movement = new Vector2(Input.GetAxis(playerId + "_AXIS_X"), Input.GetAxis(playerId + "_AXIS_Y"));
			rb.AddRelativeForce(movement * speed * Time.deltaTime);
		}
	}
}