using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void playButtonClick()
    {
        SceneManager.LoadScene("Gameplay-House");
    }

    public void creditsButtonClick()
    {
        SceneManager.LoadScene("Credits");
    }

    // Update is called once per frame
    void Update()
    {

    }
}