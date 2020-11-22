using UnityEngine;
using UnityEngine.UI;

public class BuildTab : MonoBehaviour
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

    public string TowerMenuP1;
    public string TowerMenuP2;

    void Update()
    {
        if (Input.GetButtonDown(TowerMenuP1))
        {
            Player1Pressed();
        }
        if (Input.GetButtonDown(TowerMenuP2))
        {
            Player2Pressed();
        }
    }

    public void Player1Pressed()
    {
        button = BuildTabasP1.GetComponent<Button>();
        Sprite newSprite = Resources.Load<Sprite>("BuildTabH");
        button.GetComponent<Image>().sprite = newSprite;

        button2 = bokstuPanelP1.gameObject.GetComponent<Button>();
        Sprite newSprite2 = Resources.Load<Sprite>("MenuBarH");
        button2.GetComponent<Image>().sprite = newSprite2;


        button3 = EnemiesTabP1.gameObject.GetComponent<Button>();
        Sprite newSprite3 = Resources.Load<Sprite>("AttackTab");
        button3.GetComponent<Image>().sprite = newSprite3;

        bokstuPanelP1.gameObject.SetActive(true);
        priesuPanelP1.gameObject.SetActive(false);

        button4 = firstButtonP1.gameObject.GetComponent<Button>();
        button4.Select();
    }
    public void Player2Pressed()
    {
        buttonP2 = BuildTabasP2.GetComponent<Button>();
        Sprite newSprite = Resources.Load<Sprite>("BuildTabH");
        buttonP2.GetComponent<Image>().sprite = newSprite;

        button2P2 = bokstuPanelP2.gameObject.GetComponent<Button>();
        Sprite newSprite2 = Resources.Load<Sprite>("MenuBarH");
        button2P2.GetComponent<Image>().sprite = newSprite2;


        button3P2 = EnemiesTabP2.gameObject.GetComponent<Button>();
        Sprite newSprite3 = Resources.Load<Sprite>("AttackTab");
        button3P2.GetComponent<Image>().sprite = newSprite3;

        bokstuPanelP2.gameObject.SetActive(true);
        priesuPanelP2.gameObject.SetActive(false);

        button4P2 = firstButtonP2.gameObject.GetComponent<Button>();
        button4P2.Select();
    }
}