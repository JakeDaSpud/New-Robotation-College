using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //Check if player touched goal
        if (other.CompareTag("Player")) {
            GameManager.instance.NextLevel();
        }
    }
}
