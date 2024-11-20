using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    public ItemsManager itemsManager;
    
    public Transform weaponTransform;
    public float TimeDisparo = 0.5f;
    public GameObject Balaprefa;
    public float velBala = 20f;
    
    private float nextFireTime = 0f;
    private Animator animator;

    public AudioSource sinBala;

    public float balasDisp = 120f;

    public Text balasInfo;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        balasInfo.text = "Munición: " + balasDisp.ToString() + " / 500";
        
        if (Input.GetMouseButton(0))
        {
           
            animator.SetBool("Disparando", true);

            
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + TimeDisparo;
            }
        }
        else
        {
            
            animator.SetBool("Disparando", false);
        }
    }

    void Shoot()
    {
        if(balasDisp > 0 ){

            if (Balaprefa != null && weaponTransform != null)
            {
                
                GameObject projectile = Instantiate(Balaprefa, weaponTransform.position, weaponTransform.rotation);
                balasDisp--;

                Rigidbody rb = projectile.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = -weaponTransform.forward * velBala;
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
            StartCoroutine(itemsManager.Recargador(this));
            //ItemsManager.Instance.StartCoroutine(Recargador(balasDisp));
            Destroy(collision.gameObject);

        }
    }
}

