//using UnityEngine;
//using System.Collections;
//using ScopeCreep.Behavior;
//using ScopeCreep.Resource;
//
//namespace ScopeCreep.Module.Mothership { 
//
//	[RequireComponent (typeof (IMoveable))]
//
//	public class Movement : MonoBehaviour {
//		private IMoveable moveBehavior;
//		private Module mothershipModule;
//		private ICargoHold cargoHold;
//
//		void Start() {
//			mothershipModule = GameObject.Find("MothershipModule").GetComponent<Module>();
//			moveBehavior = GetComponent<IMoveable>();
//		}
//
//		void Update() {
//			if (mothershipModule.activePlayerId > 0 && mothershipModule.canActivePlayerControlModule && hasFuel) {
//				moveBehavior.move();
//			}
//		}
//	}
//}