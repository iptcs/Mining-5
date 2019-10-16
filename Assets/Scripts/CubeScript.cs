using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public bool B_Ore, S_Ore, G_Ore, K_Ore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        if(B_Ore == true)
        {
            Gameplay.playerBronze --;
            Gameplay.playerScore += Gameplay.bronzePoints;
        }
        else if (S_Ore == true)
        {
            Gameplay.playerSilver--;
            Gameplay.playerScore += Gameplay.silverPoints;
        }
        else if (G_Ore == true)
        {
            Gameplay.playerGold--;
            Gameplay.playerScore += Gameplay.goldPoints;
        }
        else if (K_Ore == true)
        {
            Gameplay.playerKryptonite--;
            Gameplay.playerScore += Gameplay.kryptonitePoints;
        }
    }

}
