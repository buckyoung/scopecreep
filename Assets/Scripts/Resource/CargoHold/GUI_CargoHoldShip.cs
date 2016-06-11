using UnityEngine;
using System;
using System.Collections;

namespace ScopeCreep.Resource {

	[RequireComponent (typeof (CargoHoldShip))]

	public class GUI_CargoHoldShip : MonoBehaviour {
		public bool isUpTop;

		private float x;
		private float y;
		private float w;
		private float h;
		private float offset;
		private CargoHoldShip cargoHoldShip;

		delegate void SetOffset();
		private SetOffset setOffset;

		void Start() {
			cargoHoldShip = gameObject.GetComponent<CargoHoldShip>();

			// Define setOffset
			if (isUpTop) {
				setOffset += () => {
					offset += 15;
				};
			} else {
				setOffset += () => {
					offset -= 15;
				};
			}
		}

		void OnGUI() {
			setInitialPosition();
			drawResourceGui();
		}

		/*
		 * User Functions
		 */
		private void setInitialPosition() {
			x = Screen.width - 200;
			y = (isUpTop ? 10 : Screen.height - 20);
			w = 190;
			h = 30;
			offset = 0;
		}

		private void drawResourceGui() {
			foreach (ResourceType type in ((ResourceType[]) Enum.GetValues(typeof(ResourceType)))) {
				IContainer container = cargoHoldShip.getContainer(type);
				GUI.Label(new Rect(x, y + offset, w, h), type.ToString() + ": " + container.getAmount() + " / " + container.getCapacity());
				setOffset();
			}
		}
	}
}