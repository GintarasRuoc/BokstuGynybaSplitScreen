using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BarScriptP1 : MonoBehaviour
{
    public GameObject losePopup;
    public GameObject losePopupButton;
    public WaveSpawner ws1;
    public WaveSpawner ws2;
    private Player p1;
    private Player p2;

    public GameObject UpgradeUI1;
    public GameObject UpgradeUI2;
    public GameObject ErrorPlace;
    public GameObject ErrorMoney;

    public GameObject bokstuPanel;
    public GameObject priesuPanel;
    public GameObject BuildTabas;
    public GameObject EnemiesTab;
    public GameObject firstButtonB;
    public GameObject firstButtonA;

    private Button button;
    private Button button2;
    private Button button3;
    private Button button4;

    public GameObject tiles;
    private movement m;
    Button[] buttonsAtt;
    Button[] buttonsBuild;

    public string TowerMenu;
    public string EnemyMenu;
    public string Map;
    public string ConX = "ConXP1";
    private string ConX2 = "ConXP2";
    public string LeftRight = "7thAxisP1";
    private bool TowerMenuAct = false;
    private bool AttackMenuAct = false;

    public bool AcceptInputs = true;

    float timer = 0.075f;
    static int s = 90;
    static int s2 = 90;
    void Start()
    {
        m = tiles.GetComponent<movement>();
        buttonsAtt= priesuPanel.GetComponentsInChildren<Button>();
        buttonsBuild = bokstuPanel.GetComponentsInChildren<Button>();
        UpgradeUI1.gameObject.SetActive(false);
        UpgradeUI2.gameObject.SetActive(false);
        losePopup.gameObject.SetActive(false);
        ErrorPlace.gameObject.SetActive(false);
        ErrorMoney.gameObject.SetActive(false);
        p1 = ws1.GetComponent<Player>();
        p2 = ws2.GetComponent<Player>();
        Time.timeScale = 1f;
    }

    void Update()
    {

        if (p1.hp <= 0)
        {
            //Isjngiam movementus bare, movemente, upgrade ui
            AcceptInputs = false;
            m.AcceptInputsMovementOff();
            UpgradeUI1.GetComponent<UpgradeUIScript>().AcceptInputsOff();
            UpgradeUI2.GetComponent<UpgradeUIScript>().AcceptInputsOff();
            UpgradeUI1.gameObject.SetActive(false);
            UpgradeUI2.gameObject.SetActive(false);

            losePopup.gameObject.SetActive(true);
            Sprite newSprite1 = Resources.Load<Sprite>("P1Lost");
            losePopup.GetComponent<Image>().sprite = newSprite1;
            losePopupButton.gameObject.GetComponent<Button>().Select();
            if (Input.GetButtonDown(ConX) || Input.GetButtonDown(ConX2))
            {
                losePopupButton.GetComponent<Button>().onClick.Invoke();
            }

        }
        if (p2.hp <= 0)
        {
            //Isjngiam movementus bare, movemente, upgrade ui
            AcceptInputs = false;
            m.AcceptInputsMovementOff();
            UpgradeUI1.GetComponent<UpgradeUIScript>().AcceptInputsOff();
            UpgradeUI2.GetComponent<UpgradeUIScript>().AcceptInputsOff();
            UpgradeUI1.gameObject.SetActive(false);
            UpgradeUI2.gameObject.SetActive(false);

            losePopup.gameObject.SetActive(true);
            Sprite newSprite2 = Resources.Load<Sprite>("P2Lost");
            losePopup.GetComponent<Image>().sprite = newSprite2;
            losePopupButton.gameObject.GetComponent<Button>().Select();
            if (Input.GetButtonDown(ConX) || Input.GetButtonDown(ConX2))
            {
                losePopupButton.GetComponent<Button>().onClick.Invoke();
            }
        }

        if (AcceptInputs)
        {
            if (Input.GetButtonDown(TowerMenu))
            {
                TowerMenuAct = true;
                AttackMenuAct = false;
                m.TurnMapMovementOff();

                PlayerPressedBuild();
                Debug.Log("P1 pressed build");
                s = 1;
            }

            if (Input.GetButtonDown(EnemyMenu))
            {
                AttackMenuAct = true;
                TowerMenuAct = false;
                m.TurnMapMovementOff();

                PlayerPressedAttack();
                Debug.Log("P1 pressed attack");
                s2 = 1;
            }


            if (Input.GetButtonDown(Map))
            {
                AttackMenuAct = false;
                TowerMenuAct = false;
                m.TurnMapMovementOn();

                PlayerPressedMap();
                Debug.Log("P1 pressed map");

            }

            if (TowerMenuAct)
            {
                if (Input.GetButtonDown(ConX))
                {
                    buttonsBuild[s].GetComponent<Button>().onClick.Invoke();
                    AttackMenuAct = false;
                    TowerMenuAct = false;
                    PlayerPressedMap();
                    Debug.Log("P1 pressed X");
                }
                if (timer <= 0f)
                {
                    switch (s)
                    {
                        case 1:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s = 2;
                                buttonsBuild[2].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s = 5;
                                buttonsBuild[5].Select();
                            }
                            break;
                        case 2:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s = 3;
                                buttonsBuild[3].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s = 1;
                                buttonsBuild[1].Select();
                            }
                            break;
                        case 3:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s = 4;
                                buttonsBuild[4].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s = 2;
                                buttonsBuild[2].Select();
                            }
                            break;
                        case 4:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s = 5;
                                buttonsBuild[5].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s = 3;
                                buttonsBuild[3].Select();
                            }
                            break;
                        case 5:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s = 1;
                                buttonsBuild[1].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s = 4;
                                buttonsBuild[4].Select();
                            }
                            break;
                    }
                    timer = 0.075f;
                }
                else timer -= Time.deltaTime;
            }

            if (AttackMenuAct)
            {
                if (Input.GetButtonDown(ConX))
                {
                    buttonsAtt[s2].GetComponent<Button>().onClick.Invoke();
                    Debug.Log("P1 pressed X send attack");
                }
                if (timer <= 0f)
                {
                    switch (s2)
                    {
                        case 1:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s2 = 2;
                                buttonsAtt[2].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s2 = 5;
                                buttonsAtt[5].Select();
                            }
                            break;
                        case 2:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s2 = 3;
                                buttonsAtt[3].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s2 = 1;
                                buttonsAtt[1].Select();
                            }
                            break;
                        case 3:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s2 = 4;
                                buttonsAtt[4].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s2 = 2;
                                buttonsAtt[2].Select();
                            }
                            break;
                        case 4:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s2 = 5;
                                buttonsAtt[5].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s2 = 3;
                                buttonsAtt[3].Select();
                            }
                            break;
                        case 5:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s2 = 1;
                                buttonsAtt[1].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s2 = 4;
                                buttonsAtt[4].Select();
                            }
                            break;
                    }
                    timer = 0.075f;
                }
                else timer -= Time.deltaTime;
            }

        }
        

    }
    public void PlayerPressedBuild()
    {
        bokstuPanel.gameObject.SetActive(true);
        priesuPanel.gameObject.SetActive(false);

        button = BuildTabas.GetComponent<Button>();
        Sprite newSprite7 = Resources.Load<Sprite>("BuildTabH");
        button.GetComponent<Image>().sprite = newSprite7;

        button2 = bokstuPanel.gameObject.GetComponent<Button>();
        Sprite newSprite8 = Resources.Load<Sprite>("MenuBarH");
        button2.GetComponent<Image>().sprite = newSprite8;

        button3 = EnemiesTab.gameObject.GetComponent<Button>();
        Sprite newSprite9 = Resources.Load<Sprite>("AttackTab");
        button3.GetComponent<Image>().sprite = newSprite9;

        buttonsBuild[1].Select();

    }
    public void PlayerPressedAttack()
    {
        bokstuPanel.gameObject.SetActive(false);
        priesuPanel.gameObject.SetActive(true);
        button = EnemiesTab.GetComponent<Button>();
        Sprite newSprite10 = Resources.Load<Sprite>("AttackTabH");
        button.GetComponent<Image>().sprite = newSprite10;

        button2 = BuildTabas.gameObject.GetComponent<Button>();
        Sprite newSprite11 = Resources.Load<Sprite>("BuildTab");
        button2.GetComponent<Image>().sprite = newSprite11;

        bokstuPanel.gameObject.SetActive(false);
        priesuPanel.gameObject.SetActive(true);

        button3 = priesuPanel.gameObject.GetComponent<Button>();
        Sprite newSprite12 = Resources.Load<Sprite>("MenuBarH");
        button3.GetComponent<Image>().sprite = newSprite12;

        buttonsAtt[1].Select();

    }
    public void PlayerPressedMap()
    {
        button = bokstuPanel.gameObject.GetComponent<Button>();
        Sprite newSprite = Resources.Load<Sprite>("MenuBar");
        button.GetComponent<Image>().sprite = newSprite;

        button2 = BuildTabas.gameObject.GetComponent<Button>();
        Sprite newSprite2 = Resources.Load<Sprite>("BuildTab");
        button2.GetComponent<Image>().sprite = newSprite2;

        button3 = EnemiesTab.gameObject.GetComponent<Button>();
        Sprite newSprite3 = Resources.Load<Sprite>("AttackTab");
        button3.GetComponent<Image>().sprite = newSprite3;

        bokstuPanel.gameObject.SetActive(true);
        priesuPanel.gameObject.SetActive(false);

        buttonsAtt[s].gameObject.SetActive(false);
        buttonsAtt[s].gameObject.SetActive(true);

        buttonsBuild[s].gameObject.SetActive(false);
        buttonsBuild[s].gameObject.SetActive(true);

    }
}
