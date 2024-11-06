using UnityEngine;
using System.Collections;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
    public float flickerDuration = 0.5f;  // Duration to run the flicker effect
    public float interval = 0.02f;         // Interval between light toggles
    private Light flickerLight;

    void Start()
    {
        flickerLight = GetComponent<Light>();
        flickerLight.enabled = false;
    }

    public IEnumerator Flicker()
    {
        float elapsed = 0f;

        while (elapsed < flickerDuration)
        {
            // Toggle light on and off
            flickerLight.enabled = !flickerLight.enabled;

            // Wait for the interval duration
            yield return new WaitForSeconds(interval);

            // Update elapsed time
            elapsed += interval;
        }

        // Ensure the light is off after flickering
        flickerLight.enabled = false;
    }
}
