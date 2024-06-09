using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightStarController : MonoBehaviour
{
    [SerializeField] private float starSpeed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float startStarPositionX;
    [SerializeField] private float endStarPositionX;
    [SerializeField] private float endStarPositionY;
    [SerializeField] private float spanDelay;

    private float starPositionY;
    private float screenLeftBottom; // modelに移動
    private bool isSpanning = false;
    private float starSpeedY;


    void Start()
    {
        screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero).y;

        // 初期のy座標をランダムに設定
        starPositionY = Random.Range(screenLeftBottom - 5.0f, 0);
        transform.position = new Vector2(startStarPositionX, starPositionY);
    }


    void Update()
    {
        if (!isSpanning)
        {
            transform.Translate(-starSpeed * Time.deltaTime, starSpeedY * Time.deltaTime, 0, Space.World);
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
            
            if (transform.position.x < endStarPositionX || transform.position.y > endStarPositionY)
            {
                StartCoroutine(SpanStar());
            }
        }
    }

    private IEnumerator SpanStar()
    {
        isSpanning = true;
        yield return new WaitForSeconds(spanDelay);

        starPositionY = Random.Range(screenLeftBottom, 0);
        transform.position = new Vector2(startStarPositionX, starPositionY);
        starSpeed += 0.1f * Random.value;
        starSpeedY = Random.Range(0, 3f);

        isSpanning = false;
    }
}
