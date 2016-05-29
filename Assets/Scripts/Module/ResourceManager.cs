﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ScopeCreep;
using ScopeCreep.Collectible;

namespace ScopeCreep.Module {
	public class ResourceManager : MonoBehaviour {
		public Dictionary<Resource.ResourceType, float> cargoHold = new Dictionary<Resource.ResourceType, float>();

		private LilGuy.ResourceHandler lilGuyResourceHandler;
		private Mothership.ResourceHandler mothershipResourceHandler;

		protected void Start() {
			lilGuyResourceHandler = GameObject.Find("LilGuy").GetComponent<ScopeCreep.Module.LilGuy.ResourceHandler>();
			mothershipResourceHandler = GameObject.Find("MothershipModule").GetComponent<ScopeCreep.Module.Mothership.ResourceHandler>();

			initializeCargoHold();

			subscribe();
		}

		/*
		 * User Scripts
		 */
		private void initializeCargoHold() {
			foreach(Resource.ResourceType type in ((Resource.ResourceType[]) Resource.ResourceType.GetValues(typeof(Resource.ResourceType)))) {
				cargoHold.Add(type, 0.0f);
			}
		}

		private void subscribe() {
			// Collect all childship resources upon redocking with mothership
			LilGuy.LilGuy.onLilGuyInteraction += (eventObject, isEngaged) => {
				if (!isEngaged) {
					emptyInto(lilGuyResourceHandler.cargoHold, mothershipResourceHandler.cargoHold);
				} else {
					refuel(mothershipResourceHandler.cargoHold, lilGuyResourceHandler.cargoHold);
				}
			};
		}

		protected void addResource(Resource.ResourceType type, float amount) {
			cargoHold[type] += amount;
		}

		protected void emptyInto(Dictionary<Resource.ResourceType, float> source, Dictionary<Resource.ResourceType, float> destination) {
			foreach(Resource.ResourceType type in ((Resource.ResourceType[]) Resource.ResourceType.GetValues(typeof(Resource.ResourceType)))) {
				destination[type] += source[type];
				source[type] = 0;
			}
		}

		protected void refuel(Dictionary<Resource.ResourceType, float> source, Dictionary<Resource.ResourceType, float> destination) {
			
		}

		public float getResource(Resource.ResourceType type) {
			return cargoHold[type];
		}
	}
}