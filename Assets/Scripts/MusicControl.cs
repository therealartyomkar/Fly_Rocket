using UnityEngine;
public class MusicControl : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    private bool HaveAudio;
    public AudioClip [] audioClips;
    private AudioClip shutClip;

    void Awake()
    {
        ChangeAudio();
        _audio.Play();
        if (HaveAudio != false)
        {
            Destroy(gameObject);
        }
        else
        {
            HaveAudio = true;
            DontDestroyOnLoad(gameObject);
            CheckMusicValue.MusicValue += 1;
        }
    }

    private void Update()
    {
        if (!_audio.isPlaying & PauseMenu.GameIsPaused == false)
        {
            ChangeAudio();
            _audio.Play();
        }
    }
    private void ChangeAudio()
    {
        int AudioClipsIndex = Random.Range(0, audioClips.Length);
        shutClip = audioClips[AudioClipsIndex];
        _audio.clip = shutClip;
    }
    
}
