using UnityEngine;
using UnityEngine.Serialization;

namespace InGame.Model
{
    /// <summary>
    /// アイテムの情報を保持する。
    /// </summary>
    [CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
    public class Item : ScriptableObject
    {
        /// <summary>
        /// 得点
        /// </summary>
        [FormerlySerializedAs("Point")] [SerializeField] public int point;

        /// <summary>
        /// 名前
        /// </summary>
        [FormerlySerializedAs("Name")] [SerializeField] public new string name;

        /// <summary>
        /// 生成するオブジェクト
        /// </summary>
        [FormerlySerializedAs("Prefab")] [SerializeField] public GameObject prefab;

        public void ApplyEffect()
        {
            // アイテムの効果を適用するコードをここに追加
        }
    }
}