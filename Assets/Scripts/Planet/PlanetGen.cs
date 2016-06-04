using UnityEngine;
using System.Collections;
using ScopeCreep.System;

namespace ScopeCreep.Planet {
	
	[RequireComponent (typeof (CircleCollider2D))]

	public class PlanetGen : MonoBehaviour {
		CircleCollider2D cc2D;

		void Start() {
			cc2D = GetComponent<CircleCollider2D>();

			if (cc2D.radius > 4.5) {
				Debug.LogError("GOT WRONG COLLIDER -- THIS SHOULD NEVER HAPPEN LET ME KNOW IF IT DOES - buck"); // TODO BUCK - remove this
			}

			// Will generate 30 guns in random positions around the planet
			// The TurretBase OnTriggerEnter2D will destroy a guns that is too close to another
			// So in the end you will have <= 30 turrets
			// TODO BUCK -- this is the first pass, we will need to generalize this solution
//			for (var i = 0; i < 50; i++) {
//				GameObject resource = Resources.Load("TowerGun") as GameObject;
//				resource.transform.position = getRandomPositionOnOusideOfPlanet(resource);
//
//				Instantiate(
//					Resources.Load("TowerGun"), 
//					resource.transform.position,
//					resource.transform.position.getRotationTo(this.transform.position, 90.0f)
//				);
//			}
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
