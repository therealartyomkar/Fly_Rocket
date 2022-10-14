using UnityEngine;

public class BlockRotScript : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotSpeed);
    }
}
