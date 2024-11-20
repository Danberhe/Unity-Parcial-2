using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{

    public Text info;

    
    // Start is called before the first frame update
    void Start()
    {
        info.text = "Debo...encontrar la carta.";
    }

    public IEnumerator efectPildora(MovPersonaje personaje)
    {
        personaje.salud += 25;
        //Destroy(gameObject);
        info.text = "has encontrado frasco de píldoras curativas. 25 de vida extra.";
        string mensaje = info.text;
        yield return StartCoroutine(Typing(mensaje));
        yield return new WaitForSeconds(8.0f);
        info.text = "";
        

    }


    public IEnumerator Recargador(Disparo disparo)
    {
        disparo.balasDisp += 30;

        info.text = "has encontrado un cargador para tu arma. 30 de munición extra.";
        string mensaje = info.text;
        yield return StartCoroutine(Typing(mensaje));
        yield return new WaitForSeconds(8.0f);
        info.text = "";

    }


    private IEnumerator Typing(string mensaje)//efecto en la letra
    {
        info.text = "";
        foreach (char letter in mensaje.ToCharArray())
        {
            info.text += letter;  
            yield return new WaitForSeconds(0.003f); 
        }
    }
    

}
