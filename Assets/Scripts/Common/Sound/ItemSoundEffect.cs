using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Common.Sound
{
    /// <summary>
    /// アイテム系のサウンドエフェクトの操作
    /// <summary>
    public class ItemSoundEffect : MonoBehaviour
    {
        [SerializeField] private AudioClip[] itemSoundEffect = new AudioClip[3];
        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void SawaganiSoundTrigger()
        {
            audioSource.PlayOneShot(itemSoundEffect[0]);
        }

        public void KoyadofuSoundTrigger()
        {
            audioSource.PlayOneShot(itemSoundEffect[1]);
        }

        public void WoodSoundTrigger()
        {
            audioSource.PlayOneShot(itemSoundEffect[2]);
        }
    }
}