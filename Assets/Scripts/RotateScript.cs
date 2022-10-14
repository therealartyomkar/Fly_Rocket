using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] ParticleSystem lRotateParticle;
    [SerializeField] ParticleSystem rRotateParticle;

    bool rotParticle = false;
   
    void Update()
    {
      

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            lRotateParticle.Play();
        }
       

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
         //   rParticle();
        }
    }
}
