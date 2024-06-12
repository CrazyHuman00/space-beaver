using UnityEngine;
using TMPro;


namespace InGame.Model
{
    public class PlayerScoreManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI debugText;
        public int score = 0;

        void Start()
        {
            this.score = 0;
        }

        void Update()
        {
            debugText.text = score.ToString();
        }

        public void AddScore(int points)
        {
            score += points;
            Debug.Log("Score: " + score);
        }
    }

}