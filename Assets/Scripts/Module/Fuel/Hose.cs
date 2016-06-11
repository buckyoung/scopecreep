using UnityEngine;
using System.Collections;

namespace ScopeCreep.Module.Fuel { 
	public class Hose : MonoBehaviour {
		private GameObject fuelModule;
		private GameObject nozzle;
		private int SEGMENT_COUNT = 10;

		void Start() {
			fuelModule = GameObject.Find("FuelModule");
			nozzle = GameObject.Find("Nozzle");
		}

		void Update() {
			float t = 0;
			Vector3 q0;
			Vector3 q1;

			q0 = calculateBezierPoint(
				t,
				nozzle.transform.position,
				bisectAngle(nozzle.transform.localPosition, fuelModule.transform.localPosition),
				fuelModule.transform.position
			);


			for(int i = 1; i <= SEGMENT_COUNT; i++) {
				t = i / (float) SEGMENT_COUNT;

				q1 = calculateBezierPoint(
					t,
					nozzle.transform.position,
					nozzle.transform.TransformVector(bisectAngle(nozzle.transform.localPosition, fuelModule.transform.localPosition)),
					fuelModule.transform.position
				);

				drawLine(q0, q1);

				q0 = q1;
			}
		}


		private void drawLine(Vector3 q0, Vector3 q1) {
			Debug.Log("Line: " + q0 + q1);

			Debug.DrawLine(q0, q1);
		}

		private Vector3 bisectAngle(Vector3 v1, Vector3 v2) {
			

			return (v1 + v2);
		}


		private Vector3 calculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2) {
			float u = 1 - t;
			float uu = u * u;
			float tt = t*t;

			return (uu * p0) + (2 * u * t * p1) + (tt * p2);
		}
	}
}