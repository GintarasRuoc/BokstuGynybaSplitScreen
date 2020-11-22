using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    public Image content;

    [SerializeField]
    public GameObject spawner;

    public Text hp;

    Player player;
    void Start()
    {
        player = spawner.GetComponent<Player>();
    }


    void Update()
    {
        if(player.hp>=0)
        {
            content.fillAmount = CalcFill(player.hp, 0, 100, 0, 1);
            hp.text = string.Format("{0}", player.hp);
        }
        else
        {
            content.fillAmount = 0;
            hp.text = "0";
        }
    }

    private float CalcFill(float value, float hpMin, float hpMax, float outMin, float outMax)
    {
        return (value - hpMin) * (outMax - outMin) / (hpMax - hpMin) + outMin;
    }
}
