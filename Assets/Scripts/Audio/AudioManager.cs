using UnityEngine;

namespace Assets.Scripts.AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioClip shootAudio;

        AudioSource audioSource;

        public bool isShoot = false;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = shootAudio;
        }

        public void PlayShootAudio()
        {
            audioSource.loop = true;
            audioSource.Play();
            isShoot = true;
        }
        public void StopShootAudio()
        {
            audioSource.loop = false;
            isShoot = false;
        }
    }
}