using UnityEngine;

public class LevelIndexSaver : MonoBehaviour
{
     public static int levelIndex;
    [SerializeField] private int lvlID;

    private void Start()
    {
        levelIndex = lvlID;
    }
}
