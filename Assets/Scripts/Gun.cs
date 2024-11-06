using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Private


    // Public
    [Header("======== Shooting & Damage ========")]
    public float damage = 30f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    [Header("======== Ammunition ========")]
    public int magazine = 30;
    public int amo;
    public int mags = 3;
    public int magazineTemp;

    [Header("======== Others ========")]
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    // WFX_LightFlicker flickLight;
    public GameObject impactEffect;
    public ParticleSystem bulletParticle;
    public WFX_LightFlicker flickLight;

    private float nextTimetoFire = 0f;

    // UI Text elements
    [Header("======== UI Texts ========")]
    [SerializeField] private TextMeshProUGUI magazineText;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI magsText;


    private void Start()
    {
        amo = magazine * mags;
        magazineTemp = magazine;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimetoFire && magazine > 0)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && amo > 0)
        {
            Reload();
        }

        // Update UI initially
        UpdateUI();
    }


    void Shoot()
    {
        muzzleFlash.Play();
        bulletParticle.Play();

        magazine -= 3;

        if (flickLight != null)
        {
            StartCoroutine(flickLight.Flicker()); // Start the coroutine from another script;
        }

        // Raycasting on the Cam Screen
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // If enemy Hiited, the enemy will take damage
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            // Impact Effect
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            if (impactGO != null)
            {
                // Get the Particle System component and force it to play
                ParticleSystem particleSystem = impactGO.GetComponent<ParticleSystem>();

                if (particleSystem != null)
                {
                    particleSystem.Play();
                }
                else
                {
                    // If the impact effect has multiple particle systems (e.g., in children)
                    ParticleSystem[] particleSystems = impactGO.GetComponentsInChildren<ParticleSystem>();
                    foreach (ParticleSystem ps in particleSystems)
                    {
                        ps.Play();
                    }
                }

                // Destroy the effect after 2.5 seconds
                Destroy(impactGO, 2.5f);
            }

        }

    }

    void Reload()
    {
        amo  = amo - 30 + magazine;
        magazine = magazineTemp;
        if (amo > 0)
        {
            magazine += amo;
            amo = 0;
        }
    }

    void UpdateUI()
    {
        // Update text fields with current values
        magazineText.text = $"{magazine}";
        ammoText.text = $"{amo}";
        magsText.text = $"{mags}";
    }

}
