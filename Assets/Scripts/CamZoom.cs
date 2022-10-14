using Cinemachine;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private GameObject camObj;
    [SerializeField] private float speed;
    [SerializeField] private float CamDistance;
    [SerializeField] private float FOV;
    
    private void Start()
    {
        
        FOV = camObj.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;
        //CamDistance = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance;
        //FOV = m_Lens.FieldOfView;
    }
    private void Update()
    {
        
        if (speed >= 10 && speed <=30) 
        {
          FOV += 5f * Time.deltaTime;
        
        }
        else if (speed <=10 && FOV > 60f) 
        {
            FOV -= 5f * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        speed = rigidbody.velocity.magnitude;     
    }




}
