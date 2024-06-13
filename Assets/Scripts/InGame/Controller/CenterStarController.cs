using System.Collections;
using UnityEngine;

using InGame.Model;

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
        [SerializeField] private float stopStartTime = 10f; // 停止を開始する時間
        [SerializeField] private float restartDelay = 5f;

        private float starPositionX;
        private float screenLeftBottom;
        private float screenRightTop;
        private bool isSpanning = false;
        private bool isActive = false;
        private bool isStopped = false;

        private TimeManager timeManager;

        void Start()
        {
            Initialize();
            StartCoroutine(ActivateAfterDelay(startTime));
        }

        void Update()
        {
            if (isActive && !isSpanning)
            {
                MoveStar();
                CheckStarPosition();
            }
        }

        private void Initialize()
        {
            timeManager = GameObject.Find("Timer").GetComponent<TimeManager>();
            CalculateScreenBounds();
            SetInitialStarPosition();
        }

        private void CalculateScreenBounds()
        {
            screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero).x + 5.0f;
            screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - 5.0f;
        }

        private void SetInitialStarPosition()
        {
            starPositionX = Random.Range(screenLeftBottom, screenRightTop);
            transform.position = new Vector2(starPositionX, startStarPositionY);
        }

        private void MoveStar()
        {
            transform.Translate(0, starSpeed * Time.deltaTime, 0, Space.World);
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
        }

        private void CheckStarPosition()
        {
            if (transform.position.y > endStarPositionY)
            {
                StartCoroutine(SpanStar());
            }
        }

        private IEnumerator SpanStar()
        {
            isSpanning = true;
            yield return new WaitForSeconds(spanDelay);

            SetRandomStarPosition();
            IncreaseStarSpeed();

            yield return HandleStarStopAndRestart();

            isSpanning = false;
        }

        private void SetRandomStarPosition()
        {
            starPositionX = Random.Range(screenLeftBottom, screenRightTop);
            transform.position = new Vector2(starPositionX, startStarPositionY);
        }

        private void IncreaseStarSpeed()
        {
            starSpeed += 0.1f * Random.value;
        }

        private IEnumerator HandleStarStopAndRestart()
        {
            float elapsedTime = timeManager.GetElapsedTime();

            if (elapsedTime >= stopStartTime && !isStopped)
            {
                isActive = false;
                isStopped = true;
                yield return new WaitForSeconds(restartDelay); // 再開までの遅延
                isActive = true;
            }
        }

        private IEnumerator ActivateAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            isActive = true;
        }
    }
}
