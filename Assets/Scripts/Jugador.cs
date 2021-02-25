using System.Collections;
using UnityEngine;
using Photon.Pun;

public class Jugador : MonoBehaviourPun
{
    private TextMesh caption = null;
    int pos;
    bool movement;

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "Caption_Text")
            {
                caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                caption.text = string.Format("Jugador{0}", photonView.ViewID);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !movement)
            {
                Dice.Dice_Instance.RollDice();

                if (pos + Dice.Dice_Instance.random <= Circuito.Instance.Posicion.Count)
                {
                    StartCoroutine(Move());
                }
                else
                {
                    //Debug.Log("Resultado");
                }
            }
        }
    }

    IEnumerator Move()
    {
        if (movement)
        {
            yield break;
        }
        movement = true;

        while (Dice.Dice_Instance.random > 0)
        {
            Vector3 sigPos = Circuito.Instance.Posicion[pos + 0].position;
            while (MovetoNext(sigPos))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
            Dice.Dice_Instance.random--;
            pos++;
        }
        movement = false;
        Circuito.Instance.Cards();
    }

    bool MovetoNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}
