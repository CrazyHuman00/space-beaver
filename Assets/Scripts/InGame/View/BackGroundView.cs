using UnityEngine;

namespace InGame.View
{
    /// <summary>
    /// 背景の動きを制御するプログラム
    ///
    public class BackGroundView : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed;
        [SerializeField] private float backGroundStartPosition;
        [SerializeField] private float backGroundEndPosition;

        void Update()
        {
            Move();
        }

        void Move()
        {
            transform.Translate(Vector2.up * scrollSpeed * Time.deltaTime);
            if (transform.position.y > backGroundEndPosition)
            {
                transform.position = new Vector2(transform.position.x, backGroundStartPosition);
            }
        }
    }

}