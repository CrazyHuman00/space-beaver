using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    /// <summary>
    /// ダメージ系のサウンドエフェクトの操作
    /// <summary>
    public class BGMSound : MonoBehaviour
    {
        [SerializeField] private AudioClip bgmSound;
        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void StarSoundTrigger()
        {
            audioSource.PlayOneShot(bgmSound);
        }
    }
}