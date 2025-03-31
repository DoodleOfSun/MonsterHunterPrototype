using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColliding : MonoBehaviour
{
    public Text playerHitText;
    void Update()
    {
        playerHitText.text = "Player Hit : False";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyAttackBox")
        {
            playerHitText.text = "Player Hit : True";
        }
    }
}
