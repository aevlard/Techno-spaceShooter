using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager_Antoine : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;



    private void Awake()
    {

    }
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
        SceneManager.LoadScene("Antoine_Scene");
    }

}
