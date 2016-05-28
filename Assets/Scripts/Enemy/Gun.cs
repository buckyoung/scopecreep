﻿using UnityEngine;
using System.Collections;
using ScopeCreep.Enemy.TurretBase;

namespace ScopeCreep.Enemy.Gun {
	public class Gun : MonoBehaviour {
		public int ammo = 100;
		public float attackSpeed = 3f;
		public string projectilePrefab = "TurretBullet";
		public float projectileForce = 100f;

		private bool isReadyToShoot = true;
		private bool isTargetShootable;

		private void Start() {
			subscribe();
		}
		
		private void Update() {
			if (isTargetShootable && ammo > 0 && isReadyToShoot) {
				shoot();
			}
		}

		/* 
		 * User Functions
		 */
		private void shoot() {
			Vector3 bulletPosition = transform.position;
			bulletPosition.z = 10;

			GameObject projectile = (GameObject)Instantiate(
				Resources.Load(projectilePrefab), 
				bulletPosition,
				transform.rotation
			);

			projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * projectileForce);

			ammo--;

			isReadyToShoot = false;
			StartCoroutine( shootCoolDown() );

		}

		private IEnumerator shootCoolDown() {
			yield return new WaitForSeconds(1f / attackSpeed);
			isReadyToShoot = true;
		}

		void subscribe() {
			TurretBase.TurretBase.onEnemyFound += (eventObject, isFound) => {
				isTargetShootable = isFound;
			};
		}
	}
}
