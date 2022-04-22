using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void set_pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void resume_game()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void back_to_menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
