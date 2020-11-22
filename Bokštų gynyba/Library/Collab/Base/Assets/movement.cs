using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movement : MonoBehaviour
{
    public int currentTile = 10;
    public int tilesInLine = 8;

    public string tileTag = "Tile";
    GameObject[] tiles;

    Renderer selected;

    public Material selectedTexture;
    public Material unselectedTexture;
    

    float timer = 0.075f;

    public bool mapMovementActive = true;
    public bool buildMode = false;
    public bool selectedBuilding = false;

    public Transform prefab;
    public GameObject spawner;
    public Player p;
    
    public string buildingsTags = "Building";
    private GameObject building;
    private Tile location;
    private Tower tower;
    private Farm farm;

    public string UpDown = "8thAxis";
    public string LeftRight = "7thAxis";
    public string ConX = "ConX";
    public string ConO = "ConY";
    public string TowerMenu = "TowerMenu";
    public string EnemyMenu = "EnemyMenu";
    public string Map = "Map";

    public void TurnMapMovementOff()
    {
        mapMovementActive = false;
    }
    public void TurnMapMovementOn()
    {
        mapMovementActive = true;
    }
    private void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag(tileTag);
        p = spawner.GetComponent<Player>();
        selected = tiles[currentTile].GetComponent<Renderer>();
        selected.material = selectedTexture;

    }

    private void Update()
    {
        if(selectedBuilding == false && buildMode == false)
        {
            if(Input.GetButtonDown(Map))
            {
                mapMovementActive = true;
                mapMovementActivation();
            }
            if(Input.GetButtonDown(TowerMenu) || Input.GetButtonDown(EnemyMenu))
            {
                mapMovementActive = false;
                mapMovementActivation();
            }
        }
        if (mapMovementActive)
        {
            if (timer <= 0)
            {
                if (Input.GetAxisRaw(UpDown) == 1)
                    moveUp();

                if (Input.GetAxisRaw(UpDown) == -1)
                    moveDown();

                if (Input.GetAxis(LeftRight) == 1)
                    moveRight();

                if (Input.GetAxis(LeftRight) == -1)
                    moveLeft();

                timer = 0.075f;
            }
            else timer -= Time.deltaTime;

            if(Input.GetButtonDown(ConX) && !buildMode)
            {
                getTile();
                if (location.hasBuilding)
                {
                    getBuilding();
                    Debug.Log("Pasirinkti ka daryti su pastatu");
                    mapMovementActive = false;
                    selectedBuilding = true;
                    
                }

            }

            if (Input.GetButtonDown(ConX) && buildMode)
                buildBuilding();

            if (Input.GetButtonDown(ConX) && buildMode)
            {
                buildMode = false;
                mapMovementActive = false;
                mapMovementActivation();
            }

            if (selectedBuilding)
            {
                /*if (Input.GetButtonDown("UpgradeOne"))
                {
                    // patikrina ar tai bokstas, patikrina ar turi pakankamai pinigu, patikrina ar jau bokstas nera pagerintas
                    if (tower != null && tower.player.money >= tower.upgradeOneCost && !tower.upgradeOne)
                        tower.upgradeTowerOne();
                    else if (farm != null && farm.p.money >= farm.upgradeOneCost)
                        farm.upgradeFarmOne();
                }

                if (Input.GetButtonDown("UpgradeTwo"))
                {
                    // patikrina ar tai bokstas, patikrina ar turi pakankamai pinigu, patikrina ar jau bokstas nera pagerintas
                    if (tower != null && tower.player.money >= tower.upgradeTwoCost && !tower.upgradeTwo && tower.upgradeOne)
                        tower.upgradeTowerTwo();
                }

                if (Input.GetButtonDown("Sell"))
                {
                    if (tower != null)
                    {
                        tower.sellTower();
                        location.hasBuilding = false;
                        selectedBuilding = false;
                        mapMovementActive = true;
                    }
                    else if (farm != null)
                    {
                        farm.sellFarm();
                        location.hasBuilding = false;
                        selectedBuilding = false;
                        mapMovementActive = true;
                    }
                }*/

                if (Input.GetButtonDown(ConO))
                {
                    selectedBuilding = false;
                    mapMovementActive = true;
                }
            }
        }

    }

    private void moveUp()
    {

        selected.material = unselectedTexture;

        if ((currentTile - tilesInLine) < 0)
        {
            currentTile = tiles.Length - ( tilesInLine - currentTile);
        }
        else currentTile -= tilesInLine;
        selected = tiles[currentTile].GetComponent<Renderer>();
        selected.material = selectedTexture;

        
    }

    private void moveDown()
    {

        selected.material = unselectedTexture;

        if ((currentTile + tilesInLine) >= tiles.Length - 1)
        {
            currentTile = currentTile % tilesInLine;
        }
        else currentTile += tilesInLine;
        selected = tiles[currentTile].GetComponent<Renderer>();
        selected.material = selectedTexture;

    }

    private void moveRight()
    {

        selected.material = unselectedTexture;

        if ((currentTile + 1) % tilesInLine == 0)
        {
            currentTile -= tilesInLine - 1;
        }
        else currentTile++;
        selected = tiles[currentTile].GetComponent<Renderer>();
        selected.material = selectedTexture;

    }

    private void moveLeft()
    {

        selected.material = unselectedTexture;

        if ((currentTile - 1) % tilesInLine == 5 || currentTile - 1 < 0)
        {
            currentTile += tilesInLine - 1;
        }
        else currentTile--;
        selected = tiles[currentTile].GetComponent<Renderer>();
        selected.material = selectedTexture;

    }

    private void mapMovementActivation()
    {
        if (mapMovementActive)
            selected.material = selectedTexture;
        else
            selected.material = unselectedTexture;
    }

    private void buildBuilding()
    {
        Transform building;
        Tower t;
        Farm f;
        getTile();
        if (location.buildable && !location.hasBuilding)
        {
            building = Instantiate(prefab, tiles[currentTile].transform.position, Quaternion.Euler(0, 90, 0));
            t = building.GetComponent<Tower>();
            if (t != null)
            { 
                t.getPlayer(p);
            }
            f = building.GetComponent<Farm>();
            if(f != null)
            {
                f.getPlayer(p);
            }
            location.hasBuilding = true;
            buildMode = false;
            mapMovementActive = false;
            mapMovementActivation();
        }
        else return; 
    }

    private void getTile()
    {
        location = tiles[currentTile].GetComponent<Tile>();
    }

    private void getBuilding()
    {
        Collider[] colliders;
        Vector3 a = tiles[currentTile].transform.position;
        Vector3 find = new Vector3(a.x, a.y + 15f, a.z);
        colliders = Physics.OverlapSphere(find, 15f);
        Debug.Log(colliders.Length);
        Debug.Log(colliders[0].gameObject.name);

        building = colliders[0].gameObject;
        tower = building.GetComponent<Tower>();
        farm = building.GetComponent<Farm>();
    }

    public void BuildMeniu(Transform building, Player player)
    {
        mapMovementActive = true;
        mapMovementActivation();
        buildMode = true;
        selectedBuilding = false;
        prefab = building;
        p = player;
    }

}
