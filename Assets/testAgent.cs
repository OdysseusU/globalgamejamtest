using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class testAgent : Agent
{
    private Rigidbody rBody;
    float time = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    public override void AgentReset()
    {
        if (this.transform.position.y < 0)
        {
            // If the Agent fell, zero its momentum
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.position = new Vector3(0, 0.7f, -2f);
            this.transform.eulerAngles = new Vector3(0, 90.0f, 0);
        }

        // Move the target to a new spot
        /*Target.position = new Vector3(Random.value * 8 - 4,
                                      0.5f,
                                      Random.value * 8 - 4);*/


    }

    public override void CollectObservations()
    {
        // Target and Agent positions
        AddVectorObs(this.transform.position);

        // Agent velocity
        AddVectorObs(rBody.velocity.x);
        AddVectorObs(rBody.velocity.z);
    }

    public float speed = 10;
    public override void AgentAction(float[] vectorAction)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.z = vectorAction[1];
        rBody.AddForce(controlSignal * speed);

        SetReward(rBody.velocity.sqrMagnitude-5f);

        // Fell off platform
        if (this.transform.position.y < 0)
        {
            SetReward(-5.0f);
            Done();
        }
        else
        {
            SetReward(2.0f);
        }
    }
    public override float[] Heuristic()
    {
        var action = new float[2];
        action[0] = Input.GetAxis("Horizontal");
        action[1] = Input.GetAxis("Vertical");
        return action;
    }
}
