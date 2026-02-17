using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private RaceManager raceManager;

    private void Start()
    {
        raceManager = FindObjectOfType<RaceManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (raceManager != null)
            {
                raceManager.OnFinishLineCrossed();
            }

            Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
            foreach (Checkpoint checkpoint in checkpoints)
            {
                checkpoint.ResetCheckpoint();
            }
        }
    }
}
