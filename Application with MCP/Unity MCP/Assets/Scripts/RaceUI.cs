using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaceUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI lapText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI messageText;

    [Header("References")]
    [SerializeField] private CarController playerCar;

    private void Update()
    {
        if (playerCar != null && speedText != null)
        {
            float speed = Mathf.Abs(playerCar.CurrentSpeed) * 3.6f;
            speedText.text = $"Speed: {speed:F0} km/h";
        }
    }

    public void UpdateLap(int currentLap, int totalLaps)
    {
        if (lapText != null)
        {
            lapText.text = $"Lap: {currentLap}/{totalLaps}";
        }
    }

    public void UpdateTime(float time)
    {
        if (timeText != null)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);
            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    public void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
    }
}
