using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {

    private Vector2 target;

    private NavMeshAgent navMeshAgent;

    void Start() {
        target = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        navMeshAgent.SetDestination(target);

    }
}