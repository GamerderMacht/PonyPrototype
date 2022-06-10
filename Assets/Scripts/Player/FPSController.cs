using UnityEngine;
using System.Collections;



public class FPSController : MonoBehaviour {
	
	// public vars
	[HideInInspector] public float mouseSensitivityX = 1;
	[HideInInspector] public float mouseSensitivityY = 1;
    
    public float speed = 6;
	public float walkSpeed = 6;
    public float runSpeed = 9;
	public float jumpForce = 220;
    public bool isRunning = false;

    public float inputX;
    public float inputY;
	public LayerMask groundedMask;
	
	// System vars
	public bool grounded;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	float verticalLookRotation;

    [SerializeField] Camera cam;
    
	//Transform cameraTransform;
	Rigidbody playerRb;

    

    [Header("Animation")]
    [SerializeField] Animator animator;
	
	void Awake() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		//cameraTransform = Camera.main.transform;
		playerRb = GetComponent<Rigidbody>();
        
	}
	
	void Update()
    {
        
        CameraSwitcher();

    }
    void FixedUpdate()
    {
        ApplyPhysicMovement();
    }
    void LateUpdate()
    {
        if(!PauseMenu.GameIsPaused) PlayerMovement();
        
    }

    




    //Methoden-----------------------

    public void PlayerMovement()
    {
        // Look rotation:
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        

        // Calculate movement:
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal Input", inputX);
        animator.SetFloat("Vertical Input", inputY);

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, cam.transform.localEulerAngles.y, transform.localEulerAngles.z);
        Vector3 targetMoveAmount = moveDir * speed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        if(inputX != 0 || inputY != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        

        //Sprinten
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isRunning)
        {
            
            speed = runSpeed;
            isRunning = true;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            isRunning = false;
            speed = walkSpeed;
            animator.SetBool("isRunning", false);
        }
        else
        {
            
        }
        

        // Jump
        if (Input.GetButtonDown("Jump") && inputY > 0)
        {
            if (grounded)
            {
                playerRb.AddForce(transform.up * jumpForce);
                
            }
        }

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
        {
            grounded = true;
            animator.SetBool("isJumping", false);
            
        }
        else
        {
            grounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    private void CameraSwitcher()
    {
        /*
        //change camera
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (!camFPSOn)
            {
                //FPS Cam an
                camFPS.enabled = true;
                camTop.enabled = false;

                camFPSOn = true;
            }
            else
            {
                //Vogelpersektive an
                camFPS.enabled = false;
                camTop.enabled = true;

                camFPSOn = false;
            }

        }
        
        if (Input.mouseScrollDelta == new Vector2(0,-1) && camTop.transform.localPosition.z >= -10)
        {
            camTop.transform.localPosition += new Vector3(0,0,zoomValue);
        }
        else if (Input.mouseScrollDelta == new Vector2(0,1) && camTop.transform.localPosition.z <= 0)
        {
            camTop.transform.localPosition -= new Vector3(0,0,zoomValue);
        }
        */
    }

    private void ApplyPhysicMovement()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        playerRb.MovePosition(playerRb.position + localMove);
    }

    


    
}