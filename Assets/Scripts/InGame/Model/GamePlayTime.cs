using UnityEngine;
using TMPro;

namespace InGame.Model
{
    public class TimeManager : MonoBehaviour
    {
        private int a;
        public static TimeManager Instance { get; private set; }
        private float elapsedTime;
        private bool isRunning = false;
        

        private void Start()
        {
            elapsedTime = 0.0f;
            isRunning = true;
        }

        public float GetElapsedTime()
        {
            if (isRunning)
            {
                return elapsedTime;
            }
            else
            {
                return 0f;
            }
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;
        }
    }

}