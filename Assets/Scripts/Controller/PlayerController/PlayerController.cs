using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Vector2 screen_LeftBottom;
    private Vector2 screen_RightTop;
    private Vector2 newPosition;
    
    void Start()
    {
        screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
        screen_RightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
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
        
        newPosition.x = Mathf.Clamp(transform.position.x, screen_LeftBottom.x, screen_RightTop.x);
        newPosition.y = Mathf.Clamp(transform.position.y, screen_LeftBottom.y, screen_RightTop.y);

        transform.position = newPosition;
    }
}
