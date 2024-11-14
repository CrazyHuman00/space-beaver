using UnityEngine;

namespace InGame.View
{
    /// <summary>
    /// 背景の動きを制御する。
    /// </summary>
    public class BackGroundView : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed;
        [SerializeField] private float backGroundStartPosition;
        [SerializeField] private float backGroundEndPosition;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector2.up * (scrollSpeed * Time.deltaTime));
            if (!(transform.position.y > backGroundEndPosition)) return;
            var transform1 = transform;
            transform1.position = new Vector2(transform1.position.x, backGroundStartPosition);
        }
    }

}