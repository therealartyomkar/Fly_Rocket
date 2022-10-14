using UnityEngine;

public class LateEnable : MonoBehaviour
{
    public GameObject lCollider;
    public float invokeTime;
    private void Awake()
    {
        lCollider.SetActive(false);
    }
    void Start()
    {
        Invoke("Enable", invokeTime);
    }

    void Enable()
    {
        lCollider.SetActive(true);
    }
}
