using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    public Transform target;
    
    NavMeshAgent agent;
  [SerializeField]  private float rotatespeed=10f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        rotate();
    }

    void rotate()
    {
        transform.up = Vector2.Lerp(transform.forward, target.position, Time.deltaTime * rotatespeed);
    }
}
