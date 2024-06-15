using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common.View;

namespace GameOver
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private float delayBeforeSwitch = 3.0f;
        private FadeSceneLoader fadeSceneLoader;

        void Start()
        {
            fadeSceneLoader = GameObject.Find("Canvas").GetComponent<FadeSceneLoader>();
            StartCoroutine(SwitchSceneAfterDelay());
        }

        private IEnumerator SwitchSceneAfterDelay()
        {
            yield return new WaitForSeconds(delayBeforeSwitch);
            fadeSceneLoader.CallCoroutine(sceneName);
        }
    }
}