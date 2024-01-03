using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    //public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup()
    {
        Debug.Log("Game Over");
        gameObject.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("GameScene");
    }

   

    public void quit()
    {
        Application.Quit();
    }
}
