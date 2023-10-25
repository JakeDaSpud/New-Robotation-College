using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [Header("Key's Doors")]
    //Every door that this key unlocks
    [SerializeField] GameObject[] doors;
    [SerializeField] private Color darkDoorShade;

    //Method adapted from this video: https://www.youtube.com/watch?v=kDRjWher3zk
    private void OnTriggerEnter2D(Collider2D other) {
        //Check if player touched key
        if (other.CompareTag("Player")) {
            Debug.Log("Key has been picked up.");

            //Turn off sprite of key
            this.GetComponent<SpriteRenderer>().enabled = false;

            //Loop through each associated door
            foreach (GameObject currentDoor in doors)
            {
                //Turn off collision for this door
                currentDoor.GetComponent<BoxCollider2D>().enabled = false;

                //Get the colours of the current door
                darkDoorShade = currentDoor.GetComponent<SpriteRenderer>().color;

                //Get 60% of each colour, making output a darker shade
                darkDoorShade.r = 0.6f;
                darkDoorShade.g = 0.6f;
                darkDoorShade.b = 0.6f;

                //Set door to be new colour
                currentDoor.GetComponent<SpriteRenderer>().color = darkDoorShade;

                //This would turn off the object entirely, not just making it non-collidable
                //this.gameObject.SetActive(false);
            }
        }
    }
}
