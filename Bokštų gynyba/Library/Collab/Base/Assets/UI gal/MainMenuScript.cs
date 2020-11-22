using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject info;
    public GameObject play;

    public GameObject mapai;

    public Button Map1;
    public Button Map2;
    public Button Map3;
    public Button Map4;
    public Button ButFromMap;
    public Button ButFromInf;


    private Button button1;
    private Button button2;
    Button[] buttons;
    Button[] menuButtons;
    int s = 40;
    int s2 = 0;
    float timer = 0.3f;
    public string ConX = "ConXP1";
    private string ConX2 = "ConXP2";
    public string LeftRight = "7thAxisP1";
    public string LeftRight2 = "7thAxisP2";

    public bool MapSelection = false;
    public bool MenuSelection = true;
    public bool InformationMenu = false;
    void Start()
    {
        mapai.gameObject.SetActive(false);
        buttons = mapai.GetComponentsInChildren<Button>();
        menuButtons = menu.GetComponentsInChildren<Button>();
        menuButtons[0].Select();
        buttons[4] = ButFromMap;
    }
    void Update()
    {
        if (MapSelection)
        {
            if ((Input.GetButtonDown("ConXP1")) || (Input.GetButtonDown("ConXP2")))
            {
                buttons[s].GetComponent<Button>().onClick.Invoke();
            }
            if (timer <= 0f)
            {
                switch (s)
                {
                    case 0:
                        if ((Input.GetAxis("7thAxisP1") == 1) || (Input.GetAxis("7thAxisP2") == 1))
                        {
                            Debug.Log("P1 right");
                            s = 1;
                            buttons[1].Select();
                        }
                        if ((Input.GetAxis("7thAxisP1") == -1) || (Input.GetAxis("7thAxisP2") == -1))
                        {
                            s = 1;
                            buttons[1].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == 1) || (Input.GetAxis("8thAxisP2") == 1))
                        {
                            s = 2;
                            buttons[2].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == -1) || (Input.GetAxis("8thAxisP2") == -1))
                        {
                            s = 2;
                            buttons[2].Select();
                        }
                        break;
                    case 1:
                        if ((Input.GetAxis("7thAxisP1") == 1) || (Input.GetAxis("7thAxisP2") == 1))
                        {
                            Debug.Log("P1 right");
                            s = 0;
                            buttons[0].Select();
                        }
                        if ((Input.GetAxis("7thAxisP1") == -1) || (Input.GetAxis("7thAxisP2") == -1))
                        {
                            s = 0;
                            buttons[0].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == 1) || (Input.GetAxis("8thAxisP2") == 1))
                        {
                            s = 3;
                            buttons[3].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == -1) || (Input.GetAxis("8thAxisP2") == -1))
                        {
                            s = 3;
                            buttons[3].Select();
                        }
                        break;
                    case 2:
                        if ((Input.GetAxis("7thAxisP1") == 1) || (Input.GetAxis("7thAxisP2") == 1))
                        {
                            Debug.Log("P1 right");
                            s = 3;
                            buttons[3].Select();
                        }
                        if ((Input.GetAxis("7thAxisP1") == -1) || (Input.GetAxis("7thAxisP2") == -1))
                        {
                            s = 3;
                            buttons[3].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == 1) || (Input.GetAxis("8thAxisP2") == 1))
                        {
                            s = 0;
                            buttons[0].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == -1) || (Input.GetAxis("8thAxisP2") == -1))
                        {
                            s = 4;
                            buttons[4].Select();
                        }
                        break;
                    case 3:
                        if ((Input.GetAxis("7thAxisP1") == 1) || (Input.GetAxis("7thAxisP2") == 1))
                        {
                            Debug.Log("P1 right");
                            s = 2;
                            buttons[2].Select();
                        }
                        if ((Input.GetAxis("7thAxisP1") == -1) || (Input.GetAxis("7thAxisP2") == -1))
                        {
                            s = 2;
                            buttons[2].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == 1) || (Input.GetAxis("8thAxisP2") == 1))
                        {
                            s = 1;
                            buttons[1].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == -1) || (Input.GetAxis("8thAxisP2") == -1))
                        {
                            s = 4;
                            buttons[4].Select();
                        }
                        break;
                    case 4:
                        if ((Input.GetAxis("8thAxisP1") == 1) || (Input.GetAxis("8thAxisP2") == 1))
                        {
                            s = 2;
                            buttons[2].Select();
                        }
                        break;

                }
                //timer = 0.075f;
                timer = 0.1f;
            }
            else timer -= Time.deltaTime;
        }
        if (MenuSelection)
        {
            if ((Input.GetButtonDown("ConXP1")) || (Input.GetButtonDown("ConXP2")))
            {
                menuButtons[s2].GetComponent<Button>().onClick.Invoke();
            }
            if (timer <= 0f)
            {
                switch (s2)
                {
                    case 0:
                        if ((Input.GetAxis("8thAxisP1") == 1) || (Input.GetAxis("8thAxisP2") == 1))
                        {
                            s2 = 2;
                            menuButtons[2].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == -1) || (Input.GetAxis("8thAxisP2") == -1))
                        {
                            s2 = 1;
                            menuButtons[1].Select();
                        }
                        break;
                    case 1:
                        if ((Input.GetAxis("8thAxisP1") == 1) || (Input.GetAxis("8thAxisP2") == 1))
                        {
                            s2 = 0;
                            menuButtons[0].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == -1) || (Input.GetAxis("8thAxisP2") == -1))
                        {
                            s2 = 2;
                            menuButtons[2].Select();
                        }
                        break;
                    case 2:
                        if ((Input.GetAxis("8thAxisP1") == 1) || (Input.GetAxis("8thAxisP2") == 1))
                        {
                            s2 = 1;
                            menuButtons[1].Select();
                        }
                        if ((Input.GetAxis("8thAxisP1") == -1) || (Input.GetAxis("8thAxisP2") == -1))
                        {
                            s2 = 0;
                            menuButtons[0].Select();
                        }
                        break;

                }
                //timer = 0.075f;
                timer = 0.1f;
            }
            else timer -= Time.deltaTime;
        }
        if (InformationMenu)
        {
            if (timer <= 0f)
            {
                if ((Input.GetButtonDown("ConXP1")) || (Input.GetButtonDown("ConXP2")))
                {
                    Debug.Log("Is info spausta back");
                    ButFromInf.GetComponent<Button>().onClick.Invoke();
                }
                timer = 0.3f;
            }
            else timer -= Time.deltaTime;
        }
    }



    public void ChooseMaps()
    {
        InformationMenu = false;
        MapSelection = true;
        MenuSelection = false;

        menu.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        mapai.gameObject.SetActive(true);
        buttons[0].Select();
        s = 0;

    }
    public void ChangeFromMenuToInfo()
    {
        Debug.Log("Pressed info");
        InformationMenu = true;
        MapSelection = false;
        MenuSelection = false;
        menu.gameObject.SetActive(false);
        info.gameObject.SetActive(true);
        mapai.gameObject.SetActive(false);
        ButFromInf.Select();
    }
    public void ChangeFromInfoToMenu()
    {
        MenuSelection = true;
        InformationMenu = false;
        MapSelection = false;
        menu.gameObject.SetActive(true);
        info.gameObject.SetActive(false);
        buttons[0].Select();
    }
    public void ChangeFromMapsToMenu()
    {
        Debug.Log("pressed from maps to menu");
        MenuSelection = true;
        InformationMenu = false;
        MapSelection = false;
        menu.gameObject.SetActive(true);
        info.gameObject.SetActive(false);
        mapai.gameObject.SetActive(false);
        buttons[0].Select();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}