using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame.Model;

namespace InGame.Controller
{
    public class EarthController : MonoBehaviour
    {
        [SerializeField] private float startTime;
        [SerializeField] private float earthSpeed;
        private TimeManager timeManager;

        void Start()
        {
            timeManager = GameObject.Find("Timer").GetComponent<TimeManager>();
        }

        void Update()
        {
            if (timeManager.GetElapsedTime() > startTime)
            {
                transform.Translate(0, earthSpeed * Time.deltaTime, 0, Space.World);
            }
        }
    }

}