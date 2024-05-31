using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject _slider;
    public GameObject _buttons;

    void Start()
    {
       StartCoroutine(ActiveButtons());
    }
    IEnumerator ActiveButtons()
    {
        yield return new WaitForSeconds(5);
        _slider.SetActive(false);
        _buttons.SetActive(true);
    }
    public void Play()
    {
       
        SceneManager.LoadScene("BasketBall");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void ImageTracker()
    {
        SceneManager.LoadScene("ImageTracker");
    }


}
