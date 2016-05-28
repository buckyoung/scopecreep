using UnityEngine;
using System.Collections;
using ScopeCreep.Enemy.TurretBase;

namespace ScopeCreep.Enemy.Gun {
	public class Gun : MonoBehaviour {
		public int ammo = 100;
		public string projectilePrefab;
		public float projectileForce = 20f;
		public float attackSpeed = 3f;
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

		private void shoot() {
			GameObject projectile = (GameObject)Instantiate(
				Resources.Load(projectilePrefab), 
				transform.position,
				transform.rotation
			);

			projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * projectileForce * Time.deltaTime);

			ammo--;

			isReadyToShoot = false;
			StartCoroutine( shootCoolDown() );

		}

		private IEnumerator shootCoolDown() {
			yield return new WaitForSeconds(1f / attackSpeed);
			isReadyToShoot = true;
		}

		/* 
		 * User Functions
		 */

		void subscribe() {
			TurretBase.TurretBase.onEnemyFound += (eventObject, isFound) => {
				isTargetShootable = isFound;
			};
		}
	}
}