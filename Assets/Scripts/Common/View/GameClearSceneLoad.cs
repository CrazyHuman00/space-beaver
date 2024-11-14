using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.View
{
    public class GameClearSceneLoad : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private FadeSceneLoader fadeSceneLoader;
        private AudioSource bgmSource;
        private bool isbgmSourceNull;

        private void Start()
        {
            isbgmSourceNull = bgmSource == null;
            fadeSceneLoader = GameObject.Find("Canvas").GetComponent<FadeSceneLoader>();
            bgmSource = GameObject.Find("InGameBGM").GetComponent<AudioSource>();
        }


        private void Update()
        {
            if (isbgmSourceNull || bgmSource.isPlaying) return;
            fadeSceneLoader.fadeDuration = 3.0f;
            fadeSceneLoader.CallCoroutine(sceneName);
        }
    }
}