using UnityEngine;

public class LaserSwitcher : MonoBehaviour
{
    public GameObject Laser;
    [SerializeField] private float firstTime;
    [SerializeField] private float repeatRate;
    [SerializeField] private float LaserOffTime;

    private void Start()
    {
        InvokeRepeating("LaserOn", firstTime, repeatRate);
    }

    private void LaserOn()
    {
        Laser.SetActive(true);
        Invoke("LaserOff", LaserOffTime);
    }

    private void LaserOff()
    {
        Laser.SetActive(false);
    }
}
