using UnityEngine;

using InGame.Controller;
using InGame.Model;

namespace Factory
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField] private float spawnInterval;
        private float screenLeftBottom; // modelに移動
        private float screenRightTop; // modelに移動
        public itemDatabase itemDatabase;


        void Start()
        {
            screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero).x + 5.0f;
            screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - 5.0f;
            InvokeRepeating("generateItem", 1, spawnInterval);
        }

        private void generateItem()
        {
            if (itemDatabase != null && itemDatabase.items.Count > 0)
            {
                // sawagani 10%, koyadofu 20%, wood 70%
                int randomIndex = generateRandomValue();
                Item randomItem = itemDatabase.items[randomIndex];

                GameObject itemPrefab = Instantiate(randomItem.Prefab, new Vector2(Random.Range(screenLeftBottom, screenRightTop), -7), transform.rotation);
                ItemController itemController = itemPrefab.AddComponent<ItemController>();
                itemController.Initialize(randomItem);

                itemController.itemSpeed = 4.0f;
                itemController.itemPrefab = itemPrefab;
            }
        }

        private int generateRandomValue()
        {
            int randomValue = Random.Range(0, 9);
            int randomIndex;

            if (randomValue < 1)
            {
                randomIndex = 0;
            }
            else if (randomValue > 0 && randomValue < 3)
            {
                randomIndex = 1;
            }
            else
            {
                randomIndex = 2;
            }

            return randomIndex;
        }
    }

}