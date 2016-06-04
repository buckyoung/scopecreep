using UnityEngine;
using System.Collections;

/*
 * The intention is to call this whenever
 * and the internal cooldown will determine
 * if it should actually shoot.
 * 
 * Thus, you are NOT guarenteed to produce a shot
 * upon calling shoot().
 */

namespace ScopeCreep.Behavior {
	public class ShootOnCooldown : MonoBehaviour, IShoot {
		public string projectileResourceName;
		public float projectileForce;
		public float cooldownTime;
		public float projectileDamage;

		private bool isCoolingDown = false;

		public void shoot() {
			if (isCoolingDown) { return; }

			Vector3 bulletPosition = transform.position;
			bulletPosition.z = bulletPosition.z - 2; // Move the bullet further back

			GameObject projectile = (GameObject)Instantiate(
				Resources.Load(projectileResourceName), 
				bulletPosition,
				transform.rotation
			);

			projectile.GetComponent<IDamage>().setAmount(projectileDamage);
			projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * projectileForce);

			isCoolingDown = true;
			StartCoroutine( shotCoolDown() );
		}

		private IEnumerator shotCoolDown() {
			yield return new WaitForSeconds(cooldownTime);
			isCoolingDown = false;
		}
	}
}