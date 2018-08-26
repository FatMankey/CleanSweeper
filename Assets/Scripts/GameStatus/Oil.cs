using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oil : MonoBehaviour {
    //  FUTURE STUB
    //public GameObject[] AmountOfOil;
    public Text ScoreBanner;
    public int ValueOfOil = 0;
    public int CurrentScore = 0;
    private void Update() {
        
    ScoreBanner.text = "Score: " + CurrentScore.ToString();
  
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Oil") {
            print("we got hit");
            StartCoroutine(destroyOil(other.gameObject));
        }
    }

    void ScoreUpdate(int newvalue) {
        CurrentScore += newvalue;
    }
    IEnumerator destroyOil(GameObject others) {
        yield return new WaitForSeconds(0.09f);
        others.SetActive(false);
        ScoreUpdate(ValueOfOil);
    }
}
