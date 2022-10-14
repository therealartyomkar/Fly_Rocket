using UnityEngine;

public class fallTrigger : MonoBehaviour
{
    Rigidbody myRigidbody;
    public GameObject fallBlock;
    private void Start()
    {
       myRigidbody = fallBlock.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
        {
            myRigidbody.useGravity = true;
        }
    }
}
