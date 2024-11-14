using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Common.View
{
    /// <summary>
    /// フェード用の演出。
    /// </summary>
    public class FadeSceneLoader : MonoBehaviour
    {
        public Image fadePanel;             // フェード用のUIパネル（Image）
        public float fadeDuration = 2.0f;   // フェードの完了にかかる時間

        public void CallCoroutine(string sceneName)
        {
            StartCoroutine(FadeOutAndLoadScene(sceneName));
        }

        private IEnumerator FadeOutAndLoadScene(string sceneName)
        {
            fadePanel.enabled = true;                 // パネルを有効化
            var elapsedTime = 0.0f;                 // 経過時間を初期化
            var startColor = fadePanel.color;       // フェードパネルの開始色を取得
            var endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // フェードパネルの最終色を設定

            // フェードアウトアニメーションを実行
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;                        // 経過時間を増やす
                var t = Mathf.Clamp01(elapsedTime / fadeDuration);  // フェードの進行度を計算
                fadePanel.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
                yield return null;                                     // 1フレーム待機
            }

            fadePanel.color = endColor;  // フェードが完了したら最終色に設定
            SceneManager.LoadScene(sceneName); // シーンをロードしてメニューシーンに遷移
        }
    }

}
