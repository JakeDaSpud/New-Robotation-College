using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    [Header("Conveyor Settings")]
    //Where conveyor moves to first
    [SerializeField] Transform firstTargetPoint;
    //Where conveyor moves to after going to the firstTargetPoint
    [SerializeField] Transform secondTargetPoint;
    //Smoothing speed of conveyor at start and end of movement
    [SerializeField] float conveyorSpeed = 0.4f;
    //
    [SerializeField] Vector3 conveyorVelocity = Vector3.zero;
    //[SerializeField] float smoothTime = 0.5f;

    private Vector2 targetDirection;
    private Transform currentTarget;

    void Awake() {
        currentTarget = firstTargetPoint;
    }

    //Update is called once per frame
    //Used to help with conveyor movement: https://www.youtube.com/watch?v=DQYj8Wgw3O0
    void FixedUpdate()
    {
        targetDirection = new Vector3(firstTargetPoint.position.x - this.transform.position.x, firstTargetPoint.position.y - this.transform.position.y, 0f);
        
        //If conveyor isn't at the current target position (default is firstTargetPoint)
        if (this.transform.position != currentTarget.position) {
            
            //Move the conveyor to the currentTarget with an ease-in-out smoothing curve of conveyorSpeed
            this.transform.position = Vector3.SmoothDamp(transform.position, currentTarget.transform.position, ref conveyorVelocity, conveyorSpeed);
            //this.transform.position = (targetDirection + conveyorSpeed) * Time.deltaTime;
        }

        //Conveyor has reached the current target
        else if (this.transform.position == currentTarget.position) {
            //Swap whether the first or second point is the currentTarget for the next FixedUpdate
            if (currentTarget == firstTargetPoint) {currentTarget = secondTargetPoint;}
            else if (currentTarget == secondTargetPoint) {currentTarget = firstTargetPoint;}
        }
    }
}
