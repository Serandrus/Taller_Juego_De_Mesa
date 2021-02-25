using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public static Dice Dice_Instance;
    public Text dice_Text;
    public int random;

    private void Awake()
    {
        dice_Text.text = "";

        if (Dice_Instance == null)
        {
            Dice_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RollDice()
    {
        random = Random.Range(1, 7);
        dice_Text.text = "" + random;
    }

}
