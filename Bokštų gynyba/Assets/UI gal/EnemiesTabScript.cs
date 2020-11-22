using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesTabScript : MonoBehaviour
{
    public GameObject bokstuPanelP1;
    public GameObject priesuPanelP1;
    public GameObject BuildTabasP1;
    public GameObject EnemiesTabP1;
    public GameObject firstButtonP1;

    public GameObject bokstuPanelP2;
    public GameObject priesuPanelP2;
    public GameObject BuildTabasP2;
    public GameObject EnemiesTabP2;
    public GameObject firstButtonP2;

    private Button button;
    private Button button2;
    private Button button3;
    private Button button4;

    private Button buttonP2;
    private Button button2P2;
    private Button button3P2;
    private Button button4P2;

    public string EnemyMenuP1;
    public string EnemyMenuP2;

    void Update()
    {
        if (Input.GetButtonDown(EnemyMenuP1))
        {
            Player1Pressed();
        }
        if (Input.GetButtonDown(EnemyMenuP2))
        {
            Player2Pressed();
        }
    }
    public void Player1Pressed()
    {
        button = GetComponent<Button>();
        Sprite newSprite = Resources.Load<Sprite>("AttackTabH");
        button.GetComponent<Image>().sprite = newSprite;

        button2 = BuildTabasP1.gameObject.GetComponent<Button>();
        Sprite newSprite2 = Resources.Load<Sprite>("BuildTab");
        button2.GetComponent<Image>().sprite = newSprite2;

        bokstuPanelP1.gameObject.SetActive(false);
        priesuPanelP1.gameObject.SetActive(true);


        button3 = priesuPanelP1.gameObject.GetComponent<Button>();
        Sprite newSprite3 = Resources.Load<Sprite>("MenuBarH");
        button3.GetComponent<Image>().sprite = newSprite3;

        button4 = firstButtonP1.gameObject.GetComponent<Button>();
        button4.Select();
    }
    public void Player2Pressed()
    {
        buttonP2 = GetComponent<Button>();
        Sprite newSprite = Resources.Load<Sprite>("AttackTabH");
        buttonP2.GetComponent<Image>().sprite = newSprite;

        button2P2 = BuildTabasP2.gameObject.GetComponent<Button>();
        Sprite newSprite2 = Resources.Load<Sprite>("BuildTab");
        button2P2.GetComponent<Image>().sprite = newSprite2;

        bokstuPanelP2.gameObject.SetActive(false);
        priesuPanelP2.gameObject.SetActive(true);


        button3P2 = priesuPanelP2.gameObject.GetComponent<Button>();
        Sprite newSprite3 = Resources.Load<Sprite>("MenuBarH");
        button3P2.GetComponent<Image>().sprite = newSprite3;

        button4P2 = firstButtonP2.gameObject.GetComponent<Button>();
        button4P2.Select();
    }
}
