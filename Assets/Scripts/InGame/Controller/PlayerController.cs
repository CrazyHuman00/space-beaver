using UnityEngine;

/// <summary>
/// プレイヤーの動きを制御するクラス
/// <summary>
namespace InGame.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        [SerializeField] private float inside;
        private Vector2 screenLeftBottom; // modelに移動
        private Vector2 screenRightTop; // modelに移動
        private Vector2 newPosition;
        
        void Start()
        {
            screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
            screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }


        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += playerSpeed * transform.up * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= playerSpeed * transform.up * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += playerSpeed * transform.right * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= playerSpeed * transform.right * Time.deltaTime;
            }

            newPosition.x = Mathf.Clamp(transform.position.x, screenLeftBottom.x + inside, screenRightTop.x - inside);
            newPosition.y = Mathf.Clamp(transform.position.y, screenLeftBottom.y + inside, screenRightTop.y - inside);

            transform.position = newPosition;
        }
    }

}