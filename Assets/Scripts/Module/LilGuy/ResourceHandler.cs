﻿using UnityEngine;
using System.Collections;
using ScopeCreep;

namespace ScopeCreep.Module.LilGuy { 
	public class ResourceHandler : ResourceManager, IResourceHandler {
		private float spaceDollars = 0;
		private int maximum = 10;

		void OnTriggerEnter2D(Collider2D other) {
			if (spaceDollars < maximum && other.gameObject.tag == "Collectible") {

				ResourceManager.collect(this, other.GetComponent<Collectible.Collectible>());

				Destroy(other.gameObject);
			}
		}

		/*
		 * User Functions
		 */
		public void addSpaceDollars(float amount) {
			spaceDollars += amount;
		}

		public int getMaximum() {
			return maximum;
		}

		public float getSpaceDollars() {
			return spaceDollars;
		}
	}
}