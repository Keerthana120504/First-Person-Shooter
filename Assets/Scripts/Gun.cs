using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Private
    

    // Public
    public float damage = 30f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public Light flickLight;
    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

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



}
