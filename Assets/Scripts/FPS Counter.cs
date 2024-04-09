using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private float cooldown;
    private float lastTimeUpdated;
    private TextMeshProUGUI tmp;

    private void Start()
    {
        lastTimeUpdated = 0;
        tmp = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    private void Update()
    {
        if(Time.time - lastTimeUpdated >= cooldown)
        {
            lastTimeUpdated = Time.time;
            tmp.text = "FPS: " + (int)(1 / Time.deltaTime);
        }
    }
}
