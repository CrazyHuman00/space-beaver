using UnityEngine;
using InGame.Controller;
using InGame.Model;
using System.Collections;

namespace Factory
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField] private ItemDatabase itemDatabase;

        private float screenLeftBottom;
        private float screenRightTop;

        void Start()
        {
            CalculateScreenBounds();
            StartCoroutine(GenerateItemsWithRandomInterval());
        }

        private void CalculateScreenBounds()
        {
            screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero).x + 5.0f;
            screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - 5.0f;
        }

        private IEnumerator GenerateItemsWithRandomInterval()
        {
            while (true)
            {
                float randomInterval = Random.Range(1.0f, 2.0f);
                yield return new WaitForSeconds(randomInterval);
                GenerateItem();
            }
        }

        private void GenerateItem()
        {
            if (itemDatabase == null || itemDatabase.items.Count == 0) return;

            int randomIndex = GenerateRandomValue();
            Item randomItem = itemDatabase.items[randomIndex];

            GameObject itemPrefab = Instantiate(randomItem.Prefab, GetRandomSpawnPosition(), Quaternion.identity);
            InitializeItemController(itemPrefab, randomItem);
        }

        private Vector2 GetRandomSpawnPosition()
        {
            float randomX = Random.Range(screenLeftBottom, screenRightTop);
            return new Vector2(randomX, -7f);
        }

        private void InitializeItemController(GameObject itemPrefab, Item randomItem)
        {
            ItemController itemController = itemPrefab.AddComponent<ItemController>();
            itemController.Initialize(randomItem);
            itemController.itemSpeed = 6.0f;
            itemController.itemPrefab = itemPrefab;
        }

        private int GenerateRandomValue()
        {
            int randomValue = Random.Range(0, 10); // 上限値を10に修正
            if (randomValue < 1)
                return 0;
            else if (randomValue < 3)
                return 1;
            else
                return 2;
        }
    }
}