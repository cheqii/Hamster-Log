using System;
using UnityEngine;

public class LogControl : MonoBehaviour
{
    [Header("Log Control")]
    [SerializeField] private int turnSpeed = 20;
    [SerializeField] private int startPush = 10;
    [SerializeField] private int jumpPower = 5;
    [SerializeField] private int speedLimit;
    
    [Header("Log Physics")]
    [SerializeField] private PhysicMaterial logMaterial;
    [SerializeField] private float normalFriction = 0.12f;
    [SerializeField] private float brakeFriction;

    private Rigidbody rb;
    private GroundCheck _groundCheck;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _groundCheck = GetComponent<GroundCheck>();
        LogSpin();
    }
    
    void Update()
    {
        LogMovement();
    }

    public void HamsterStart()
    {
        rb.isKinematic = false;
        rb.AddForce(Vector3.back * startPush, ForceMode.VelocityChange);
    }
    
    void FixedUpdate()
    {
        if(rb.velocity.magnitude > speedLimit)
        {
            rb.velocity = rb.velocity.normalized * speedLimit;
        }
        
        rb.AddForce(Vector3.back / 10,ForceMode.VelocityChange);
    }

    public void LogMovement()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z);
                HamsterStable(100);

                
            }
            else if(Input.GetKeyUp(KeyCode.A)) ChangeRotate(0);
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                HamsterStable(100);
                rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z);
                
            }
            else if(Input.GetKeyUp(KeyCode.D)) ChangeRotate(0);
            
            // hamster jump
            if (Input.GetKeyDown(KeyCode.Space) && _groundCheck.GetIsGround() == true) Jump(jumpPower);


            if (Input.GetKey(KeyCode.A))
            {
                ChangeRotate(-30);
                rb.AddForce(Vector3.right * Time.deltaTime * (turnSpeed + (rb.velocity.magnitude / 4)), ForceMode.VelocityChange);
            }

            if (Input.GetKey(KeyCode.D))
            {
                ChangeRotate(30);
                rb.AddForce(Vector3.left * Time.deltaTime * (turnSpeed + (rb.velocity.magnitude / 4)), ForceMode.VelocityChange);
            }
            
            //hamster log brake
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Brake();
            }
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SoundManager.Instance.PlayBrake();
            }

            
            if (Input.GetKey(KeyCode.E))
            {
                HamsterStable(2);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ChangeRotate(0);
                logMaterial.staticFriction = normalFriction;
                logMaterial.dynamicFriction = normalFriction;
            }
        
            // hamster log spinning 
            if (Input.GetKey(KeyCode.R)) LogSpin();
        }
    }
    

    public void Jump(int power)
    {
        rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        SoundManager.Instance.PlayJump();
    }
    
    void Brake()
    {
        ChangeRotate(90);
        logMaterial.staticFriction = brakeFriction;
        logMaterial.dynamicFriction = brakeFriction;
    }
    
    void LogSpin()
    {
        rb.AddTorque(transform.right);
    }
    
    private void ChangeRotate(int r)
    {
        var currentAngle = new Vector3(transform.eulerAngles.x,  Mathf.LerpAngle(transform.eulerAngles.y, r, Time.deltaTime*20), transform.eulerAngles.z);


        transform.eulerAngles = currentAngle;
    }

    private void HamsterStable(int speed)
    {
        rb.angularVelocity = Vector3.zero;

        var currentAngle = new Vector3(
            Mathf.LerpAngle(transform.eulerAngles.x, 0, Time.deltaTime*speed),
            Mathf.LerpAngle(transform.eulerAngles.y, 0, Time.deltaTime*speed),
            Mathf.LerpAngle(transform.eulerAngles.z,0,Time.deltaTime*speed));
        
        transform.eulerAngles = currentAngle;
    }
}
