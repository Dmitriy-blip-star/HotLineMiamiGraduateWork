using UnityEngine;

namespace Assets.Scripts.AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _shootAudio;

        private AudioSource _audioSource;

        public bool isShoot = false;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _shootAudio;
        }

        public void PlayShootAudio()
        {
            _audioSource.loop = true;
            _audioSource.Play();
            isShoot = true;
        }
        public void StopShootAudio()
        {
            _audioSource.loop = false;
            isShoot = false;
        }
    }
}