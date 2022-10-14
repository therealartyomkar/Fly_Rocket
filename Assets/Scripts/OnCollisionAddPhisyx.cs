using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAddPhisyx: MonoBehaviour
{

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Untagged") || other.gameObject.CompareTag("Friendly"))
        {
            if (other.gameObject.GetComponent<Rigidbody>() == null)
            {
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().mass = 0.3f;
                other.gameObject.AddComponent<OnCollisionAddPhisyx>();
            }
        }
    }


}
