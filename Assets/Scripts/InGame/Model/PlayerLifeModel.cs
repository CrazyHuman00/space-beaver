using UnityEngine;


namespace InGame.Model
{
    public class PlayerLifeModel : MonoBehaviour
    {
        [SerializeField] private int playerLife;
        [SerializeField] public int playerLifePoint;
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