using UnityEngine;
using TMPro;
using unityroom.Api;

namespace Common.Model
{
    public class PlayerScoreManager : MonoBehaviour
    {
        public static PlayerScoreManager instance { get; private set; }
        private GameObject scoreLabel;
        public int score;
        private bool isScoreLabelNull;
        private GameObject o;

        private void Awake()
        {
            o = GameObject.Find("Score");
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject); // オブジェクトをシーン切り替え時に破棄しない
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            UpdateScoreLabel();
            isScoreLabelNull = scoreLabel == null;
            this.scoreLabel = GameObject.Find("Score");
            UpdateScoreLabel();
        }

        private void Update()
        {
            if (isScoreLabelNull)
            {
                scoreLabel = o;
            }
        }

        public void AddScore(int points)
        {
            score += points;
            Debug.Log("Score: " + score);
            UpdateScoreLabel();
        }

        public int GetScore()
        {
            return this.score;
        }

        public void ResetScoreManager()
        {
            UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.Always);
            instance = null;
            Destroy(gameObject);
        }

        private void UpdateScoreLabel()
        {
            if (scoreLabel != null)
            {
                scoreLabel.GetComponent<TextMeshProUGUI>().text =  score.ToString();
            }
        }
    }

}