using UnityEngine;

public class ComponentEnabler : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Target.SetActive(true);
        }


    }
}
