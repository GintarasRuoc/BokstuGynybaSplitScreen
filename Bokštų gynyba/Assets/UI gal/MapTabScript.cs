
using UnityEngine;
using UnityEngine.UI;


public class MapTabScript : MonoBehaviour
{

    public GameObject bokstuPanel;
    public GameObject priesuPanel;

    public GameObject BuildTab;
    public GameObject EnemiesTab;

    private Button button;
    private Button button2;
    private Button button3;
    private Button button4;
    void Update()
    {

        if (Input.GetButtonDown("MapP1"))
        {
            KeistiFona();
        }
    }

    public void KeistiFona()
    {
        button = bokstuPanel.gameObject.GetComponent<Button>();
        Sprite newSprite = Resources.Load<Sprite>("MenuBar");
        button.GetComponent<Image>().sprite = newSprite;

        button4 = priesuPanel.gameObject.GetComponent<Button>();
        button4.GetComponent<Image>().sprite = newSprite;

        button2 = BuildTab.gameObject.GetComponent<Button>();
        Sprite newSprite2 = Resources.Load<Sprite>("BuildTab");
        button2.GetComponent<Image>().sprite = newSprite2;

        button3 = EnemiesTab.gameObject.GetComponent<Button>();
        Sprite newSprite3 = Resources.Load<Sprite>("AttackTab");
        button3.GetComponent<Image>().sprite = newSprite3;

        bokstuPanel.gameObject.SetActive(true);
        priesuPanel.gameObject.SetActive(false);


    }
}
