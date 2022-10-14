using UnityEngine;

public class Move_Rb_Object : MonoBehaviour
{
    private Rigidbody rb;
    private float moveAmount;
    [SerializeField] private float targetPositionX;
    [SerializeField] private float startPosition;
    [SerializeField] private float backSpeed = -0.1f;
    [SerializeField] private float startSpeed = 0.08f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 newPosition = transform.position + (new Vector3(moveAmount, 0, 0));
        rb.MovePosition(newPosition);
    }
    private void Update()
    {
        if (transform.localPosition.x >= targetPositionX)
        {
            moveAmount = backSpeed;
        }
        else if (transform.localPosition.x <= startPosition) 
        {
            moveAmount = startSpeed;
        }
    }

}
