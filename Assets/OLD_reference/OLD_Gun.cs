//using UnityEngine;
//using System.Collections;
//
//namespace ScopeCreep.Enemy {
//	public class Gun : MonoBehaviour {
//		public float attackSpeed = 3f;
//		public float projectileForce = 100f;
//		public int ammo = 100;
//		public string projectilePrefab = "TurretBullet";
//		public string resourcePrefab = "SpaceDollarsPrefab";
//
//		private bool isApplicationQuitting = false;
//		private bool isReadyToShoot = true;
//		private bool isTargetShootable;
//
//		private void Start() {
//			subscribe();
//		}
//		
//		private void Update() {
//			if (isTargetShootable && ammo > 0 && isReadyToShoot) {
//				shoot();
//			}
//		}
//
//		private void OnDestroy() {
//			TurretBase.onEnemyFound -= onEnemyFoundListener;
//
//			// Spawn in resources upon enemy death
//			if (!isApplicationQuitting) { // This is needed if you are going to instantiate objects on an object destroy
//				int amt = ammo / 30; // One spacebux for every 30 ammo
//				for (int i = 0; i < amt; i++) {
//					Instantiate(
//						Resources.Load(resourcePrefab), 
//						transform.position,
//						transform.rotation
//					);
//				}
//			}
//		}
//
//		private void OnApplicationQuit() {
//			isApplicationQuitting = true;
//		}
//
//		/* 
//		 * User Functions
//		 */
//		private void shoot() {
//			Vector3 bulletPosition = transform.position;
//			bulletPosition.z = 10;
//
//			GameObject projectile = (GameObject)Instantiate(
//				Resources.Load(projectilePrefab), 
//				bulletPosition,
//				transform.rotation
//			);
//
//			projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * projectileForce);
//
//			ammo--;
//
//			isReadyToShoot = false;
//			StartCoroutine( shootCoolDown() );
//		}
//
//		private IEnumerator shootCoolDown() {
//			yield return new WaitForSeconds(1f / attackSpeed);
//			isReadyToShoot = true;
//		}
//
//		void subscribe() {
//			TurretBase.onEnemyFound += onEnemyFoundListener;
//		}
//
//		private void onEnemyFoundListener(TurretBase eventObject, bool isFound) {
//			if ( eventObject == GetComponentInParent<TurretBase>() ) {
//				isTargetShootable = isFound;
//			}
//		}
//	}
//}
