using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    
    [Header("Camera Settings")]
    public float distance = 10f;
    public float height = 5f;
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 2f;
    
    private Vector3 offset;
    
    void Start()
    {
        // Auto-find Car if target not assigned
        if (target == null)
        {
            GameObject car = GameObject.Find("Car");
            if (car != null)
            {
                target = car.transform;
            }
            else
            {
                Debug.LogWarning("CameraFollow: No target assigned and Car not found!");
                return;
            }
        }
        
        offset = new Vector3(0, height, -distance);
    }
    
    void LateUpdate()
    {
        if (target == null) return;
        
        // Calculate desired position behind the car
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        
        // Smoothly move camera to desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Look at the car
        Vector3 lookDirection = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
