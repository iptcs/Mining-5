using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] int miningSpeed = 3;
    public static int playerBronze, playerSilver, playerGold, playerKryptonite;
    public GameObject Bronze, Silver, Gold, Kryptonite;
    public GameObject myself;
    int bronzeSpawnSpot = -4;
    int silverSpawnSpot = -4;
    int goldSpawnSpot = -4;
    int kryptoniteSpawnSpot = -4;
    public static int playerScore;
    [SerializeField] public static int bronzePoints = 1;
    [SerializeField] public static int silverPoints = 10;
    [SerializeField] public static int goldPoints = 100;
    [SerializeField] public static int kryptonitePoints = 1000;
    // Can't figure out why these won't show up in the inspector...
    private int nextActionTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerBronze = 0;
        playerSilver = 0;
        playerGold = 0;
        playerScore = 0;
        playerKryptonite = 0;
    }

    void Mining()
    {
        if (playerBronze == 2 && playerSilver == 2)
        {
            playerGold++;
            myself = Instantiate(Gold, new Vector3(goldSpawnSpot, 4, 0), Quaternion.identity);
            myself.GetComponent<CubeScript>().G_Ore = true;
            goldSpawnSpot += 2;
        }
        if (playerBronze < 4)
        {
            playerBronze++;
            myself = Instantiate(Bronze, new Vector3(bronzeSpawnSpot, 0, 0), Quaternion.identity);
            bronzeSpawnSpot += 2;
            myself.GetComponent<CubeScript>().B_Ore = true;
        }
        if (playerGold > 0 && playerKryptonite < 2 && playerGold == playerSilver 
            || playerGold > 0 && playerKryptonite < 2 && playerGold + playerKryptonite == playerSilver 
            || playerGold > 0 && playerKryptonite < 2 && playerSilver + playerKryptonite == playerGold)
        {
            playerKryptonite++;
            myself = Instantiate(Kryptonite, new Vector3(kryptoniteSpawnSpot, 6, 0), Quaternion.identity);
            kryptoniteSpawnSpot += 2;
            myself.GetComponent<CubeScript>().K_Ore = true;
        }
        else if (playerBronze >= 4)
        {
            playerSilver++;
            myself = Instantiate(Silver, new Vector3(silverSpawnSpot, 2, 0), Quaternion.identity);
            silverSpawnSpot += 2;
            myself.GetComponent<CubeScript>().S_Ore = true;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            miningSpeed++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            miningSpeed--;
        }

        if (Time.time > nextActionTime)
        {
            nextActionTime += miningSpeed;
            Mining();
        }
    }
    
}
