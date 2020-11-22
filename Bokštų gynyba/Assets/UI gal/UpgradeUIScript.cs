using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIScript : MonoBehaviour
{
    public Text damage;
    public Text speed;
    public Text range;
    public Text upkaina;
    public Text sellkaina;
    public WaveSpawner ws1;
    public WaveSpawner ws2;

    public Tower tower;
    public Farm farm;
    float timer = 0.075f;
    int s = 20;
    public GameObject ui1;
    public string LeftRight = "7thAxisP1";
    private bool UpgradeMenuAct = false;
    Button[] buttons;
    public string ConX = "ConXP1";
    public string Map;
    public string TowerMenu;
    public string EnemyMenu;
    public bool AcceptInputs = true;

    public void AcceptInputsOff()
    {
        AcceptInputs = false;
    }
    void Start()
    {
    }

    void Update()
    {
        if (AcceptInputs)
        {
            if (Input.GetButtonDown(Map))
            {
                UpgradeMenuAct = false;
                this.gameObject.SetActive(false);
            }
            if (Input.GetButtonDown(TowerMenu))
            {
                UpgradeMenuAct = false;
                this.gameObject.SetActive(false);
            }
            if (Input.GetButtonDown(EnemyMenu))
            {
                UpgradeMenuAct = false;
                this.gameObject.SetActive(false);
            }
            if (UpgradeMenuAct)
            {
                if (Input.GetButtonDown(ConX))
                {
                    buttons[s].GetComponent<Button>().onClick.Invoke();
                }
                if (timer <= 0f)
                {
                    switch (s)
                    {
                        case 0:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s = 1;
                                buttons[1].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s = 1;
                                buttons[1].Select();
                            }
                            break;
                        case 1:
                            if (Input.GetAxis(LeftRight) == 1)
                            {
                                s = 0;
                                buttons[0].Select();
                            }
                            if (Input.GetAxis(LeftRight) == -1)
                            {
                                s = 0;
                                buttons[0].Select();
                            }
                            break;
                    }
                    timer = 0.075f;
                }
                else timer -= Time.deltaTime;
            }
        }


    }


    public void idk(GameObject building)
    {
        tower = building.GetComponent<Tower>();
        farm = building.GetComponent<Farm>();

        if (tower !=null)
        {
            this.gameObject.SetActive(true);
            Sprite newSprite1 = Resources.Load<Sprite>("UpgrUI");
            ui1.GetComponent<Image>().sprite = newSprite1;

            damage.text = "" + tower.damage;
            speed.text = "" + tower.attackSpeed;
            range.text = "" + tower.range;
            if(!tower.upgradeOne && !tower.upgradeTwo)
            {
                upkaina.text = " " + tower.upgradeOneCost;
            }
            else if(tower.upgradeOne && !tower.upgradeTwo)
            {
                upkaina.text = "" + tower.upgradeTwoCost;
            }
            sellkaina.text = "" + tower.sell;
            buttons = ui1.GetComponentsInChildren<Button>();
            buttons[0].Select();
            UpgradeMenuAct = true;
            s = 0;
        }
        if (farm != null)
        {
            this.gameObject.SetActive(true);
            Sprite newSprite1 = Resources.Load<Sprite>("UpgrUIFarm");
            ui1.GetComponent<Image>().sprite = newSprite1;
            damage.text = "" + farm.income;
            speed.text = "" + farm.incomeSpeed;
            range.text = "" + farm.incomeCountdown;
            upkaina.text = "" + farm.upgradeOneCost;
            sellkaina.text = "" + farm.sell;
            buttons = ui1.GetComponentsInChildren<Button>();
            buttons[0].Select();
            UpgradeMenuAct = true;
            s = 0;
        }

    }

    public void UpdateInfoTowerOne()
    {
        this.gameObject.SetActive(true);
        damage.text = "" + tower.damage;
        speed.text = "" + tower.attackSpeed;
        range.text = "" + tower.range;
        upkaina.text = "" + tower.upgradeOneCost;
        sellkaina.text = "" + tower.sell;
        buttons = ui1.GetComponentsInChildren<Button>();
        buttons[0].Select();
        UpgradeMenuAct = true;
        s = 0;
    }
    public void UpdateInfoTowerTwo()
    {
        this.gameObject.SetActive(true);
        damage.text = "" + tower.damage;
        speed.text = "" + tower.attackSpeed;
        range.text = "" + tower.range;
        upkaina.text = "" + tower.upgradeTwoCost;
        sellkaina.text = "" + tower.sell;
        buttons = ui1.GetComponentsInChildren<Button>();
        buttons[0].Select();
        UpgradeMenuAct = true;
        s = 0;
    }

    public void UpdateInfoFarm()
    {
        this.gameObject.SetActive(true);
        damage.text = " " + farm.income;
        speed.text = " " + farm.incomeSpeed;
        range.text = " " + farm.incomeCountdown;
        upkaina.text = " " + farm.upgradeOneCost;
        sellkaina.text = " " + farm.sell;
        buttons = ui1.GetComponentsInChildren<Button>();
        buttons[0].Select();
        UpgradeMenuAct = true;
        s = 0;
    }
}
