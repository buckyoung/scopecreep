using UnityEngine;
using System.Collections;

public class DrawWalls : MonoBehaviour {
	
	void Update () {
        // Get camera borders
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        float dist = (transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        // Dynamically set the walls' positions
        Transform leftForm = transform.Find("LeftWall").gameObject.transform;
        Transform rightForm = transform.Find("RightWall").gameObject.transform;
        leftForm.position = new Vector3(leftBorder - 0.5f, leftForm.position.y, leftForm.position.z);
        rightForm.position = new Vector3(rightBorder + 0.5f, rightForm.position.y, rightForm.position.z);

        // NJD TODO: Consider altering the ceiling's scale (currently hard coded to 50 units long, which should work for almost every screen size.
    }
}
