using UnityEngine;
using System.Collections;
using ScopeCreep.Module;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (DamageableHealth))]

	public class GUI_DamageableHealth : ShipGUI {
		public bool isUpTop;

		private float x;
		private float y;
		private float w;
		private float h;
		private DamageableHealth damageableHealth;

		new void Start() {
			base.Start();

			damageableHealth = gameObject.GetComponent<DamageableHealth>();
		}

		void OnGUI() {
			if (!shouldDraw) { return; }

			setPosition();
			drawHealthGui();
		}

		/*
		 * User Functions
		 */
		private void setPosition() {
			x = Screen.width - 300;
			y = (isUpTop ? 10 : Screen.height - 20);
			w = 140;
			h = 30;
		}

		private void drawHealthGui() {
			GUI.Label(new Rect(x, y, w, h), "Health: " + damageableHealth.getHealth());
		}
	}
}