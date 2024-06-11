using System.Collections;
using UnityEngine;

/// <summary>
/// 待ち時間の名前空間
/// <summary>
namespace InGame.Model
{
    public class StarWaitTime
    {
        public static IEnumerator WaitForSecondsCoroutine(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

    }
}
