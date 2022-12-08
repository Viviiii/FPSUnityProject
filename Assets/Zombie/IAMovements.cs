using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Threading;
using System;

public class IAMovements : IA
{

    // Start is called before the first frame update
    PlayerStats player_stats;
    Quaternion rotation;
    void Start()
    {
        FindHealth();
        calculateNewMovementVector();
        latestDirectionChangeTime = 0f;
        for (int i = 0; i < nbrZombies; i++)
        {
            zombiesGO.Add(zombie);
            zombieArray[i].setPosition(zombieArray[i].getMoveSpeed(), gravity);
            zombiesGO[i].transform.position = zombieArray[i].getPosition();

        }
        movementPerSecond = movementDirection * 5;

    }

    //void gameLoop()
    //{
    void Update()
    {
        player_stats = GameObject.Find("SK_AR_02").GetComponent<PlayerStats>();

        //For every zombie

        for (int i = 0; i < zombiesGO.Count; i++)
        {


            //Distance between player and zombie

            zombieArray[i].setDistance(Target.position);
            //Debug.Log("Distance " + zombieArray[i].getDistance() + " VS " + lookAtDistance);
            //if (zombieS[i].distance > zombieS[i].lookAtDistance)
            //{

            if (Time.time - latestDirectionChangeTime > directionChangeTime && zombieArray[i].getDistance() > zombieArray[i].getLookAtDistance())
            {
                latestDirectionChangeTime = Time.time;
                calculateNewMovementVector();
            }

            else if (zombieArray[i].getDistance() < lookAtDistance)
            {
                movementDirection = new Vector3(Target.position.x - zombiesGO[i].transform.position.x, 0, Target.position.z - zombiesGO[i].transform.position.z).normalized;
                movementPerSecond = movementDirection * 7;
                rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                rotation = Quaternion.LookRotation(Target.position - zombiesGO[i].transform.position, Vector3.up);
                //  transform.position = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
                //transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.deltaTime * Damping);


                //zombieS[i]..transform.rotation = rotation;
            }

            //}
            if (Distance < chaseRange)
            {
                movementDirection = new Vector3(Target.position.x - zombiesGO[i].transform.position.x, 0, Target.position.z - zombiesGO[i].transform.position.z).normalized;
                movementPerSecond = movementDirection * 9;
                rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                rotation = Quaternion.LookRotation(Target.position - zombiesGO[i].transform.position, Vector3.up);
            }

            if (zombieArray[i].getIsAttacking() || zombieArray[i].getHP() < 0)
            {
                zombieArray[i].setMoveSpeed(0f);
                movementPerSecond = movementDirection * zombieArray[i].getMoveSpeed();

            }
            zombieArray[i].setMoveSpeed(20f);
            //zombieArray[i].setPosition(20, gravity);

            zombiesGO[i].transform.position = new Vector3(zombiesGO[i].transform.position.x + (movementPerSecond.x * Time.deltaTime), 0,
                zombiesGO[i].transform.position.z + (movementPerSecond.z * Time.deltaTime));
            rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            zombiesGO[i].transform.rotation = rotation;


            //Debug.Log("Zombie numero:" + zombiesGO[1].transform.position);
            //zombieS[i].transform.position = new Vector3(zombieS[i].transform.position.x + (movementPerSecond.x * Time.deltaTime), 0,
            //zombieS[i].transform.position.z + (movementPerSecond.z * Time.deltaTime));

            //zombiesGO[i].transform.position = zombieArray[i].getPosition();
            //  zombiesGO[i].transform.rotation = zombieArray[i].getRotation();
        }

    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Wall")
        {

            for (int i = 0; i < zombiesGO.Count; i++)
            {

                if (zombiesGO[i].transform.position.z > 0)
                {
                    movementDirection = new Vector3(zombiesGO[i].transform.position.x, 0, zombiesGO[i].transform.position.z).normalized;
                    movementPerSecond = movementDirection * 5;
                    zombiesGO[i].transform.position = -zombiesGO[i].transform.position;
                    Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    zombiesGO[i].transform.rotation = rotation;
                    //movementPerSecond *= -1;
                }
                if (zombiesGO[i].transform.position.z < 0)
                {
                    movementDirection = new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(zombiesGO[i].transform.position.z, 50.0f)).normalized;
                    movementPerSecond = movementDirection * 5;
                    zombiesGO[i].transform.position = -zombiesGO[i].transform.position;
                    Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    zombiesGO[i].transform.rotation = rotation;
                }
                if (zombiesGO[i].transform.position.x > 0)
                {
                    movementDirection = new Vector3(50f, 0, zombiesGO[i].transform.position.z).normalized;
                    movementPerSecond = movementDirection * 5;
                    zombiesGO[i].transform.position = -zombiesGO[i].transform.position;
                    Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    zombiesGO[i].transform.rotation = rotation;
                }
            }
        }
    }

}
