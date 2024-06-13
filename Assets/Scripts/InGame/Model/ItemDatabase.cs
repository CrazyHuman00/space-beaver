using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Model
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "CreateItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        public List<Item> items = new List<Item>();
    }

}