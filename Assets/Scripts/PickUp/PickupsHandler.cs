using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups;
using PeppaSquad.Utils;

public class PickupsHandler : MonoBehaviour {

    [SerializeField]
    private NumberRange pickupWaveCooldownRange;
    [SerializeField]
    private NumberRange waveTimeRange;

    [SerializeField]
    private List<PickupController> pickups;
    private List<PickupController> wavingPickups = new List<PickupController>();

    public NumberRange PickupWaveCooldown => pickupWaveCooldownRange;
    public NumberRange WaveTime => waveTimeRange;

    private void Awake() {
        StartCoroutine(SpawnPickups());
    }

    private IEnumerator SpawnPickups() {
        while (true) {
            float waveTime = WaveTime.GetRandom();
            int pickupIndex = Random.Range(0, pickups.Count);
            var pickup = pickups[pickupIndex];

            if (!pickup.CanPickUp) {
                StartCoroutine(StopWavingTimer(waveTime, pickup));
                pickup.StartPickupWave();
                float delay = PickupWaveCooldown.GetRandom();
                yield return new WaitForSeconds(delay);
            }

        }
    }

    private IEnumerator StopWavingTimer(float time, PickupController pickup) {
        yield return new WaitForSeconds(time);
        pickup.StopPickupWave();
    }

    private void StartWaving() {
        int pickupIndex = Random.Range(0, pickups.Count);
        var pickup = pickups[pickupIndex];

        pickups.Remove(pickup);
        wavingPickups.Add(pickup);

        float waveTime = waveTimeRange.GetRandom();

        StartCoroutine(StopWavingTimer(waveTime, pickup));
    }

    [ContextMenu("Get All Pickups")]
    private void GetAllPickups() {
        pickups = new List<PickupController>(FindObjectsOfType<PickupController>());
    }
}