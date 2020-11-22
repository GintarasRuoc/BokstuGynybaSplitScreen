using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButtonScript : MonoBehaviour
{
    public GameObject upgrUI;
    private movement m;
    public GameObject tiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SellT()
    {
        if (upgrUI.gameObject.GetComponent<UpgradeUIScript>().tower != null)
        {
            Debug.Log("Paspaustas sell ant tower");
            upgrUI.GetComponent<UpgradeUIScript>().tower.sellTower();
            m = tiles.GetComponent<movement>();
            m.TurnMapMovementOn();
            upgrUI.gameObject.SetActive(false);
        }
        if (upgrUI.gameObject.GetComponent<UpgradeUIScript>().tower == null)
        {
            Debug.Log("Paspaustas sell ant farm");
            upgrUI.GetComponent<UpgradeUIScript>().farm.sellFarm();
            m = tiles.GetComponent<movement>();
            m.TurnMapMovementOn();
            upgrUI.gameObject.SetActive(false);
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
