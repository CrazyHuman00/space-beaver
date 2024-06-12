using UnityEngine;
using UnityEngine.Audio;

using Common.Sound;
using InGame.Model;

namespace InGame.Controller
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField] public float itemSpeed;
        public GameObject itemPrefab;
        private Item itemData;


        public void Initialize(Item data)
        {
            itemData = data;
        }

        void Update()
        {
            transform.Translate(0, itemSpeed * Time.deltaTime, 0, Space.World);

            if (transform.position.y > 7.0f)
            {
                Destroy(itemPrefab);
            }
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