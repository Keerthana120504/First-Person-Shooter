using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Private
    BatteryPower batteryScript;
    TileStoneScript tileStoneScript;

    // Public
    


    // Start is called before the first frame update
    void Start()
    {
        batteryScript = GetComponent<BatteryPower>();
        tileStoneScript = GetComponent<TileStoneScript>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Battery":
                batteryScript.BatteryPicked();
                break;
            case "TileStone":
                tileStoneScript.TilePicked();
                break;

            default:
                break;
        }

        batteryScript.batteryStatus.value = batteryScript.batteryPower; // Assigning Battery Power to Battery Status
        tileStoneScript.tilePowerStatus.value = tileStoneScript.tilePower; // Assigning Tiles Power to Tiles Status
    }

    
}
