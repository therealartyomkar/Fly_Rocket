using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(1 * speed * Time.deltaTime, 0, 0);
    }
}
