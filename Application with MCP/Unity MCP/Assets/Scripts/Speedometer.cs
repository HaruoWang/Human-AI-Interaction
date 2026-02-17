using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [Header("References")]
    public CarController carController;
    public Text speedText;
    
    private string speedDisplay = "Speed: 0 km/h";
    
    void Start()
    {
        // Auto-find CarController if not assigned
        if (carController == null)
        {
            GameObject car = GameObject.Find("Car");
            if (car != null)
            {
                carController = car.GetComponent<CarController>();
            }
        }
        
        // Auto-find Text component if not assigned
        if (speedText == null)
        {
            speedText = GetComponent<Text>();
        }
    }
    
    void Update()
    {
        if (carController != null)
        {
            float speed = carController.GetSpeed();
            speedDisplay = "Speed: " + speed.ToString("F0") + " km/h";
            
            if (speedText != null)
            {
                speedText.text = speedDisplay;
            }
        }
    }
    
    void OnGUI()
    {
        // Fallback display if no UI Text assigned
        if (speedText == null && carController != null)
        {
            GUI.Label(new Rect(10, 10, 200, 30), speedDisplay);
            GUI.Label(new Rect(10, 40, 300, 30), "Controls: Arrow Keys / WASD to drive, Space to brake");
        }
    }
}
