using UnityEngine;
using UnityEngine.SceneManagement;

public class controlButton : MonoBehaviour
{
    public void PlayCurrentLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }
}
