using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Plugins.ButtonSoundsEditor
{
    public class ButtonClickSound : MonoBehaviour, IPointerClickHandler
    {
        public AudioSource AudioSource;
        public AudioClip ClickSound;


        private void Start()
        {
            AudioSource = GameObject.Find("ButtonsAudioSource").GetComponent<AudioSource>();
            if(AudioSource == null) 
            {
                Debug.LogError("а вот нету аудиосоурса на батон скриптах");
            }
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            PlayClickSound();
        }

        private void PlayClickSound()
        {
            AudioSource.PlayOneShot(ClickSound);
        }
    }

}
