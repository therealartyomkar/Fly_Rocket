using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpToTheObject : MonoBehaviour
{
    [SerializeField] private Transform TpPoint;
    [SerializeField] private Vector3 Offset;
    private Vector3 SpawnPosition;
    private void Start()
    {
        SpawnPosition = TpPoint.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = SpawnPosition + Offset;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
        }


    }
}