using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private AudioSource Music;
    [SerializeField] public static bool GameIsPaused = false;
    [SerializeField] private GameObject [] pauseMenuUI;
    [SerializeField] private AudioMixerGroup Mixer;
    [SerializeField] private GameObject buttonBoost;
    [SerializeField] private GameObject buttonRot;
    [SerializeField] private GameObject canvasFuel;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject restartButton;

    public enum State { Playing, Dead, NextLevel, NoFuel, Pause };
    State state = State.Playing;
    private void Start()
    {
        Music = GameObject.Find("Music").GetComponent<AudioSource>();
        GameIsPaused = false;
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused == true)
                {
                    Resume();

                }
                else if(GameIsPaused == false)
                {
                    Pause();

                }
            }
        }
    }
   public void Resume()
    {
        for (int i = 0; i < pauseMenuUI.Length; i++)
        {       
                pauseMenuUI[i].SetActive(false);
        }
        Time.timeScale = 1;
        GameIsPaused = false;
        //AudioListener.pause = false;
        buttonBoost.SetActive(true);
        buttonRot.SetActive(true);
        canvasFuel.SetActive(true);
        settingsButton.SetActive(true);
        restartButton.SetActive(true);
    }
   public void Pause()
    {
        state = State.Pause;
        Music.Stop();
        pauseMenuUI[0].SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        //AudioListener.pause = true;
        buttonBoost.SetActive(false);
        buttonRot.SetActive(false);
        canvasFuel.SetActive(false);
        settingsButton.SetActive(false);
        restartButton.SetActive(false);
    } 

    public void Quit()
    {
        Application.Quit();
    }

    public void OffVolume() 
    {
        AudioListener.volume = 0;
        
    }
    public void OnVolume()
    {
        AudioListener.volume = 1;

    }
    public void SetQuality(int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }
}
