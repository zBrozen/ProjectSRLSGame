using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform player;
    public float safeDistance;
    public float shootInterval;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float lastShootTime;

    void Update() {
        if (player == null){
            gameObject.SetActive(false);
            return;
        }
        
        AdjustDistanceFromPlayer();
        TryToShoot();
    }

    private void AdjustDistanceFromPlayer() {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        float deadZone = 0.5f;

        if (distanceToPlayer < safeDistance - deadZone){
            Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized;
            transform.position += directionAwayFromPlayer * moveSpeed * Time.deltaTime;
        } else if (distanceToPlayer > safeDistance + deadZone) {
            Vector3 directionTowardsPlayer = (player.position - transform.position).normalized;
            transform.position += directionTowardsPlayer * moveSpeed * Time.deltaTime;
        } else if (distanceToPlayer == safeDistance) {
            Vector3 directionTowardsPlayer = (player.position - transform.position).normalized;
            float increasedMoveSpeed = moveSpeed * 1.5f;
            transform.position += directionTowardsPlayer * increasedMoveSpeed * Time.deltaTime;
        }

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        
        if (directionToPlayer != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, moveSpeed * Time.deltaTime);
        }
    }

    private void TryToShoot() {
        if (Time.time >= lastShootTime + shootInterval) {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private void Shoot() {
        if (bulletPrefab != null && firePoint != null) {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null) {
                bulletRb.velocity = firePoint.forward * bullet.GetComponent<BulletController>().bulletSpeed;
            }
        }
    }
}
