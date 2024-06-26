using UnityEngine;

namespace Common.Sound
{
    /// <summary>
    /// ダメージ系のサウンドエフェクトの操作
    /// <summary>
    public class DamagedSoundEffect : MonoBehaviour
    {
        [SerializeField] private AudioClip starSoundEffect;
        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void StarSoundTrigger()
        {
            audioSource.PlayOneShot(starSoundEffect);
        }
    }

}
