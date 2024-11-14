using UnityEngine;
using InGame.Model;

namespace InGame.Controller
{
    /// <summary>
    /// 地球を動かす。
    /// </summary>
    public class EarthController : MonoBehaviour
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