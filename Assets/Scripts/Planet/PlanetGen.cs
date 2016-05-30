using UnityEngine;
using System.Collections;
using ScopeCreep.System;

namespace ScopeCreep.Planet {
	public class PlanetGen : MonoBehaviour {
		CircleCollider2D cc2D;

		void Start() {
			cc2D = GetComponent<CircleCollider2D>();

			if (cc2D.radius > 4.5) {
				Debug.LogError("GOT WRONG COLLIDER");
			}

			for (var i = 0; i < 30; i++) {
				GameObject resource = Resources.Load("TowerGun") as GameObject;
				resource.transform.position = getRandomPositionOnOusideOfPlanet(resource);

				GameObject test = (GameObject)Instantiate(
					Resources.Load("TowerGun"), 
					resource.transform.position,
					resource.transform.position.getRotationTo(this.transform.position, 90.0f)
				);
			}
		}

		private Vector3 getRandomPositionOnOusideOfPlanet(GameObject resource) {
			Vector3 position = transform.position;
			position = Random.insideUnitCircle.normalized;
			position *= cc2D.radius * this.transform.localScale.x + resource.transform.localScale.y/2;
			position.z = -8;
			return position;
		}


	}
}
