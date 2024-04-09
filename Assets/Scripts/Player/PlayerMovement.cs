using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody rb;

    [Header("Walk")]
    [SerializeField] private float groundMoveSpeed;
    [SerializeField] private float jumpMoveSpeed;
    private float verticalInput;
    private float horizontalInput;
    private Vector3 moveDirection;

    [Header("Drag")]
    [SerializeField] private float groundDrag;

    [Header("Jump")]
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravityScale;
    private bool jump;

    [Header("GroundCheck")]
    private bool grounded;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = false;
        grounded = true;
    }

    // Update is called once per frame
    private void Update()
    {
        SetDrag();
        ReceiveInputs();
    }

    private void FixedUpdate()
    {
        SetVelocity();
    }


    private void SetDrag()
    {
        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void ReceiveInputs()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
            grounded = false;
        }
    }

    private void SetVelocity()
    {
        float speed;
        if(grounded)
        {
            speed = groundMoveSpeed;
        }
        else
        {
            speed = jumpMoveSpeed;
        }
        moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput) * (speed * Time.fixedDeltaTime);

        moveDirection.y = rb.velocity.y;

        if(!grounded && Input.GetKey(KeyCode.Space))
        {
            moveDirection.y += Physics.gravity.y * gravityScale * Time.fixedDeltaTime;
        }
        else
        {
            moveDirection.y += Physics.gravity.y * Time.fixedDeltaTime;
        }

        if(jump)
        {
            jump = false;
            moveDirection.y = jumpSpeed;
        }

        rb.velocity = moveDirection;
    }

    public void SetGrounded(bool value)
    {
        grounded = value;
    }
}
