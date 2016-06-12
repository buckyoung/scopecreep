using UnityEngine;
using System.Collections;
using ScopeCreep.Behavior;

namespace ScopeCreep.Resource {

	[RequireComponent (typeof (IMoveable))]

	public class MovementFuelManager : MonoBehaviour {
		private IContainer fuelContainer;
		private IMoveable moveBehavior;

		void Start() {
			fuelContainer = GetComponentInChildren<ICargoHold>().getContainer(ResourceType.FUEL);
			moveBehavior = GetComponent<IMoveable>();

			subscribe();
		}

		/*
		 * User Functions
		 */
		private void subscribe() {
			FueledMovement.onFueledMovement += (eventObject, fuelExpenditure) => {
				if (moveBehavior.Equals(eventObject)) {
					fuelContainer.remove(fuelExpenditure);
				}
			};
		}
	}
}