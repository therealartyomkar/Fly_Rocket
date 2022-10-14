using UnityEngine;

public class Spawnpoints : MonoBehaviour
{
    [SerializeField]public static Vector3 SpawnPosition;
    [SerializeField]private GameObject CanvasDeath;
    [SerializeField]private Transform MenuDeath;

    public void Start()
    {
        CanvasDeath = GameObject.Find("CanvasDeath");
        MenuDeath = CanvasDeath.transform.GetChild(0);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MenuDeath.transform.GetChild(4).gameObject.SetActive(true);
            MenuDeath.transform.GetChild(5).gameObject.SetActive(false);
            SpawnPosition = other.transform.position;
        
        }
    }
}   
