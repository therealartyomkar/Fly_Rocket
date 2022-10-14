using UnityEngine;

public class FuelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
    }






}
