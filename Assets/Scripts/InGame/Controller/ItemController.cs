using UnityEngine;

using InGame.Model;

namespace InGame.Controller
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField] public float itemSpeed;
        public GameObject itemPrefab;
        private Item itemData;

        void Update()
        {
            transform.Translate(0, itemSpeed * Time.deltaTime, 0, Space.World);

            if (transform.position.y > 7.0f)
            {
                Destroy(itemPrefab);
            }
        }

        public void SetItemData(Item data)
        {
            itemData = data;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerScoreManager playerScoreManager = other.gameObject.GetComponent<PlayerScoreManager>();
                if (playerScoreManager != null && itemData != null)
                {
                    playerScoreManager.AddScore(itemData.Point);
                    Destroy(gameObject);
                }
            }
        }

    }
}