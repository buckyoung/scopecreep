using UnityEngine;
using System.Collections;

public class LilGuyModule : Module {
	private int previousActivePlayerId = 0; 
	private GameObject lilGuy;
	private BoxCollider2D lilGuyBoxCollider2D;
	private BoxCollider2D msBottomBoxCollider2D;

	void Start() {
		base.Start();

		lilGuy = GameObject.Find("LilGuy");
		lilGuyBoxCollider2D = lilGuy.GetComponent<BoxCollider2D>();
		msBottomBoxCollider2D = GameObject.Find("MSBottom").GetComponent<BoxCollider2D>();
	}

	void Update() {
		base.Update();

		if (previousActivePlayerId == 0 && activePlayerId > 0) { // First frame after player has engaged with the module
			int index = activePlayerId - 1;
			players[index].GetComponent<SpriteRenderer>().enabled = false; // Player "enters" the childship
			previousActivePlayerId = activePlayerId;

			canActivePlayerControlModule = false;
			Physics2D.IgnoreCollision(lilGuyBoxCollider2D, msBottomBoxCollider2D, true);

		}

		if (activePlayerId == 0 && previousActivePlayerId > 0) { // First frame after player has disengaged with the module
			int index = previousActivePlayerId - 1;
			players[index].GetComponent<SpriteRenderer>().enabled = true; // Player "exits" the childship
			previousActivePlayerId = 0;
		}
	}
}
