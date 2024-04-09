using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerMovement playerMov;

    // Start is called before the first frame update
    private void Start()
    {
        playerMov = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer is 3)
        {
            playerMov.SetGrounded(true);
        }
    }
}