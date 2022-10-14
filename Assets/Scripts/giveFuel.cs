using UnityEngine;

public class giveFuel : MonoBehaviour
{
    private rocket variable;

    void Awake()
    {
        variable = GameObject.Find("Rocket").GetComponent<rocket>();
        variable.fuelSize = 1000;
    }

}
