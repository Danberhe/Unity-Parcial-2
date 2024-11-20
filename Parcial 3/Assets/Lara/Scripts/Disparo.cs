using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    public ItemsManager itemsManager;
    
    public Transform weaponTransform;
    public float TimeDisparo = 0.5f; // Tiempo entre disparos
    public GameObject Balaprefa; // Prefab del proyectil
    public float velBala = 20f; // Velocidad del proyectil
    
    private float nextFireTime = 0f;
    private Animator animator;

    public AudioSource sinBala;

    public float balasDisp = 3f;

    public Text indBalas;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        indBalas.text = "Munición: " + balasDisp.ToString() + " / 400";
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
        if(balasDisp > 0 ){

            if (Balaprefa != null && weaponTransform != null) // Asegúrate de que haya un prefab asignado
            {
                // Instanciar el proyectil en el punto de disparo y orientado según la rotación actual del arma
                GameObject projectile = Instantiate(Balaprefa, weaponTransform.position, weaponTransform.rotation);
                balasDisp--;

                Rigidbody rb = projectile.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = -weaponTransform.forward * velBala; // Proyectil viaja hacia adelante
                }
            }else{
                Debug.Log("SE ACABOO");
                sinBala.Play();
            }
        }
        
    }



    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "municion")
        {
            Debug.Log("entro a municion");
            StartCoroutine(itemsManager.Recargador(balasDisp));
            //ItemsManager.Instance.StartCoroutine(Recargador(balasDisp));

        }
    }
}

