using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Private
    AudioManager audioManager;
    [SerializeField]Gun gunScript;
    [SerializeField] FinishMenu finishMenu;

    // Public

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Ammo":
                audioManager.PlaySFX(audioManager.AmmoPickup);
                gunScript.AmmoPicked();
                Destroy(other.gameObject);
                break;
            case "Finish":
                audioManager.PlaySFX(audioManager.wellDone);
                Invoke("DelayedToggleFinish", 2f);
                break;

            default:
                break;
        }

    }
    // Delay finish menu
    void DelayedToggleFinish()
    {
        finishMenu.ToggleFinish();
    }
}
