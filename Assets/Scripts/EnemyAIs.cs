using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIs : MonoBehaviour
{
    private float lastShootTime;

    public void DoigbyAI(float moveSpeed, Transform player)
    {
        Vector3 direction = (player.position - transform.position).normalized;

        // Check if direction is not zero before looking
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    public void NormanAI(Transform player, float safeDistance, float moveSpeed, float shootInterval, GameObject bulletPrefab, Transform firePoint)
    {
        // Update movement and shooting simultaneously
        AdjustDistanceFromPlayer(player, safeDistance, moveSpeed);
        TryToShoot(shootInterval, bulletPrefab, firePoint);
    }

    private void AdjustDistanceFromPlayer(Transform player, float safeDistance, float moveSpeed)
    {
        // Calculate the current distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Define a dead zone around the safe distance
        float deadZone = 0.5f; // You can adjust this value for more or less sensitivity

        if (distanceToPlayer < safeDistance - deadZone)
        {
            // If too close, move away from the player
            Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized;
            transform.position += directionAwayFromPlayer * moveSpeed * Time.deltaTime;
        }
        else if (distanceToPlayer > safeDistance + deadZone)
        {
            // If too far, move towards the player
            Vector3 directionTowardsPlayer = (player.position - transform.position).normalized;
            transform.position += directionTowardsPlayer * moveSpeed * Time.deltaTime;
        }
        else if (distanceToPlayer == safeDistance)
        {
            // If at safe distance, move a little more towards the player
            Vector3 directionTowardsPlayer = (player.position - transform.position).normalized;
            float increasedMoveSpeed = moveSpeed * 1.5f; // Increase speed by 50%
            transform.position += directionTowardsPlayer * increasedMoveSpeed * Time.deltaTime;
        }

        // Always rotate towards the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        
        // Check if direction is not zero before looking
        if (directionToPlayer != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, moveSpeed * Time.deltaTime);
        }
    }

    private void TryToShoot(float shootInterval, GameObject bulletPrefab, Transform firePoint)
    {
        // Check if enough time has passed to shoot again
        if (Time.time >= lastShootTime + shootInterval)
        {
            Shoot(bulletPrefab, firePoint);
            lastShootTime = Time.time;
        }
    }

    private void Shoot(GameObject bulletPrefab, Transform firePoint)
    {
        float bulletSpeed = 5f;
        if (bulletPrefab != null && firePoint != null)
        {
            // Instantiate the bullet at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Apply force to the bullet
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = firePoint.forward * bulletSpeed;
            }
        }
    }
}
