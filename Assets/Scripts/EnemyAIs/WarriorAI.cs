using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform player;

    void Update() {
        if (player == null){
            gameObject.SetActive(false);
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;

        if (direction != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
