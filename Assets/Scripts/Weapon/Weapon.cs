using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract int                 maxAmmo { get; protected set; }
    public abstract int                 currentAmmo { get; protected set; }
    public abstract float               shotCooldown { get; protected set; }
    public abstract float               lastTimeShot { get; protected set; }
    public abstract int                 damage { get; protected set; }
    public abstract FiringType          firingType { get; protected set; }

    protected void Start()
    {
        currentAmmo = maxAmmo;
        lastTimeShot = 0f;
    }
    public abstract void TryFire();
}