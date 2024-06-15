using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common.View;

namespace Explain
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private FadeSceneLoader fadeSceneLoader;

        void Start()
        {
            fadeSceneLoader = GameObject.Find("Canvas").GetComponent<FadeSceneLoader>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                fadeSceneLoader.CallCoroutine(sceneName);
            }
        }
    }
}