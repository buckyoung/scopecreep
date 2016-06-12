using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ScopeCreep.Resource {
	public class CargoHoldShip: MonoBehaviour, ICargoHold {
		[Tooltip ("If these fields are blank, the inits are probably being loaded from file at Resources/Data/CargoHoldInit")]
		public CargoHoldShipInit[] inits = new CargoHoldShipInit[Enum.GetNames(typeof(ResourceType)).Length];

		private Dictionary<ResourceType, float> initialValue = new Dictionary<ResourceType, float>();
		private Dictionary<ResourceType, float> maximumCapacity = new Dictionary<ResourceType, float>();
		private Dictionary<ResourceType, ProviderType> providerType = new Dictionary<ResourceType, ProviderType>();
		private Dictionary<ResourceType, IProviderContainer> cargoHold = new Dictionary<ResourceType, IProviderContainer>();

		void Awake() {
			// Attempt to load init from file 
			TextAsset json = Resources.Load("Data/CargoHoldInit/" + transform.parent.gameObject.name) as TextAsset;

			// Overwrite editor settings if file data exists
			if (json != null) {
				JsonUtility.FromJsonOverwrite(json.ToString(), this);
			}

			foreach (CargoHoldShipInit init in inits) {
				initialValue.Add(init.resourceType, init.initialValue);
				maximumCapacity.Add(init.resourceType, init.maximumCapacity);
				providerType.Add(init.resourceType, init.providerType);
			}

			// Initialize cargoHold
			foreach (ResourceType type in ((ResourceType[]) Enum.GetValues(typeof(ResourceType)))) {
				cargoHold.Add(type, new Resource.ProviderContainerShip(type, providerType[type], initialValue[type], maximumCapacity[type]));
			}
		}

		/*
		 * User Functions
		 */

		public IContainer getContainer(ResourceType type) {
			return cargoHold[type];
		}
	}

	[Serializable]
	public class CargoHoldShipInit {
		public ResourceType resourceType;
		public ProviderType providerType;
		public float initialValue;
		public float maximumCapacity;
	} 
}