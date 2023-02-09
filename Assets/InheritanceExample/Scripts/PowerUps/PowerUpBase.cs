using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public abstract class PowerUpBase : MonoBehaviour
{

    [SerializeField] protected float powerUpDuration = 3f;
    private float powerUpTimer;
    //[SerializeField] private AudioClip _hitSound;

    protected Collider C { get; private set; }
    protected MeshRenderer MR { get; private set; }


    private void Awake()
    {
        C = GetComponent<Collider>();
        MR = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        if (powerUpTimer > 0)
        {
            powerUpTimer -= Time.deltaTime;
            if (powerUpTimer <= 0)
            {
                PowerDown();
                Destroy(this);
            }
        }

    }

    protected virtual void OnHit()
    {
        C.enabled = false;
        MR.enabled = false;
        powerUpTimer = powerUpDuration;
        PowerUp();
    }

    protected abstract void PowerUp();

    protected abstract void PowerDown();

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            //AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
        }
    }

}
