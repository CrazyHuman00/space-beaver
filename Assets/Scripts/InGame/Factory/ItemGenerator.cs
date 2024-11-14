using System.Collections;
using InGame.Controller;
using InGame.Model;
using UnityEngine;

namespace InGame.Factory
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField] private ItemDatabase itemDatabase;

        private float screenLeftBottom;
        private float screenRightTop;

        private void Start()
        {
            CalculateScreenBounds();
            StartCoroutine(GenerateItemsWithRandomInterval());
        }

        private void CalculateScreenBounds()
        {
            if (Camera.main == null) return;
            screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero).x + 5.0f;
            screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - 5.0f;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator GenerateItemsWithRandomInterval()
        {
            while (true)
            {
                var randomInterval = Random.Range(1.0f, 2.0f);
                yield return new WaitForSeconds(randomInterval);
                GenerateItem();
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void GenerateItem()
        {
            if (itemDatabase == null || itemDatabase.items.Count == 0) return;

            var randomIndex = GenerateRandomValue();
            var randomItem = itemDatabase.items[randomIndex];

            var itemPrefab = Instantiate(randomItem.prefab, GetRandomSpawnPosition(), Quaternion.identity);
            InitializeItemController(itemPrefab, randomItem);
        }

        private Vector2 GetRandomSpawnPosition()
        {
            var randomX = Random.Range(screenLeftBottom, screenRightTop);
            return new Vector2(randomX, -7f);
        }

        private static void InitializeItemController(GameObject itemPrefab, Item randomItem)
        {
            var itemController = itemPrefab.AddComponent<ItemController>();
            itemController.Initialize(randomItem);
            itemController.itemSpeed = 6.0f;
            itemController.itemPrefab = itemPrefab;
        }

        private static int GenerateRandomValue()
        {
            var randomValue = Random.Range(0, 10); // 上限値を10に修正
            return randomValue switch
            {
                < 1 => 0,
                < 3 => 1,
                _ => 2
            };
        }
    }
}