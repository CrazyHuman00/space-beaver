using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動きを制御するクラス
/// <summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Vector2 screenLeftBottom; // modelに移動
    private Vector2 screenRightTop; // modelに移動
    private Vector2 newPosition;
    
    void Start()
    {
        screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
        screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += playerSpeed * transform.up * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= playerSpeed * transform.up * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += playerSpeed * transform.right * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= playerSpeed * transform.right * Time.deltaTime;
        }
        
        newPosition.x = Mathf.Clamp(transform.position.x, screenLeftBottom.x, screenRightTop.x);
        newPosition.y = Mathf.Clamp(transform.position.y, screenLeftBottom.y, screenRightTop.y);

        transform.position = newPosition;
    }
}
