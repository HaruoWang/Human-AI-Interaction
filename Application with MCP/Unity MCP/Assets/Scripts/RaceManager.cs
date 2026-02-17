using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    [Header("Race Settings")]
    [SerializeField] private int totalLaps = 3;
    [SerializeField] private Transform startPosition;

    [Header("References")]
    [SerializeField] private CarController playerCar;
    [SerializeField] private RaceUI raceUI;

    private int currentLap = 0;
    private float raceTime = 0f;
    private bool raceStarted = false;
    private bool raceFinished = false;
    private int checkpointsPassed = 0;
    private int totalCheckpoints = 0;

    private void Start()
    {
        totalCheckpoints = FindObjectsOfType<Checkpoint>().Length;
        
        if (startPosition != null && playerCar != null)
        {
            playerCar.ResetCar(startPosition.position, startPosition.rotation);
        }

        if (raceUI != null)
        {
            raceUI.UpdateLap(currentLap, totalLaps);
            raceUI.UpdateTime(0f);
        }
    }

    private void Update()
    {
        if (raceStarted && !raceFinished)
        {
            raceTime += Time.deltaTime;
            if (raceUI != null)
            {
                raceUI.UpdateTime(raceTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartRace();
        }
    }

    public void StartRace()
    {
        if (!raceStarted)
        {
            raceStarted = true;
            currentLap = 1;
            raceTime = 0f;
            
            if (raceUI != null)
            {
                raceUI.UpdateLap(currentLap, totalLaps);
                raceUI.ShowMessage("");
            }
        }
    }

    public void OnCheckpointPassed()
    {
        checkpointsPassed++;
    }

    public void OnFinishLineCrossed()
    {
        if (!raceStarted)
        {
            StartRace();
            return;
        }

        if (checkpointsPassed < totalCheckpoints)
        {
            return;
        }

        checkpointsPassed = 0;
        currentLap++;

        if (raceUI != null)
        {
            raceUI.UpdateLap(currentLap, totalLaps);
        }

        if (currentLap > totalLaps)
        {
            FinishRace();
        }
    }

    private void FinishRace()
    {
        raceFinished = true;
        
        if (raceUI != null)
        {
            raceUI.ShowMessage($"Race Complete! Time: {FormatTime(raceTime)}\nPress R to restart");
        }
    }

    public void RestartRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
