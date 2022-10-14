using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMusicValue : MonoBehaviour
{
    public static int MusicValue;
    [SerializeField] private string _createdTag;
    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(_createdTag);
        if (MusicValue >= 1) //проверка на дублирование донтдестройонлоад
        {
            Destroy(obj);
        }
    }
}
