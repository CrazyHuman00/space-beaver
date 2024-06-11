using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Model
{
    /// <summary>
    /// アイテムの情報を保持するクラス
    /// <summary>
    [CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
    public class Item : ScriptableObject
    {
        /// <summary>
        /// 得点
        /// </summary>
        [SerializeField] public int Score;

        /// <summary>
        /// name
        /// </summary>
        [SerializeField] public string Name;

        /// <summary>
        /// 生成するオブジェクト
        /// </summary>
        [SerializeField] public GameObject Prefab;

        public void ApplyEffect()
        {
            // アイテムの効果を適用するコードをここに追加
        }

    }


    [CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
    public class itemDatabase : ScriptableObject
    {
        public List<Item> items = new List<Item>();
    }
}