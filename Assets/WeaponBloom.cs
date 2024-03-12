using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBloom : MonoBehaviour
{
    [SerializeField] public float defaultBloomAngle = 3;
    [SerializeField] public float walkBloomMultiplier = 1.5f;
    [SerializeField] public float crouchBloomMultiplier = 0.5f;
    [SerializeField] public float sprintBloomMultiplier = 2f;
    [SerializeField] public float adsBloomMultiplier = 0.5f;

    MovementStateManager movement;
    AimStateManager aiming;

    float currentBloom;

    void Start()
    {
        movement = GetComponentInParent<MovementStateManager>();
        aiming= GetComponentInParent<AimStateManager>();
    }

    public Vector3 BloomAngle (Transform barrelPos)
    {
        if (movement.currentState == movement.Idle) currentBloom = defaultBloomAngle;
        else if (movement.currentState == movement.Walk) currentBloom = defaultBloomAngle*walkBloomMultiplier;
        else if (movement.currentState== movement.Run) currentBloom=defaultBloomAngle*sprintBloomMultiplier;
        else if (movement.currentState == movement.Crouch)
        {
            if (movement.dir.magnitude == 0) currentBloom = defaultBloomAngle * crouchBloomMultiplier;
            else currentBloom = defaultBloomAngle*crouchBloomMultiplier*walkBloomMultiplier;
        }

        if (aiming.currentState == aiming.Aim) currentBloom *= adsBloomMultiplier;
        float randX = Random.Range(-currentBloom, currentBloom);
        float randY = Random.Range(-currentBloom, currentBloom);
        float randZ = Random.Range(-currentBloom, currentBloom);

        Vector3 randomRotation = new Vector3(randX, randY, randZ);
        return barrelPos.localEulerAngles + randomRotation;
    }

   
}
