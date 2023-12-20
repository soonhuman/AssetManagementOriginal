using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushLevel1Button()
    {
        SceneManager.LoadScene("Game1Scene");
    }

    public void PushLevel2Button()
    {
        SceneManager.LoadScene("Game2Scene");
    }

    public void PushLevel3Button()
    {
        SceneManager.LoadScene("Game3Scene");
    }

    public void PushLevel4Button()
    {
        SceneManager.LoadScene("Game4Scene");
    }

    public void PushLevel5Button()
    {
        SceneManager.LoadScene("Game5Scene");
    }

    public void PushLevel6Button()
    {
        SceneManager.LoadScene("Game6Scene");
    }

}
