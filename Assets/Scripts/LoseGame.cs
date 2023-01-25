using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{

    [SerializeField] public GameObject interactUI;

    public Animator _anim;

    public GameObject mainMenuButton;

    public GameObject enemies;

    public PlayerMovementv2 PM2;

    public CharacterController CC;

    public void loseGame()
    {
        _anim.SetTrigger("playGameOver");

        mainMenuButton.SetActive(true);

        enemies.SetActive(false);

        interactUI.SetActive(false);

        PM2.enabled = false;
        CC.enabled = false;

        Cursor.lockState = CursorLockMode.None;   
    }



    public void mainMenu()
    {

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);


    }







}
