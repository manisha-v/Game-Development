using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public GameObject controlPanel;

    public float speed = 2;
    public float force = 300;

    // Start is called before the first frame update
    void Start()
    {
        //controlPanel.SetActive(false);
        this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }

    public void Restart()
    {
        SceneManager.LoadScene("FlappyGame");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void Back()
    {
        controlPanel.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        controlPanel.SetActive(true);
    }


}
