using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActionStateManager : MonoBehaviour
{
    [HideInInspector] public ActionBaseState currentstate;

    public ReloadState Reload = new ReloadState();
    public DefaultState Default = new DefaultState();

    public GameObject currentWeapon;
    [HideInInspector] public WeaponAmmo ammo;
    AudioSource audioSource;

    [HideInInspector] public Animator anim;

    public MultiAimConstraint rHandAim;
    public TwoBoneIKConstraint lHandIK;
    private void Start()
    {
        SwitchState(Default);
        ammo= currentWeapon.GetComponent<WeaponAmmo>();
        anim = GetComponent<Animator>();
        //audioSource = currentWeapon.GetComponent<AudioSource>();
    }

    private void Update()
    {
        currentstate.UpdateState(this);
    }

    public void SwitchState(ActionBaseState state)
    {
        currentstate = state;
        currentstate.EnterState(this);
    }

    public void WeaponReloaded()
    {
        ammo.Reload();
        SwitchState(Default);
    }

    public void MagOut()
    {
        audioSource.PlayOneShot(ammo.magOutSound);
    }
    public void MagIn()
    {
        audioSource.PlayOneShot(ammo.magInSound);

    }
    public void ReleaseSlide()
    {
        audioSource.PlayOneShot(ammo.releaseSlideSound);

    }
}
