using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect_ratio : MonoBehaviour
{
    public static Aspect_ratio ratio;

    public GameObject panel_18_9;
    public GameObject panel_16_9;
    public GameObject panel_4_3;

    private void Awake()
    {
        if (ratio == null)
        {
            DontDestroyOnLoad(gameObject);
            ratio = this;
        }
        else if (ratio != this)
        {
            Destroy(gameObject);
        }
    }

    public void On_panel()
    {
        if (Camera.main.aspect >= 2)
        {
            Debug.Log("18:9");
            panel_18_9.SetActive(true);
        }
        else if (Camera.main.aspect >= 1.6)
        {
            Debug.Log("16:9");
            panel_16_9.SetActive(true);
        }
        else
        {
            Debug.Log("4:3");
            panel_4_3.SetActive(true);
        }
    }

}