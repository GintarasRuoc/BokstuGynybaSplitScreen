using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour
{
    public GameObject upgrUI;
    public GameObject ws;
    public GameObject err;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Upgrade()
    {
        if(upgrUI.gameObject.GetComponent<UpgradeUIScript>().tower != null && upgrUI.gameObject.GetComponent<UpgradeUIScript>().tower.upgradeOne && !upgrUI.gameObject.GetComponent<UpgradeUIScript>().tower.upgradeTwo)
        {
            if (ws.gameObject.GetComponent<Player>().money >= upgrUI.GetComponent<UpgradeUIScript>().tower.upgradeTwoCost)
            {
                Debug.Log("Paspaustas upgrade ant tower lvl 2 ir pinigu uztenka");
                upgrUI.GetComponent<UpgradeUIScript>().tower.upgradeTowerTwo();
                upgrUI.GetComponent<UpgradeUIScript>().UpdateInfoTowerTwo();
            }
            else
            {
                Debug.Log("Paspaustas upgrade ant tower lvl 2 ir pinigu neuztenka");
                errorMsgScript errMsg = err.GetComponent<errorMsgScript>();
                errMsg.NotEnoughMoney();
            }

        }
        if (upgrUI.gameObject.GetComponent<UpgradeUIScript>().tower != null && !upgrUI.gameObject.GetComponent<UpgradeUIScript>().tower.upgradeOne && !upgrUI.gameObject.GetComponent<UpgradeUIScript>().tower.upgradeTwo)
        {
            if(ws.gameObject.GetComponent<Player>().money >= upgrUI.GetComponent<UpgradeUIScript>().tower.upgradeOneCost)
            {
            Debug.Log("Paspaustas upgrade ant tower lvl 1 ir pinigu uztenka");
            upgrUI.GetComponent<UpgradeUIScript>().tower.upgradeTowerOne();
            upgrUI.GetComponent<UpgradeUIScript>().UpdateInfoTowerTwo();
            }
            else
            {
                Debug.Log("Paspaustas upgrade ant tower lvl 1 ir neuztenka");
                errorMsgScript errMsg = err.GetComponent<errorMsgScript>();
                errMsg.NotEnoughMoney();
            }

        }

        if (upgrUI.gameObject.GetComponent<UpgradeUIScript>().farm != null && !upgrUI.gameObject.GetComponent<UpgradeUIScript>().farm.upgradeOne)
        {
            if (ws.gameObject.GetComponent<Player>().money >= upgrUI.GetComponent<UpgradeUIScript>().farm.upgradeOneCost)
            {
            Debug.Log("Paspaustas upgrade ant farm ir pinigu uztenka");
            upgrUI.GetComponent<UpgradeUIScript>().farm.upgradeFarmOne(upgrUI.GetComponent<UpgradeUIScript>());
            upgrUI.GetComponent<UpgradeUIScript>().UpdateInfoFarm();
            }
            else
            {
                Debug.Log("Paspaustas upgrade ant farm ir pinigu neuztenka");
                errorMsgScript errMsg = err.GetComponent<errorMsgScript>();
                errMsg.NotEnoughMoney();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
