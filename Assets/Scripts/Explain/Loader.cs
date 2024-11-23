using UnityEngine;

using Common.View;

namespace Explain
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private FadeSceneLoader fadeSceneLoader;

        private void Start()
        {
            fadeSceneLoader = GameObject.Find("Canvas").GetComponent<FadeSceneLoader>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                fadeSceneLoader.CallCoroutine(sceneName);
            }
        }
    }
}