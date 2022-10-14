using UnityEngine;

public class DestroyTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject Laser;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.LaserTriggerEnter();
    }

}
