using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public event Action onLaserTriggerEnter;
    private void Awake()
    {
        current = this;
    }
    
    public void LaserTriggerEnter()
    {
        onLaserTriggerEnter?.Invoke();
    }

}
