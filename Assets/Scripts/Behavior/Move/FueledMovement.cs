using UnityEngine;
using System.Collections;

namespace ScopeCreep.Behavior {
	public class FueledMovement : MonoBehaviour {
		// Events
		public delegate void FuelMovementEvent(IMoveable eventObject, float fuelExpenditure);
		public static event FuelMovementEvent onFueledMovement;

		protected void throwFueledMovementEvent(IMoveable that, float fuelExpenditure) {
			if (fuelExpenditure < 0) {
				Debug.LogWarning("Fuel expenditure should not be less than 0. Try using the absolute value.", this);
				return;
			}

			if (onFueledMovement != null) onFueledMovement(that, fuelExpenditure);
		}
	}
}