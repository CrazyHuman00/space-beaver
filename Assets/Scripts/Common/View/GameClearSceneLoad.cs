using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.View
{
    public class GameClearSceneLoad : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private FadeSceneLoader fadeSceneLoader;
        private AudioSource BGMSource;

        void Start()
        {
            fadeSceneLoader = GameObject.Find("Canvas").GetComponent<FadeSceneLoader>();
            BGMSource = GameObject.Find("InGameBGM").GetComponent<AudioSource>();
        }


        void Update()
        {
            if (BGMSource != null && !BGMSource.isPlaying)
            {
                fadeSceneLoader.fadeDuration = 3.0f;
                fadeSceneLoader.CallCoroutine(sceneName);
            }
        }
    }
}