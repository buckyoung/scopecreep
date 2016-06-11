using UnityEngine;
using System.Collections;

namespace ScopeCreep.Resource {
	public class CollectibleRandomAmount : MonoBehaviour, ICollectible<ResourceType> {
		public ResourceType type;

		// Exponential distribution number may be negative so we dont always get exactly within min/max
		private float softMin = 1f; 
		private float softMax = 15.0f;
		private float amount;

		void Start() {
			amount = (convertToExponentialDistribution(getRandomUniformDistributionNumber())  * (softMax - softMin)) + softMin; // Get amount on an exponential distribution in a certain range
			gameObject.transform.localScale *= Mathf.Log(amount/4 + 1); // Set scale of object using a log scale
		}

		/*
		 * User Functions
		 */
		public float getAmount() {
			return amount;
		}

		public ResourceType getType() {
			return type;
		}

		// Random.value is inclusive with 1.0f, we need it to be exclusive
		private float getRandomUniformDistributionNumber() {
			float min = 0.01f;
			float max = 0.99f;
			float result = Random.value  * (max - min) + min;

			return result;
		}

		private float convertToExponentialDistribution(float uniformDistributionNumber) {
			return Mathf.Log(1 - uniformDistributionNumber) / -5;
		}
	}
}