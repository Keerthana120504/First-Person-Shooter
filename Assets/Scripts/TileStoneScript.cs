using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileStoneScript : MonoBehaviour
{
    // Private
    float fullTilePowerTimeInSeconds = 60f; // 5 seconds for full battery time
    float tilePowerConsumptionRate;  // battery consumption rate per second
    float consumptionMultiplier = 4f; // Increase this factor to consume battery faster

    // Public
    public Slider tilePowerStatus;

    public float tilePower = 0f;
    public float tilePowerFull = 100f;
    public float tilePowerOut = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate battery consumption rate: 100% battery over 5 seconds
        tilePowerConsumptionRate = 100f / fullTilePowerTimeInSeconds; // This gives us a consumption rate of 20 units per second.

        if (tilePowerStatus != null)
        {
            tilePowerStatus.maxValue = tilePowerFull;
            tilePowerStatus.minValue = tilePowerOut;
            tilePowerStatus.value = tilePower;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TilePowerConsumption();
    }


    public void TilePicked()
    {
        tilePower = tilePowerFull;

    }

    void TilePowerConsumption()
    {
        // Decrease fuel based on the fuel consumption rate and the consumption multiplier
        float batteryDecrease = tilePowerConsumptionRate * Time.deltaTime * consumptionMultiplier;
        tilePower -= batteryDecrease;

        // Clamp the fuel value to ensure it doesn't go below 0
        tilePower = Mathf.Clamp(tilePower, 0f, 100f);

        // Update the fuel bar slider
        if (tilePowerStatus != null)
        {
            tilePowerStatus.value = tilePower;  // Update the slider value
        }

        // Debug log to track fuel changes
        Debug.Log($"Fuel: {tilePower}, Decreased by: {tilePowerStatus}");
    }
}
