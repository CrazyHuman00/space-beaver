using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Model
{
    public class TimeManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log ("経過時間(秒)" + Time.time);
        }
    }

}