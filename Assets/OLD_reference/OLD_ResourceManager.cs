//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ScopeCreep.Resource;
//
//namespace ScopeCreep.Module {
//	public class ResourceManager : MonoBehaviour {
//		// Events
//		public delegate void FuelEvent(ResourceManager eventObject, bool hasFuel);
//		public static event FuelEvent onFuelEvent;
//
//		protected void Start() {}
//
//		/*
//		 * User Functions
//		 */
//
////		protected void emptyInto(Dictionary<Resource.ResourceType, float> source, Dictionary<Resource.ResourceType, float> destination) {
////			foreach(Resource.ResourceType type in ((Resource.ResourceType[]) Resource.ResourceType.GetValues(typeof(Resource.ResourceType)))) {
////				destination[type] += source[type];
////				source[type] = 0;
////			}
////
////			// FUEL TODO BUCK
////			throwFuelEvent(mothershipResourceHandler); // Mothership could have gotten fuel from childship
////		}
////
////		protected void refuelLilGuy() {
////			float available = mothershipResourceHandler.cargoHold[Resource.ResourceType.FUEL];
////			float requested = lilGuyResourceHandler.getMaximum();
////
////			// Give childship the requested amount unless mothership doesnt have enough, in which case give it all
////			float amount = available >= requested ? requested : available; 
////
////			lilGuyResourceHandler.cargoHold[Resource.ResourceType.FUEL] += amount;
////			mothershipResourceHandler.cargoHold[Resource.ResourceType.FUEL] -= amount;
////
////			// FUEL TODO BUCK
////			throwFuelEvent(lilGuyResourceHandler);
////		}
////
////		// FUEL TODO BUCK
////		protected void throwFuelEvent(ResourceManager eventObject) {
////			bool hasFuel = eventObject.cargoHold[Resource.ResourceType.FUEL] > 0;
////			if (onFuelEvent != null) onFuelEvent(eventObject, hasFuel);
////		}
//	}
//}