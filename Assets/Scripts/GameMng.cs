using UnityEngine;
using System.Collections;

public class GameMng : MonoBehaviour
{
    public static GameMng Instance;

    public GameObject[] cardPrefabs; // Array to hold card prefabs
    private CardBehavior firstFlipped, secondFlipped;
    private int score = 0;
    private float startTime;
    private bool gameStarted = false;
    private GameObject[] instantiatedCards; // To keep track of instantiated cards

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // The game setup logic is now moved to StartGame
    }

    public void StartGame()
    {
        SetupCards();
    }

    void SetupCards()
    {
        int totalCards = 6;
        instantiatedCards = new GameObject[totalCards];

        // Shuffle the card colors
        int[] cardIndices = { 0, 0, 1, 1, 2, 2 }; // 0: red, 1: blue, 2: green
        Shuffle(cardIndices);

        // Instantiate and position the cards in a 3x2 grid
        int index = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 position = new Vector3(j * 1.5f, 0, i * 2f); // Adjust spacing as needed
                GameObject card = Instantiate(cardPrefabs[cardIndices[index]], position, Quaternion.identity);
                instantiatedCards[index] = card;
                index++;
            }
        }
    }

    void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public void CardFlipped(CardBehavior card)
    {
        if (!gameStarted)
        {
            startTime = Time.time;
            gameStarted = true;
        }

        if (firstFlipped == null)
        {
            firstFlipped = card;
        }
        else
        {
            secondFlipped = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1);

        if (firstFlipped.cardColor == secondFlipped.cardColor)
        {
            score++;
            if (score == 3)
            {
                float totalTime = Time.time - startTime;
                Debug.Log("You win! Time taken: " + totalTime + " seconds");
            }
        }
        else
        {
            firstFlipped.ResetCard();
            secondFlipped.ResetCard();
        }

        firstFlipped = null;
        secondFlipped = null;
    }
}
