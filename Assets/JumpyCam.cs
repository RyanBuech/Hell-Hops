using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyCam : MonoBehaviour {

    public float maxY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < maxY)
        {
            transform.position = new Vector3(0, maxY, transform.position.z);
        }
	}
}
