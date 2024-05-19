using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class KovalayanDusman : Agent
{
    private Rigidbody rb;
    [SerializeField] private float hareketHizi;
    [SerializeField] private float donmeHizi;
    [SerializeField] private Transform hedef;
    [SerializeField] private Transform[] duvarlar;

    //Rastgele pozisyonlar için
    [SerializeField] private float maxX, maxY;

    //Yerinde durmasını engellemek için
    private Vector3 startPos;
    private float yerindeDurmaSüresi = 5f;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        //ResetPositions();
    }

    private void Update()
    {
        SabitDurma();
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        AjanHareketi(actions.DiscreteActions);
        //AddReward(-1f / MaxStep);
    }

    private Vector3 RandomSpawnPoint()
    {
        float randomX = Random.Range(-maxX, maxX);
        float randomY = Random.Range(-maxY, maxY);
        Vector3 spawnPosition = new Vector3(Mathf.Sign(randomX) * (Mathf.Clamp(Mathf.Abs(randomX), 5f, 13f)),
            0.5f, Mathf.Sign(randomY) * (Mathf.Clamp(Mathf.Abs(randomY), 5f, 13f)));

        return spawnPosition;
    }
    public void HedefeVardi(float amount)
    {
        /*AddReward(amount);
        EndEpisode();*/
    }

    private void AjanHareketi(ActionSegment<int> actionSegment)
    {
        Vector3 gidilecekYon = Vector3.zero;
        Vector3 gidilecekMesafe = Vector3.zero;

        var action = actionSegment[0];
        var action2 = actionSegment[1];

        /*switch (action)
        {
            case 1:
                gidilecekMesafe = transform.forward * 1f;
                break;
            case 2:
                gidilecekMesafe = transform.forward * -1f;
                break;
            case 2:
                gidilecekYon = transform.up * 1f;
                break;
            case 3:
                gidilecekYon = transform.up * -1f;
                break;
            case 4:
                gidilecekMesafe = transform.right * 0.75f;
                break;
            case 5:
                gidilecekMesafe = transform.right * -0.75f;
                break;
        }*/

        switch (action)
        {
            case 0:
                gidilecekMesafe = transform.forward * 1f;
                break;
            /*case 1:
                gidilecekMesafe = transform.forward * -1f;
                break;*/
            case 1:
                gidilecekMesafe = transform.right * 0.75f;
                break;
            case 2:
                gidilecekMesafe = transform.right * -0.75f;
                break;
        }

        switch (action2)
        {
            case 0:
                gidilecekYon = transform.up * 1f;
                break;
            case 1:
                gidilecekYon = transform.up * -1f;
                break;
        }

        transform.Rotate(gidilecekYon, Time.fixedDeltaTime * donmeHizi);
        rb.AddForce(gidilecekMesafe * hareketHizi, ForceMode.VelocityChange);
    }

    private void ResetPositions()
    {
        //Ajan
        transform.localPosition = new Vector3(0f, 0.5f, 0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        //Hedef ve engeller
        hedef.localPosition = RandomSpawnPoint();
        foreach (Transform duvar in duvarlar)
        {
            duvar.localPosition = RandomSpawnPoint();
        }
    }

    private void SabitDurma()
    {
        yerindeDurmaSüresi -= Time.deltaTime;
        if(yerindeDurmaSüresi <= 0f)
        {
            if(Vector3.Distance(transform.position, startPos) <= 0.1f)
            {
                SetReward(-0.2f);
            }
            startPos = transform.position;
            yerindeDurmaSüresi = 5f;
        }
    }
}
