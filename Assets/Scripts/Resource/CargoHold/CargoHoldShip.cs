using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ScopeCreep.Resource {

	[Serializable]
	public class CargoHoldShipInit {
		public ResourceType resourceType;
		public ProviderType providerType;
		public float initialValue;
		public float maximumCapacity;
	} 

	public class CargoHoldShip: MonoBehaviour, ICargoHold {
		public CargoHoldShipInit[] inits = new CargoHoldShipInit[Enum.GetNames(typeof(ResourceType)).Length];

		private Dictionary<ResourceType, float> initialValue = new Dictionary<ResourceType, float>();
		private Dictionary<ResourceType, float> maximumCapacity = new Dictionary<ResourceType, float>();
		private Dictionary<ResourceType, ProviderType> providerType = new Dictionary<ResourceType, ProviderType>();
		private Dictionary<ResourceType, ContainerShip> cargoHold = new Dictionary<ResourceType, ContainerShip>();

		void Start() {
			foreach (CargoHoldShipInit init in inits) {
				initialValue.Add(init.resourceType, init.initialValue);
				maximumCapacity.Add(init.resourceType, init.maximumCapacity);
				providerType.Add(init.resourceType, init.providerType);
			}

			// Initialize cargoHold
			foreach (ResourceType type in ((ResourceType[]) Enum.GetValues(typeof(ResourceType)))) {
				cargoHold.Add(type, new Resource.ContainerShip(type, providerType[type], initialValue[type], maximumCapacity[type]));
			}
		}

		public IContainer getContainer(ResourceType type) {
			return cargoHold[type];
		}
	}
}