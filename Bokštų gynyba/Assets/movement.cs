using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movement : MonoBehaviour
{

    public GameObject upgrUIP1;
    public GameObject errorMsgs;

    public int currentTile = 10;
    public int tilesInLine = 8;
    public int tilesInColumn = 0;
    public GameObject TileFirst;
    public GameObject TileLast;
    public float spaceTiles;
    public int tileCount;

    public string tileTag = "Tile";
    public GameObject[] tiles;

    Renderer selected;
    Tile sel;

    public Material selectedTexture;
    public Material unselectedTexture;
    public Material redTexture;

    float timer = 0.075f;

    public bool mapMovementActive = true;
    public bool buildMode = false;
    public bool selectedBuilding = false;
    public bool bm = false;

    public Transform[] prefabs;
    private int buildingNumber;
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
    public string ConO = "ConO";
    public string TowerMenu = "TowerMenu";
    public string EnemyMenu = "EnemyMenu";
    public string Map = "Map";

    public bool AcceptInputs = true;

    public void TurnMapMovementOff()
    {
        mapMovementActive = false;
    }
    public void AcceptInputsMovementOff()
    {
        AcceptInputs = false;
    }
    public void TurnMapMovementOn()
    {
        mapMovementActive = true;
    }
    private void Start()
    {
        tiles = new GameObject[tileCount];
        //tiles = GameObject.FindGameObjectsWithTag(tileTag);
        p = spawner.GetComponent<Player>();
        float X;
        float Z;
        int count = 0;
        Collider[] colliders;
        Vector3 find;
        X = TileFirst.transform.position.x;
        for (int i = 0; i < tilesInColumn; i++)
        {
            Z = TileFirst.transform.position.z;
            for(int j = 0; j < tilesInLine; j++)
            {
                find = new Vector3(X, 0.025f, Z);
                Debug.Log(string.Format("{0} {1} {2}", find.x, find.y, find.z));
                colliders = Physics.OverlapSphere(find, 0.01f);
                tiles[count] = colliders[0].gameObject;
                count++;
                Z -= spaceTiles;
            }
            X -= spaceTiles;
        }

        if (tiles[currentTile].GetComponent<Tile>().buildable)
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = selectedTexture;
        }
        else
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = redTexture;
        }

    }

    private void Update()
    {
        if (AcceptInputs)
        {
            if (selectedBuilding == false && buildMode == false)
            {
                if (Input.GetButtonDown(Map))
                {
                    mapMovementActive = true;
                    mapMovementActivation();
                }
                if (Input.GetButtonDown(TowerMenu) || Input.GetButtonDown(EnemyMenu))
                {
                    mapMovementActive = false;
                    mapMovementActivation();
                    buildMode = false;
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

                if (Input.GetButtonDown(ConX) && !buildMode)
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
                {
                    buildBuilding();
                }

                if (Input.GetButtonDown(ConX) && !buildMode && bm)
                    buildMode = true;

                /*if (Input.GetButtonDown(ConX) && buildMode)
                {
                    buildMode = false;
                    mapMovementActive = false;
                    mapMovementActivation();
                }*/

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

                    if (Input.GetButtonDown(Map) || Input.GetButtonDown(ConO))
                    {
                        selectedBuilding = false;
                        mapMovementActive = true;
                    }
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

        if(tiles[currentTile].GetComponent<Tile>().buildable)
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = selectedTexture;
        }
        else
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = redTexture;
        }

    }

    private void moveDown()
    {

        selected.material = unselectedTexture;

        if ((currentTile + tilesInLine) >= tiles.Length)
        {
            currentTile = currentTile % tilesInLine;
        }
        else currentTile += tilesInLine;

        if (tiles[currentTile].GetComponent<Tile>().buildable)
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = selectedTexture;
        }
        else
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = redTexture;
        }

    }

    private void moveRight()
    {

        selected.material = unselectedTexture;

        if ((currentTile + 1) % tilesInLine == 0)
        {
            currentTile -= tilesInLine - 1;
        }
        else currentTile++;

        if (tiles[currentTile].GetComponent<Tile>().buildable)
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = selectedTexture;
        }
        else
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = redTexture;
        }

    }

    private void moveLeft()
    {
        
        selected.material = unselectedTexture;

        if ((currentTile - 1) % tilesInLine == 5 || currentTile - 1 < 0)
        {
            currentTile += tilesInLine - 1;
        }
        else currentTile--;

        if (tiles[currentTile].GetComponent<Tile>().buildable)
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = selectedTexture;
        }
        else
        {
            selected = tiles[currentTile].GetComponent<Renderer>();
            selected.material = redTexture;
        }

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
            building = Instantiate(prefabs[buildingNumber], tiles[currentTile].transform.position, Quaternion.Euler(0, 90, 0));
            location = tiles[currentTile].GetComponent<Tile>();
            t = building.GetComponent<Tower>();
            if (t != null)
            {
                t.getPlayer(p, location);
                p.incomeMoney(-t.price);
            }
            f = building.GetComponent<Farm>();
            if (f != null)
            {
                f.getPlayer(p, location);
                p.incomeMoney(-f.price);
            }
            location.hasBuilding = true;
            buildMode = false;
            mapMovementActive = true;
            mapMovementActivation();
            
        }
        else
        {
            errorMsgScript errMsg = errorMsgs.GetComponent<errorMsgScript>();
            errMsg.occupied(p);
        }
        bm = false;
    }

    private void getTile()
    {
        location = tiles[currentTile].GetComponent<Tile>();
    }

    private void getBuilding()
    {
        Collider[] colliders;
        Vector3 a = tiles[currentTile].transform.position;
        Vector3 find = new Vector3(a.x, a.y + 10f, a.z);
        colliders = Physics.OverlapSphere(find, 5f);
        building = colliders[0].gameObject;
        tower = building.GetComponent<Tower>();
        farm = building.GetComponent<Farm>();


        UpgradeUIScript ui = upgrUIP1.GetComponent<UpgradeUIScript>();
        //ui.idk(building);

        upgrUIP1.GetComponent<UpgradeUIScript>().idk(building);
    }

    public void BuildMeniu(int number)
    {
        if(number==4)
        {
            if(p.money >= prefabs[number].GetComponent<Farm>().price)
            {
                mapMovementActive = true;
                mapMovementActivation();
                bm = true;
                selectedBuilding = false;
                buildingNumber = number;
                Debug.Log("uzteko pinigu fermai");
            }
            else
            {
                errorMsgScript errMsg = errorMsgs.GetComponent<errorMsgScript>();
                errMsg.NotEnoughMoney();
                Debug.Log("neuzteko pinigu fermai");
            }
        }
        if(number<4)
        {
            if (p.money >= prefabs[number].GetComponent<Tower>().price)
            {
                mapMovementActive = true;
                mapMovementActivation();
                bm = true;
                selectedBuilding = false;
                buildingNumber = number;
                Debug.Log("uzteko pinigu bokstui");
            }
            else
            {
                errorMsgScript errMsg = errorMsgs.GetComponent<errorMsgScript>();
                errMsg.NotEnoughMoney();
                Debug.Log("neuzteko pinigu bokstui");
            }
        }

    }

}
