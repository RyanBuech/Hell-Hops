using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdate : MonoBehaviour {

    public float maxY;
    public Transform target;
    public float damping = 1.0f;

	// Use this for initialization
	void FixedUpdate()
    {
        if (target !=null)
        {
            Vector3 position = transform.position;
            Vector3 targetPosition = target.position;

            targetPosition.z = position.z;

            transform.position += (targetPosition - position) * damping * Time.fixedDeltaTime;
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
		if (transform.position.y < maxY)
        {
            transform.position = new Vector3(0, maxY, transform.position.z);
        }
	}
}
