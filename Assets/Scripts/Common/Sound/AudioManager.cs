using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Sound
{
    /// <summary>
    /// オーディオボリュームを保持するクラス
    /// <summary>
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        public static AudioManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                // シーンが変更されたときにOnSceneLoadedメソッドを呼び出すように設定
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // シーンが変更されたときに呼び出されるメソッド
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name.Equals(sceneName))
            {
                Destroy(gameObject);
            }
        }

        private void StopBGM()
        {
            // ここにBGMを停止するコードを追加する
        }

        private void OnDestroy()
        {
            // シーンが変更されたときのイベント登録を解除
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}