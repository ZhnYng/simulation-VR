using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public Color cardColor;
    private bool isFlipped = false;

    void OnMouseDown()
    {
        if (!isFlipped)
        {
            FlipCard();
            GameMng.Instance.CardFlipped(this);
        }
    }

    public void FlipCard()
    {
        isFlipped = true;
        GetComponent<MeshRenderer>().material.color = cardColor;
    }

    public void ResetCard()
    {
        isFlipped = false;
        GetComponent<MeshRenderer>().material.color = Color.white; // assuming white is the back of the card
    }
}
