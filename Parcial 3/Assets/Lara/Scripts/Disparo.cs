using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

        public float detectionRadius = 10f;
        public LayerMask enemyLayer;
        public Transform weaponTransform;  // Este debe ser el punto "MuzzlePoint"
        public float fireRate = 0.5f;      // Tiempo entre disparos
        public GameObject projectilePrefab;  // Prefab del proyectil
        public float projectileSpeed = 20f;  // Velocidad del proyectil

        private Transform targetEnemy;
        private float nextFireTime = 0f;
        private Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
        {
            if (Input.GetMouseButton(1))  // Clic derecho
            {
                animator.SetBool("Disparando", true);
                FindClosestEnemy();
                if (targetEnemy != null)
                {
                    AimAtTarget();
                    if (Time.time >= nextFireTime)
                    {
                        Shoot();
                        nextFireTime = Time.time + fireRate;
                    }
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
            animator.SetBool("Disparando", false);

            }
    }

        void FindClosestEnemy()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
            float closestDistance = Mathf.Infinity;
            targetEnemy = null;

            foreach (Collider collider in hitColliders)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    targetEnemy = collider.transform;
                }
            }
        }

        void AimAtTarget()
        {
            Vector3 directionToTarget = targetEnemy.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        void Shoot()
        {
            if (projectilePrefab != null && weaponTransform != null)
            {
                // Instancia el proyectil en el punto de disparo y orientado en la direcci�n recta del arma
                GameObject projectile = Instantiate(projectilePrefab, weaponTransform.position, weaponTransform.rotation);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = -weaponTransform.forward * projectileSpeed;  // Dispara en la direcci�n de weaponTransform
                }
            }
        }
    




}
