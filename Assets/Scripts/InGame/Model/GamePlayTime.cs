using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Model
{
    public class TimeManager : MonoBehaviour
    {
        void Update()
        {
            Debug.Log ("経過時間(秒)" + Time.time);
        }
    }

}