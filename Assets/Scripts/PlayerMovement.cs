using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int playerNum = 1;
	public Rigidbody2D rb;
	public float speed = 150.0f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();

		// Ignore collisions between PlayerCharacters
		Physics2D.IgnoreLayerCollision(8, 8);
	}

	void FixedUpdate() {
		var playerMovement = new Vector3(Input.GetAxis("P" + playerNum + "_X_AXIS"), Input.GetAxis("P" + playerNum + "_Y_AXIS"), 0);
		rb.AddRelativeForce(playerMovement * speed * Time.deltaTime);
	}
}