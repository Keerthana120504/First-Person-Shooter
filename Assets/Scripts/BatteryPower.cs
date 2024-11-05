using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    // Private
    float fullBatteryTimeInSeconds = 100f; // 5 seconds for full battery time
    float batteryConsumptionRate;  // battery consumption rate per second
    float consumptionMultiplier = 4f; // Increase this factor to consume battery faster

    // Public
    public Slider batteryStatus;

    public float batteryPower = 100f;
    public float batteryFull = 100f;
    public float batteryOut = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        // Calculate battery consumption rate: 100% battery over 5 seconds
        batteryConsumptionRate = 100f / fullBatteryTimeInSeconds; // This gives us a consumption rate of 20 units per second.

        if (batteryStatus != null)
        {
            batteryStatus.maxValue = batteryFull;
            batteryStatus.minValue = batteryOut;
            batteryStatus.value = batteryPower;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BatteryConsumption();
    }


    public void BatteryPicked()
    {
        batteryPower = batteryFull;
        
    }

    void BatteryConsumption()
    {
        // Decrease fuel based on the fuel consumption rate and the consumption multiplier
        float batteryDecrease = batteryConsumptionRate * Time.deltaTime * consumptionMultiplier;
        batteryPower -= batteryDecrease;

        // Clamp the fuel value to ensure it doesn't go below 0
        batteryPower = Mathf.Clamp(batteryPower, 0f, 100f);

        // Update the fuel bar slider
        if (batteryStatus != null)
        {
            batteryStatus.value = batteryPower;  // Update the slider value
        }

        // Debug log to track fuel changes
        Debug.Log($"Fuel: {batteryPower}, Decreased by: {batteryStatus}");
    }
}
