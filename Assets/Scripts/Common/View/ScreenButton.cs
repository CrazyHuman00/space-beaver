using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Common.View
{
    public class ScreenButton : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        public void OnClick()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
