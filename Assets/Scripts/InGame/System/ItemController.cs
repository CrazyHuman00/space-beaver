using UnityEngine;

using Common.Model;
using InGame.Model;

namespace InGame.Controller
{
    /// <summary>
    /// アイテムの動き。
    /// </summary>
    public class ItemController : MonoBehaviour
    {
        [SerializeField] public float itemSpeed;
        public GameObject itemPrefab;
        private Item itemData;


        public void Initialize(Item data)
        {
            itemData = data;
        }

        private void Update()
        {
            transform.Translate(0, itemSpeed * Time.deltaTime, 0, Space.World);

            if (transform.position.y > 7.0f)
            {
                Destroy(itemPrefab);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var playerScoreManager = GameObject.Find("ScoreManager").GetComponent<PlayerScoreManager>();

            if (playerScoreManager == null || itemData == null) return;
            playerScoreManager.AddScore(itemData.point);
            Destroy(gameObject);
        }

    }
}