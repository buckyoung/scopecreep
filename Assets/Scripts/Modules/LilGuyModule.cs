using UnityEngine;
using System.Collections;

public class LilGuyModule : Module {
	private int previousActivePlayerId = 0; 

	void Update() {
		base.Update();

		if (activePlayerId > 0) {
			int index = activePlayerId - 1;
			players[index].GetComponent<SpriteRenderer>().enabled = false;
			previousActivePlayerId = activePlayerId;
		} else if (previousActivePlayerId > 0) {
			int index = previousActivePlayerId - 1;
			players[index].GetComponent<SpriteRenderer>().enabled = true;
			previousActivePlayerId = 0;
		}
	}
}
