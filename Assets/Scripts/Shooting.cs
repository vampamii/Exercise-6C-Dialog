using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform gunTip; // Assign the muzzle of the gun in the Inspector
    public float shootingRange = 50f;
    public float damage = 10f;
    public LayerMask targetLayer; // Set this to "Enemy" layer in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Check if the gun animation is active
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, shootingRange, targetLayer))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Apply damage if the target has EnemyHealth
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}



