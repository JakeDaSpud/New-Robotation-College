using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //Check if player touched goal
        if (other.CompareTag("Player")) {
            if (SceneManager.GetActiveScene().buildIndex == 2) {
                GameManager.instance.LoadMainMenu();
            }
            else {
                GameManager.instance.NextLevel();
            }
        }
    }
}
