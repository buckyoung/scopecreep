using UnityEngine;
using System.Collections;
using ScopeCreep.System;

namespace ScopeCreep.Planet {
	
	[RequireComponent (typeof (CircleCollider2D))]

	public class PlanetGen : MonoBehaviour {

		private static int numberOfObjects = 2;

		public string[] spawnResouceName = new string[numberOfObjects];
		public int[] spawnAmount = new int[numberOfObjects];

		private CircleCollider2D cc2D;

		void Start() {
			cc2D = GetComponent<CircleCollider2D>();

			int zPosition = 10; // TODO

			// For each spawn object...
			for (var i = 0; i < spawnResouceName.Length; i++) {
				zPosition += i; // Will put each new resource type on different layers

				// Spawn a certain amount
				for (var k = 0; k < spawnAmount[i]; k++) {
					GameObject resource = Resources.Load(spawnResouceName[i]) as GameObject;
					resource.transform.position = getRandomPositionOnOusideOfPlanet(resource, zPosition);

					Instantiate(
						resource, 
						resource.transform.position,
						resource.transform.position.getRotationTo(this.transform.position, 90.0f)
					);
				}
			}
		}

		private Vector3 getRandomPositionOnOusideOfPlanet(GameObject resource, int zPosition) {
			Vector3 position = transform.position;
			position = Random.insideUnitCircle.normalized;
			position *= cc2D.radius * this.transform.localScale.x + resource.transform.Find("Base").transform.localScale.y/2 - 0.05f;
			position.z = zPosition;
			return position;
		}
	}
}
