using UnityEngine;
using InGame.Model;

namespace InGame.Controller
{
    /// <summary>
    /// プレイヤーの動きを制御するクラス
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        [SerializeField] private float inside;
        [SerializeField] private float stopTime;
        private Vector2 screenLeftBottom; // modelに移動
        private Vector2 screenRightTop; // modelに移動
        private Vector2 newPosition;
        private TimeManager timeManager;
        private bool stopFlag = true;

        private void Start()
        {
            if (Camera.main != null)
            {
                screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
                screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            }

            timeManager = GameObject.Find("Timer").GetComponent<TimeManager>();
        }


        private void Update()
        {
            StopMove();

            if (!stopFlag) return;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                var transform1 = transform;
                transform1.position += transform1.up * (playerSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                var transform1 = transform;
                transform1.position -= transform1.up * (playerSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                var transform1 = transform;
                transform1.position += transform1.right * (playerSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                var transform1 = transform;
                transform1.position -= transform1.right * (playerSpeed * Time.deltaTime);
            }

            var position = transform.position;
            newPosition.x = Mathf.Clamp(position.x, screenLeftBottom.x + inside, screenRightTop.x - inside);
            newPosition.y = Mathf.Clamp(position.y, screenLeftBottom.y + inside, screenRightTop.y - inside);

            position = newPosition;
            transform.position = position;
        }

        private void StopMove()
        {
            var elapsedTime = timeManager.GetElapsedTime();
            if (elapsedTime > stopTime)
            {
                stopFlag = false;
            }
        }
    }

}