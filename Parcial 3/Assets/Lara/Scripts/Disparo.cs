using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform weaponTransform;
    public float TimeDisparo = 0.5f; // Tiempo entre disparos
    public GameObject Balaprefa; // Prefab del proyectil
    public float velBala = 20f; // Velocidad del proyectil

    private float nextFireTime = 0f;
    private Animator animator;

    public AudioSource sinBala;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detectar disparo al hacer clic izquierdo
        if (Input.GetMouseButton(0))
        {
            // Activar animación de disparo
            animator.SetBool("Disparando", true);

            // Verificar si es el momento de disparar
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + TimeDisparo;
            }
        }
        else
        {
            // Detener la animación si no se está disparando
            animator.SetBool("Disparando", false);
        }
    }

    void Shoot()
    {
        if (Balaprefa != null && weaponTransform != null) // Asegúrate de que haya un prefab asignado
        {
            // Instanciar el proyectil en el punto de disparo y orientado según la rotación actual del arma
            GameObject projectile = Instantiate(Balaprefa, weaponTransform.position, weaponTransform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = -weaponTransform.forward * velBala; // Proyectil viaja hacia adelante
            }
        }
        
    }
}

