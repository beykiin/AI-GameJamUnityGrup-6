using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Hadi : Agent
{
    private Rigidbody rb;
    public float carpan;

    public Transform hedef;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        if(transform.localPosition.y < 0f)
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0f, 0.5f, 0f);
        }

        hedef.localPosition = new Vector3(Random.value * 8.5f - 4f, 0.5f, Random.value * 8.5f - 4f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(hedef.localPosition);
        sensor.AddObservation(transform.localPosition);

        sensor.AddObservation(rb.velocity.x);
        sensor.AddObservation(rb.velocity.z);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 kontrolSinyali = Vector3.zero;
        kontrolSinyali.x = actions.ContinuousActions[0];
        kontrolSinyali.z = actions.ContinuousActions[1];

        Debug.Log(actions.ContinuousActions[0] + " + " + rb.velocity.x);

        rb.AddForce(kontrolSinyali * carpan);

        float hedefeUzaklik = Vector3.Distance(transform.localPosition, hedef.localPosition);
        if(hedefeUzaklik < 1.5f)
        {
            SetReward(1.0f);
            EndEpisode();
        }

        if(transform.localPosition.y < 0f)
        {
            SetReward(-1.0f);
            EndEpisode();
        }

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}
