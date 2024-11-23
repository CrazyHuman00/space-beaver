using UnityEngine;

namespace InGame.Timer
{
    /// <summary>
    /// 時間管理。
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance { get; } = new();
        private float elapsedTime;
        private bool isRunning = false;

        private void Start()
        {
            elapsedTime = 0.0f;
            isRunning = true;
        }

        public float GetElapsedTime()
        {
            return isRunning ? elapsedTime : 0f;
        }

        private void Update()
        {
            elapsedTime += Time.deltaTime;
        }
    }

}