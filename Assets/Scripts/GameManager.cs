using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private int status;
    private Pause pause_class;

    public void Start()
    {
        pause_class = pauseMenu.GetComponent<Pause>();
        pauseMenu.SetActive(false);
        status = 0;
    }

    public void OnPause()
    {
        if (status == 0) {
            set_pause();
            status = 1;
        } else {
            resume_game();
            status = 0;
        }
    }

    public void set_pause()
    {
        pause_class.set_pause();
        Debug.Log("pause");
    }

    public void resume_game()
    {
        pause_class.resume_game();
        Debug.Log("resume");
    }

    public void back_to_menu()
    {
        pause_class.back_to_menu();
        Debug.Log("menu");
    }
}
