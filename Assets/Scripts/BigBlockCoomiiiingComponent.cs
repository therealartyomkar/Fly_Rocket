using UnityEngine;

public class BigBlockCoomiiiingComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 moveUp = transform.position + (new Vector3(0, 1, 0) * speed);
        rb.MovePosition(moveUp);
    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Untagged") || other.gameObject.CompareTag("Friendly")) 
        {
            if (other.gameObject.GetComponent<Rigidbody>() == null)
            {
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                other.gameObject.GetComponent<Rigidbody>().mass = 0.3f;
                other.gameObject.AddComponent<OnCollisionAddPhisyx>();
            }
        }
    }

}
