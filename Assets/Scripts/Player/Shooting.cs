using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Weapon heldWeapon;

    // Start is called before the first frame update
    private void Start()
    {
        heldWeapon = FindObjectOfType<Weapon>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(heldWeapon != null)
        {
            if(heldWeapon.firingType == FiringType.Automatic)
            {
                if(Input.GetKey(KeyCode.Mouse0))
                {
                    heldWeapon.TryFire();
                }
            }
            else if(heldWeapon.firingType == FiringType.SemiAuto)
            {
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    heldWeapon.TryFire();
                }
            }
        }
    }
}
