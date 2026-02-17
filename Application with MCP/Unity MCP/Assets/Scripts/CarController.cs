using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float motorForce = 1500f;
    public float brakeForce = 3000f;
    public float maxSteerAngle = 30f;
    public float downForce = 100f;
    
    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    
    [Header("Wheel Meshes")]
    public Transform frontLeftWheelMesh;
    public Transform frontRightWheelMesh;
    public Transform rearLeftWheelMesh;
    public Transform rearRightWheelMesh;
    
    [Header("Center of Mass")]
    public Transform centerOfMass;
    
    private float motor;
    private float steering;
    private float brake;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Auto-find wheel colliders if not assigned
        if (frontLeftWheelCollider == null)
            frontLeftWheelCollider = transform.Find("FrontLeftWheelCollider")?.GetComponent<WheelCollider>();
        if (frontRightWheelCollider == null)
            frontRightWheelCollider = transform.Find("FrontRightWheelCollider")?.GetComponent<WheelCollider>();
        if (rearLeftWheelCollider == null)
            rearLeftWheelCollider = transform.Find("RearLeftWheelCollider")?.GetComponent<WheelCollider>();
        if (rearRightWheelCollider == null)
            rearRightWheelCollider = transform.Find("RearRightWheelCollider")?.GetComponent<WheelCollider>();
        
        // Auto-find wheel meshes if not assigned
        if (frontLeftWheelMesh == null)
            frontLeftWheelMesh = transform.Find("FrontLeftWheelMesh");
        if (frontRightWheelMesh == null)
            frontRightWheelMesh = transform.Find("FrontRightWheelMesh");
        if (rearLeftWheelMesh == null)
            rearLeftWheelMesh = transform.Find("RearLeftWheelMesh");
        if (rearRightWheelMesh == null)
            rearRightWheelMesh = transform.Find("RearRightWheelMesh");
        
        // Auto-find center of mass if not assigned
        if (centerOfMass == null)
            centerOfMass = transform.Find("CenterOfMass");
        
        if (centerOfMass != null)
        {
            rb.centerOfMass = centerOfMass.localPosition;
        }
    }
    
    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheelPoses();
        AddDownForce();
    }
    
    void GetInput()
    {
        motor = Input.GetAxis("Vertical") * motorForce;
        steering = Input.GetAxis("Horizontal") * maxSteerAngle;
        brake = Input.GetKey(KeyCode.Space) ? brakeForce : 0f;
    }
    
    void HandleMotor()
    {
        rearLeftWheelCollider.motorTorque = motor;
        rearRightWheelCollider.motorTorque = motor;
        
        ApplyBraking();
    }
    
    void ApplyBraking()
    {
        if (brake > 0)
        {
            frontLeftWheelCollider.brakeTorque = brake;
            frontRightWheelCollider.brakeTorque = brake;
            rearLeftWheelCollider.brakeTorque = brake;
            rearRightWheelCollider.brakeTorque = brake;
        }
        else
        {
            frontLeftWheelCollider.brakeTorque = 0;
            frontRightWheelCollider.brakeTorque = 0;
            rearLeftWheelCollider.brakeTorque = 0;
            rearRightWheelCollider.brakeTorque = 0;
        }
    }
    
    void HandleSteering()
    {
        frontLeftWheelCollider.steerAngle = steering;
        frontRightWheelCollider.steerAngle = steering;
    }
    
    void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheelCollider, frontLeftWheelMesh);
        UpdateWheelPose(frontRightWheelCollider, frontRightWheelMesh);
        UpdateWheelPose(rearLeftWheelCollider, rearLeftWheelMesh);
        UpdateWheelPose(rearRightWheelCollider, rearRightWheelMesh);
    }
    
    void UpdateWheelPose(WheelCollider collider, Transform mesh)
    {
        if (mesh == null) return;
        
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        
        mesh.position = position;
        mesh.rotation = rotation;
    }
    
    void AddDownForce()
    {
        rb.AddForce(-transform.up * downForce * rb.velocity.magnitude);
    }
    
    public float GetSpeed()
    {
        return rb.velocity.magnitude * 3.6f;
    }

    public float CurrentSpeed => rb.velocity.magnitude;

    public void SetInput(float move, float turn)
    {
        motor = move * motorForce;
        steering = turn * maxSteerAngle;
    }

    public void ResetCar(Vector3 position, Quaternion rotation)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = position;
        transform.rotation = rotation;
    }
}
