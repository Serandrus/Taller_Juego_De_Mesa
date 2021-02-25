using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circuito : MonoBehaviour
{
    public static Circuito Instance;
    public List<Transform> Posicion = new List<Transform>();   ///Lista que obtiene las posiciones del jugador y las pone en orden.
    public Text card_Text;
    Transform[] lista;  ///Array de posiciones
    public string[] actions = { "Avanza 1 posición", "Regresar al inicio", "Avanza 5 posiciones", "Regresa 1 posición", "Regresa 5 posiciones" };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Posicion.Clear();
        lista = GetComponentsInChildren<Transform>();
        foreach (Transform child in lista)
        {
            if (child != this.transform)
            {
                Posicion.Add(child);
            }
        }
    }

    public void Cards()
    {
        card_Text.text = actions[Random.Range(0, actions.Length)];
    }
}
