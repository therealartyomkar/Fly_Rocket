using UnityEngine;

[DisallowMultipleComponent]
public class moveObject : MonoBehaviour
{
    [SerializeField] private Vector3 movePosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] [Range(0,1)] float moveProgress;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
      startPosition = transform.position;
     
        
    }

    // Update is called once per frame
    private void Update()
    {
      PingPong();
    }

    public void PingPong()
    {
      moveProgress = Mathf.PingPong(Time.time*moveSpeed,1);
      Vector3 offset = movePosition * moveProgress;
      transform.position = startPosition + offset;
    }
}