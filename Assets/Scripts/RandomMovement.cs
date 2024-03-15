using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important

//if you use this code you are contractually obligated to like the YT video
public class RandomMovement : MonoBehaviour //don't forget to change the script name if you haven't
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    float range; //radius of sphere

    [SerializeField]
    Transform centerPoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    [SerializeField]
    Transform goToWhenCaught;

    private float lastDestinationSetTime = 0f;
    private bool isCaught = false;

    [SerializeField]
    float stuckTimeout = 2f; // Change this value to adjust the stuck timeout duration

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isCaught)
        {
            agent.SetDestination(goToWhenCaught.position);
        }

        else if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centerPoint.position, range, out point)) //pass in our center point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
        
        else
        {
            // If the game object has been stuck for a certain amount of time, set a new destination
            if (Time.time - lastDestinationSetTime > stuckTimeout)
            {
                Vector3 point;
                if (RandomPoint(centerPoint.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    agent.SetDestination(point);
                    lastDestinationSetTime = Time.time;
                }
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    public void SetCaught()
    {
        this.isCaught = true;
    }

    public bool GetCaught()
    {
        return this.isCaught;
    }
}