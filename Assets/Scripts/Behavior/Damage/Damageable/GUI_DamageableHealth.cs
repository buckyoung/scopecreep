using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {

	[RequireComponent (typeof (DamageableHealth))]

	public class GUI_DamageableHealth : MonoBehaviour {
		public bool isUpTop;

		private float x;
		private float y;
		private float w;
		private float h;
		private float offset;
		private DamageableHealth damageableHealth;

		void Start() {
			damageableHealth = gameObject.GetComponent<DamageableHealth>();
		}

		void OnGUI() {
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
			offset = 0;
		}

		private void drawHealthGui() {
			GUI.Label(new Rect(x, y, w, h), "Health: " + damageableHealth.getHealth());
		}
	}
}