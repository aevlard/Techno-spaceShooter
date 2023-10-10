using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        OpenMenu(mainMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseAllMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void OpenMenu(GameObject target)
    {
        target.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameMenu_Antoine");
    }


}
