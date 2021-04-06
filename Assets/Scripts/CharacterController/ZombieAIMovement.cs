using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAIMovement : MonoBehaviour
{
    public PlayerMovement player;
    private CharacterMovement charMove;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        charMove = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.GetComponent<CharacterMovement>().rch.point;// transform.position;
        Vector3 moveDir = (agent.path.corners[0] - gameObject.transform.position);
        moveDir.y = 0;
        Debug.Log(moveDir.normalized);
        //charMove.Move(moveDir.normalized, false);
        charMove.Move(agent.desiredVelocity, false);
        //charMove.Move((player.transform.position - gameObject.transform.position).normalized, false);
        Debug.DrawLine(gameObject.transform.position, agent.path.corners[0]);
        if (agent.path.corners.Length >= 1)
        {
            for (int i = 1; i < agent.path.corners.Length; ++i)
            {
                Debug.DrawLine(agent.path.corners[i - 1], agent.path.corners[i], Color.yellow);
            }
        }

    }
}
