using UnityEngine;
using System.Collections;

public class LilGuyModule : Module {
	private int previousActivePlayerId = 0; 

	void Start() {
		base.Start();

		canActivePlayerControlModule = false;
	}

	void Update() {
		base.Update();

		if (previousActivePlayerId == 0 && activePlayerId > 0) { // First frame after player has engaged with the module
			int index = activePlayerId - 1;
			players[index].GetComponent<SpriteRenderer>().enabled = false; // Player "enters" the childship
			previousActivePlayerId = activePlayerId;
		}

		if (activePlayerId == 0 && previousActivePlayerId > 0) { // First frame after player has disengaged with the module
			int index = previousActivePlayerId - 1;
			players[index].GetComponent<SpriteRenderer>().enabled = true; // Player "exits" the childship
			previousActivePlayerId = 0;
		}
	}
}
