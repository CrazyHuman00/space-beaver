using UnityEngine;
using TMPro;


namespace Common.Model
{
    public class PlayerScoreManager : MonoBehaviour
    {
        static public PlayerScoreManager instance { get; private set; }
        private GameObject scoreLabel;
        public int score;

        void Awake()
        {
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

        void Start()
        {
            this.scoreLabel = GameObject.Find("Score");
            UpdateScoreLabel();
        }

        void Update()
        {
            if (scoreLabel == null)
            {
                scoreLabel = GameObject.Find("Score");
            }
            UpdateScoreLabel();
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
            instance = null;
            Destroy(gameObject);
        }

        private void UpdateScoreLabel()
        {
            if (scoreLabel != null)
            {
                scoreLabel.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString("D4");
            }
        }
    }

}