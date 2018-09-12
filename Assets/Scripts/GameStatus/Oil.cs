using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Oil : MonoBehaviour
{
    //  FUTURE STUB
    public GameObject[] AmountOfOil;

    public Text ScoreBanner;
    public int ValueOfOil = 0;
    public int CurrentScore = 0;

    private void Update()
    {
        ScoreBanner.text = "Score: " + CurrentScore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        // tag == "" creates overhead and adds garbage to the collection...
        // CompareTag == "" doesnt and uses almost no memory lol
        //if (other.tag == "Oil")
        if (!other.CompareTag("Oil")) return;
        print("we got hit");
        StartCoroutine(DestroyOil(other.gameObject));
    }

    private void ScoreUpdate(int newvalue)
    {
        CurrentScore += newvalue;
    }

    private IEnumerator DestroyOil(GameObject others)
    {
        yield return new WaitForSeconds(0.09f);
        others.SetActive(false);
        ScoreUpdate(ValueOfOil);
    }
}