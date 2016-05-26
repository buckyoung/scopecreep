using UnityEngine;

public class DrawWalls : MonoBehaviour {
	private GameObject leftWall;
	private GameObject rightWall;

	void Start() {
		leftWall = GameObject.Find("LeftBoundary").gameObject;
		rightWall = GameObject.Find("RightBoundary").gameObject;
	}

	void Update() {
		// Get camera borders
		float leftBorder = transform.InverseTransformPoint(Camera.main.ViewportToWorldPoint(new Vector2(0, 0))).x;
		float rightBorder = transform.InverseTransformPoint(Camera.main.ViewportToWorldPoint(new Vector2(1, 0))).x;
		
		// Dynamically set the walls' positions
		leftWall.transform.localPosition = new Vector2(leftBorder - 1.0f, leftWall.transform.localPosition.y);
		rightWall.transform.localPosition = new Vector2(rightBorder + 1.0f, rightWall.transform.localPosition.y);
	}
}
