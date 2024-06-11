using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InGame.Model;

/// <summary>
/// 右からの星の移動を制御するクラス
/// <summary>
namespace InGame.Controller
{
    public class RightStarController : MonoBehaviour
    {
        [SerializeField] private float starSpeed;
        [SerializeField] private float rotSpeed;
        [SerializeField] private float startStarPositionX;
        [SerializeField] private float endStarPositionX;
        [SerializeField] private float endStarPositionY;
        [SerializeField] private float spanDelay;
        [SerializeField] private float startTime;
        [SerializeField] private float stopStartTime = 10f;
        private float starPositionY;
        private float screenLeftBottom; // modelに移動
        private bool isSpanning = false;
        private bool isActive = false;
        private float starSpeedY;
        private TimeManager timeManager;


        void Start()
        {
            // 時間の取得
            timeManager = GameObject.Find("Timer").GetComponent<TimeManager>();

            screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero).y;

            // 初期のy座標をランダムに設定
            starPositionY = Random.Range(screenLeftBottom - 5.0f, 0);
            transform.position = new Vector2(startStarPositionX, starPositionY);

            // 開始時間を決める
            StartCoroutine(ActivateAfterDelay(startTime));
        }


        void Update()
        {

            if (isActive && !isSpanning)
            {
                transform.Translate(-starSpeed * Time.deltaTime, starSpeedY * Time.deltaTime, 0, Space.World);
                transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

                if (transform.position.x < endStarPositionX || transform.position.y > endStarPositionY)
                {
                    StartCoroutine(SpanStar());
                }
            }
        }

        private IEnumerator SpanStar()
        {
            isSpanning = true;
            yield return StartCoroutine(StarWaitTime.WaitForSecondsCoroutine(spanDelay));

            starPositionY = Random.Range(screenLeftBottom, 0);
            transform.position = new Vector2(startStarPositionX, starPositionY);
            starSpeed += 0.1f * Random.value;
            starSpeedY = Random.Range(0, 3f);

            // 決められた時間に動かしたり、止めたりする
            float elapsedTime = timeManager.GetElapsedTime();
            
            if (elapsedTime >= stopStartTime)
            {
                isActive = false;
            }

            isSpanning = false;
        }

        private IEnumerator ActivateAfterDelay(float delay)
        {
            yield return StartCoroutine(StarWaitTime.WaitForSecondsCoroutine(delay));
            isActive = true;
        }
    }

}