using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBarScript : MonoBehaviour
{
    public Text moneyAmount;

    public GameObject spawner;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = spawner.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmount.text = string.Format("{0}", player.money);
    }
}
