using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	public float maxSpeed = 6f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float verticalSpeed = 20;
	[HideInInspector]
	public bool lookingRight = true;
	bool doubleJump = false;
	public GameObject Boost;
	
	private Animator cloudanim;
	public GameObject Cloud;


	private Rigidbody2D rb2d;
	private Animator anim;
	private bool isGrounded = false;

    public CameraUpdate cameraUpdate;
    public GameObject furryPrefab;
    public AudioClip jumpSfx;
    public string scene;
    public GameObject pause;
    public bool paused;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		//cloudanim = GetComponent<Animator>();

		Cloud = GameObject.Find("Cloud");
        //cloudanim = GameObject.Find("Cloud(Clone)").GetComponent<Animator>();

        Time.timeScale = 1;
	}


	void OnCollisionEnter2D(Collision2D collision2D) {
		
		if (collision2D.relativeVelocity.magnitude > 20){
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
		//	cloudanim.Play("cloud");	

		}
	}


	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene(scene);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
                paused = true;
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
                paused = false;
            }
        }

        


        if (Input.GetButtonDown("Jump") && (isGrounded || !doubleJump) && !paused)
		{
			rb2d.AddForce(new Vector2(0,jumpForce));
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(jumpSfx);

            if (!doubleJump && !isGrounded)
			{
				doubleJump = true;
				Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
			//	cloudanim.Play("cloud");		
			}
		}


	if (Input.GetButtonDown("Vertical") && !isGrounded && !paused)
		{
			rb2d.AddForce(new Vector2(0,-jumpForce));
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
			//cloudanim.Play("cloud");
		}

	}


	void FixedUpdate()
	{
		if (isGrounded) 
			doubleJump = false;


		float hor = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (hor));

		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
		  
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

        CameraUpdate cu = Camera.main.GetComponent<CameraUpdate>();

        if (cu.enabled && !isGrounded)
        {
            cu.damping = 0;
        }
        else if (!cu.enabled && isGrounded)
        {
            cu.damping = 1;
        }

		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();
		 
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}


	
	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

    void LateUpdate()
    {
        if (cameraUpdate.maxY < transform.position.y)
        {
            cameraUpdate.maxY = transform.position.y;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(furryPrefab);
        GameManager.Get().onPlayerDied();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void showPaused()
    {
        pause.SetActive(true);
    }

    public void hidePaused()
    {
        pause.SetActive(false);
    }


}
