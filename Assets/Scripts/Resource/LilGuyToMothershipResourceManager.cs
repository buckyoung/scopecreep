using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using ScopeCreep.Module;

namespace ScopeCreep.Resource {
	public class LilGuyToMothershipResourceManager : MonoBehaviour {
		private ICargoHold lilGuyCargoHold;
		private ICargoHold mothershipCargoHold;

		void Start() {
			lilGuyCargoHold = GameObject.Find("LilGuy").GetComponent<ICargoHold>();
			mothershipCargoHold = GameObject.Find("Mothership").GetComponent<ICargoHold>();

			subscribe();
		}

		/*
		 * User Functions
		 */

		private void subscribe() {
			// Transfer resources upon redocking
			ShipModule.onModuleInteraction += (eventObject, player, isEngaged) => {
				if (eventObject is Module.LilGuy.Module) {
					if (!isEngaged) {
						redock();
					}
				}
			};
		}

		// Transfer resources depending on ProviderType relationships
		private void redock() {
			foreach (ResourceType resourceType in ((ResourceType[]) Enum.GetValues(typeof(ResourceType)))) {
				IProviderContainer lilGuyContainer = (IProviderContainer) lilGuyCargoHold.getContainer(resourceType);
				IProviderContainer mothershipContainer = (IProviderContainer) mothershipCargoHold.getContainer(resourceType);

				transfer(lilGuyContainer, mothershipContainer);
			}
		}

		private void transfer(IProviderContainer source, IProviderContainer target, bool exit = false) {
			ProviderType sourceProviderType = source.getProviderType();
			ProviderType targetProviderType = target.getProviderType();

			// Ensure one requestor and one provider
			if (sourceProviderType == targetProviderType) {
				Debug.LogWarning("LilGuy and Mothership " + source.getResourceType().ToString() + " containers are both set to ProviderType: " + sourceProviderType.ToString() + ".", this);
				return;
			}

			// Fill source from target
			if (sourceProviderType == ProviderType.REQUESTER) { // Implicitly: (&& targetProviderType == ProviderType.PROVIDER)
				// Request capacity - amount from target
				float amountToRequest = source.getCapacity() - source.getAmount();
				source.add(target.remove(amountToRequest));
			}

			if (exit) { return; }

			// Fill target from source
			transfer(target, source, true);
		}
	}
}