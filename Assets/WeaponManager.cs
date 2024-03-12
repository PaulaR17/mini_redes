using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header ("Fire Rate")]
    [SerializeField] float fireRate;
    float fireRateTimer;
    [SerializeField] bool semiAuto;

    [Header("Bullet Propieties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
    AimStateManager aim;
    public float damage = 20;

    [SerializeField] AudioClip gunshot;
    AudioSource audioSource;
    WeaponAmmo ammo;
    WeaponBloom bloom;
    ActionStateManager actions;
    WeaponRecoil recoil;

    Light muzzleFlashLight;
    ParticleSystem muzzleFlashParticles;
    float lightIntensity;
    [SerializeField] float lightReturnSpeed = 20;
    void Start()
    {
        recoil=GetComponent<WeaponRecoil>();
        //audioSource.GetComponent<AudioSource>();
        aim = GetComponentInParent<AimStateManager>();
        fireRateTimer = fireRate;
        ammo= GetComponentInParent<WeaponAmmo>();
        bloom = GetComponentInParent<WeaponBloom>();
        actions = GetComponentInParent<ActionStateManager>();
        muzzleFlashLight = GetComponentInChildren<Light>();
        muzzleFlashParticles = GetComponentInChildren<ParticleSystem>();
        lightIntensity=muzzleFlashLight.intensity;
        muzzleFlashLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldFire()) Fire();
        muzzleFlashLight.intensity = Mathf.Lerp(muzzleFlashLight.intensity, 0, lightReturnSpeed * Time.deltaTime);
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) return false;
        if (ammo.currentAmmo == 0) return false;
        if (actions.currentstate == actions.Reload) return false;
        if (semiAuto&& Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if (!semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        barrelPos.LookAt(aim.aimPos);
        barrelPos.localEulerAngles = bloom.BloomAngle(barrelPos);
        //audioSource.PlayOneShot(gunshot);
        recoil.TriggerRecoil();
        //TriggerMuzzleFlash();
        ammo.currentAmmo--;
        for(int i = 0; i < bulletsPerShot; i++)
        {
            GameObject currentByllet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);

            Bullet bulletScript = currentByllet.GetComponent<Bullet>();
            bulletScript.weapon = this;

            Rigidbody rb= currentByllet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        }

    }

    void TriggerMuzzleFlash()
    {
        muzzleFlashParticles.Play();
        muzzleFlashLight.intensity = lightIntensity;
    }
}
