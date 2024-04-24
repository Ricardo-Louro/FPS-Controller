using Unity.VisualScripting;
using UnityEngine;

public class Pistol : Weapon
{
    [Header("Raycast Ignore Collision")]
    [SerializeField] private LayerMask      layerMask;

    [Header("Values")]
    [SerializeField] private int MaxAmmo;
    [SerializeField] private float ShotCooldown;

    public override int                     maxAmmo { get; protected set; }
    public override int                     currentAmmo { get; protected set; }
    public override float                   shotCooldown { get; protected set; }
    public override float                   lastTimeShot { get; protected set; }
    public override int                     damage { get; protected set; } = 1;
    public override FiringType              firingType { get; protected set; } = FiringType.SemiAuto;

    private  new ParticleSystem             particleSystem;

    [Header("Audio Sources")]    
    [SerializeField] private AudioSource    noAmmo;
    [SerializeField] private AudioSource    gunshotSound1;
    [SerializeField] private AudioSource    gunshotSound2;

    private new void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();

        maxAmmo = MaxAmmo;
        shotCooldown = ShotCooldown;

        base.Start();
    }

    public override void TryFire()
    {
        if(Time.time - lastTimeShot  >= shotCooldown)
        {
            if (currentAmmo >= 1)
            {
                SuccessfulShot();
            }
            else
            {
                NotEnoughAmmo();
            }
        }
        else
        {
            NotInCooldown();
        }
    }

    private void SuccessfulShot()
    {
        SubtractAmmo(1);

        particleSystem.Play();

        AudioSource audioSource;
        if(gunshotSound1.isPlaying)
        {
            if (gunshotSound2.isPlaying)
            {
                audioSource = gunshotSound1;
            }
            else
            {
                audioSource= gunshotSound2;
            }
        }
        else
        {
            audioSource = gunshotSound1;
        }

        audioSource.pitch = Random.Range(.6f, 1f);
        audioSource.Play();
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        lastTimeShot = Time.time;
    }

    private void NotEnoughAmmo()
    {
        if (!noAmmo.isPlaying)
        {
            noAmmo.pitch = Random.Range(.8f, 1f);
            noAmmo.Play();
        }
    }

    private void NotInCooldown()
    {
        //Don't do anything for now
    }

    private void SubtractAmmo(int value)
    {
        currentAmmo -= value;
    }

    private void AddAmmo(int value)
    {
        currentAmmo += value;
    }
}
