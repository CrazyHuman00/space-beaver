using UnityEngine;


namespace InGame.Model
{
    public class PlayerLifeModel : MonoBehaviour
    {
        [SerializeField] private int playerLife = 3;
        [SerializeField] public int playerLifePoint = 3;
        [SerializeField] private GameObject[] playerLifeArray = new GameObject[3];

        public void playerLifeCount()
        {
            if (playerLife > 0)
            {
                playerLifeArray[playerLifePoint - 1].SetActive(false);
                playerLifePoint--;
            }
        }
    }
}