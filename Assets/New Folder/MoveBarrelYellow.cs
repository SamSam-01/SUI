using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrelYellow : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Update() {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                agent.SetDestination(hit.point);
            
        }
    }
}
