using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ScopeCreep;

namespace ScopeCreep.Module {
	public class ResourceManager : MonoBehaviour {
		public Dictionary<Collectible.Collectible.CollectibleType, float> cargoHold = new Dictionary<Collectible.Collectible.CollectibleType, float>();

		private LilGuy.ResourceHandler lilGuyResourceHandler;
		private Mothership.ResourceHandler mothershipResourceHandler;

		void Start() {
			lilGuyResourceHandler = GameObject.Find("LilGuy").GetComponent<ScopeCreep.Module.LilGuy.ResourceHandler>();
			mothershipResourceHandler = GameObject.Find("MothershipModule").GetComponent<ScopeCreep.Module.Mothership.ResourceHandler>();

			initializeCargoHold();

			subscribe();
		}

		/*
		 * User Scripts
		 */
		private void initializeCargoHold() {
			foreach(Collectible.Collectible.CollectibleType type in ((Collectible.Collectible.CollectibleType[]) Collectible.Collectible.CollectibleType.GetValues(typeof(Collectible.Collectible.CollectibleType)))) {
				cargoHold.Add(type, 0.0f);
			}
		}

		private void subscribe() {
			// Collect all childship resources upon redocking with mothership
			LilGuy.LilGuy.onLilGuyInteraction += (eventObject, isEngaged) => {
				if (!isEngaged) {
					emptyInto(lilGuyResourceHandler.cargoHold, mothershipResourceHandler.cargoHold);
				}
			};
		}

		protected void addResource(Collectible.Collectible.CollectibleType type, float amount) {
			cargoHold[type] += amount;
		}

		protected void emptyInto(Dictionary<Collectible.Collectible.CollectibleType, float> source, Dictionary<Collectible.Collectible.CollectibleType, float> destination) {
			foreach(Collectible.Collectible.CollectibleType type in ((Collectible.Collectible.CollectibleType[]) Collectible.Collectible.CollectibleType.GetValues(typeof(Collectible.Collectible.CollectibleType)))) {
				destination[type] += source[type];
				source[type] = 0;
			}
		}

		public float getResource(Collectible.Collectible.CollectibleType type) {
			return cargoHold[type];
		}
	}
}