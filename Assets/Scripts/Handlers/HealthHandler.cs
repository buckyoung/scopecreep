//using UnityEngine;
//using System.Collections;
//
//namespace ScopeCreep.CommonHandlers {
//
//	[RequireComponent (typeof (IDamageable))]
//
//	public class HealthHandler : MonoBehaviour {
//
//		public IDamageable damageableBehavior;
//		public string 
//
//		void Start() {
//			damageableBehavior = GetComponent<IDamageable>();
//		}
//
//		void OnCollisionEnter2D(Collision2D col) {
//			GameObject colObj = col.gameObject;
//
//			if ( colObj.CompareTag("EnemyBullet") ) {
//
//
//
//
//				hitPoints = hitPoints - colObj.GetComponent<ScopeCreep.Enemy.Bullet.Bullet>().damageToDeal;
//			}
//		}
//	}
//}
