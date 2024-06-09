using System.Collections;
using UnityEngine;

using Common.Model;

/// <summary>
/// 中央からの星の移動を制御するクラス
/// <summary>
namespace InGame.Controller
{
    public class CenterStarController : MonoBehaviour
    {
        [SerializeField] private float starSpeed;
        [SerializeField] private float rotSpeed;
        [SerializeField] private float startStarPositionY;
        [SerializeField] private float endStarPositionY;
        [SerializeField] private float spanDelay;
        [SerializeField] private float startTime;
        private float starPositionX;
        private float screenLeftBottom; // modelに移動
        private float screenRightTop; // modelに移動
        private bool isSpanning = false;
        private bool isActive = false;

        void Start()
        {
            screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero).x + 5.0f;
            screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - 5.0f;

            // 初期のx座標をランダムに設定
            starPositionX = Random.Range(screenLeftBottom, screenRightTop);
            transform.position = new Vector2(starPositionX, startStarPositionY);

            // 開始時間を決める
            StartCoroutine(ActivateAfterDelay(startTime));
        }

        void Update()
        {
            if (isActive && !isSpanning)
            {
                transform.Translate(0, starSpeed * Time.deltaTime, 0, Space.World);
                transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

                if (transform.position.y > endStarPositionY)
                {
                    StartCoroutine(SpanStar());
                }
            }
        }

        private IEnumerator SpanStar()
        {
            isSpanning = true;
            yield return new WaitForSeconds(spanDelay);

            starPositionX = Random.Range(screenLeftBottom, screenRightTop);
            transform.position = new Vector2(starPositionX, startStarPositionY);
            starSpeed += 0.1f * Random.value;

            isSpanning = false;
        }

        private IEnumerator ActivateAfterDelay(float delay)
        {
            yield return StartCoroutine(StarWaitTime.WaitForSecondsCoroutine(delay));
            isActive = true;
        }
    }
}