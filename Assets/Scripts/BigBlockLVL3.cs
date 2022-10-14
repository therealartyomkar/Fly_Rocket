using UnityEngine;

public class BigBlockLVL3 : MonoBehaviour
{


    [SerializeField] private GameObject BigBlock;
    [SerializeField] private float speed;
    void Start()
    {
      Instantiate(BigBlock, new Vector3(-130,0,0), Quaternion.identity);
    }
    private void OnCollisionEnter (Collision other)
    {

      print("touch");

    }
}
