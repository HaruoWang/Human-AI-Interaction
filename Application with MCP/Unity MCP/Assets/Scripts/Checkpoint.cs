using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private RaceManager raceManager;
    private bool passed = false;

    private void Start()
    {
        raceManager = FindObjectOfType<RaceManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !passed)
        {
            passed = true;
            if (raceManager != null)
            {
                raceManager.OnCheckpointPassed();
            }
        }
    }

    public void ResetCheckpoint()
    {
        passed = false;
    }
}
