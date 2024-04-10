using Unity.VisualScripting;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private LayerMask      layerMask;
    public override int                     maxAmmo { get; protected set; } = 100;
    public override int                     currentAmmo { get; protected set; }
    public override float                   shotCooldown { get; protected set; } = 1f;
    public override float                   lastTimeShot { get; protected set; }
    public override int                     damage { get; protected set; } = 1;
    public override FiringType              firingType { get; protected set; } = FiringType.SemiAuto;

    private ParticleSystem                  particleSystem;
    private AudioSource                     audioSource;

    private void Start()
    {
        base.Start();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public override void TryFire()
    {
        if(Time.time - lastTimeShot  >= shotCooldown && currentAmmo >= 1)
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
        //PLAY THE SOUND
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
