using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour {

    public float jumpForce = 10;
    //public JumpyCam jumpyCam;
    public GameObject playerPrefab;
    Rigidbody2D rb;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-200 * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(200 * Time.deltaTime, 0));
        }
    }

    /*void LateUpdate()
    {
        if (jumpyCam.maxY < transform.position.y)
        {
            jumpyCam.maxY = transform.position.y;
        }
    }*/

    private void OnBecameInvisible()
    {
        Destroy(playerPrefab);
    }
}
