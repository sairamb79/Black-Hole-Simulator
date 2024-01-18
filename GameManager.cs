using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject UI;
    private void Start()
    {
        UI.SetActive(false);
    }
    void Update()
    {
        if(SpaceshipMovement.gameOver)
        {
            UI.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && SpaceshipMovement.gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
