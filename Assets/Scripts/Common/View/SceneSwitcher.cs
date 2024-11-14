using UnityEngine;
using Common.Model;


namespace Common.View
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private FadeSceneLoader fadeSceneLoader;

        private void Start()
        {
            fadeSceneLoader = GameObject.Find("Canvas").GetComponent<FadeSceneLoader>();
        }

        public void OnClick()
        {
            fadeSceneLoader.CallCoroutine(sceneName);
        }

        public void Retry()
        {
            if (PlayerScoreManager.instance != null)
            {
                PlayerScoreManager.instance.ResetScoreManager();
            }
            fadeSceneLoader.CallCoroutine(sceneName);
        }
    }
}