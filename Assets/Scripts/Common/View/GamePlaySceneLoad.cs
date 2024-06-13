using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.View
{
    public class GamePlaySceneLoad : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private FadeSceneLoader fadeSceneLoader;

        void Start()
        {
            fadeSceneLoader = GameObject.Find("Canvas").GetComponent<FadeSceneLoader>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fadeSceneLoader.CallCoroutine(sceneName);
            }
        }
    }
}