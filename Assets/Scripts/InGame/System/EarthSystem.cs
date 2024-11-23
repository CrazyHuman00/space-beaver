using InGame.Timer;
using UnityEngine;

namespace InGame.System
{
    /// <summary>
    /// 地球を動かす。
    /// </summary>
    public class EarthSystem : MonoBehaviour
    {
        [SerializeField] private float startTime;
        [SerializeField] private float earthSpeed;
        private TimeManager timeManager;

        private void Start()
        {
            timeManager = GameObject.Find("Timer").GetComponent<TimeManager>();
        }

        private void Update()
        {
            if (timeManager.GetElapsedTime() > startTime)
            {
                transform.Translate(0, earthSpeed * Time.deltaTime, 0, Space.World);
            }
        }
    }

}