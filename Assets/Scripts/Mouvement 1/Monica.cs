using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class Monica : MonoBehaviour
{         
    private List<string> sentences;

    public string link;
    
    public GameObject canvas;

    private string[] splited;

    private int i;

    public GameObject ContinueButton;
    public GameObject MonicaAnswer;

    private bool Spoken;

    // Start is called before the first frame update
    void Start()
    {
        Begin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                canvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void WriteAnswer()
    {
        if(i == 0)
        {
            MonicaAnswer.GetComponent<TextMeshProUGUI>().text = sentences[i].Split('+')[0];
            ContinueButton.GetComponent<TextMeshProUGUI>().text = sentences[i].Split('+')[1];
            i++;
        }
        else
        {
            if (i < sentences.Count && sentences[i - 1].Split('+')[1] != " *End* ")
            {
                MonicaAnswer.GetComponent<TextMeshProUGUI>().text = sentences[i].Split('+')[0];
                ContinueButton.GetComponent<TextMeshProUGUI>().text = sentences[i].Split('+')[1];
                i++;
            }
            else
            {
                Spoken = true;
                Time.timeScale = 1f;
                canvas.SetActive(false);
            }
        }
        
              
    }

    public bool GetSpoken()
    {
        return Spoken;
    }

    private void Begin()
    {
        if (PlayerPrefs.GetInt("BigBossBeaten") == 0)
        {
            Spoken = false;

            string Ph = "Salut + **Elle est si belle** \n Je peux faire quelque chose pour toi ? +Heeeeeuu... \n Quand tu aura retrouvé tes mots, reviens me parler + *End* ";


            i = 0;
            sentences = new List<string>();


            foreach (string a in Ph.Split('\n'))
            {
                sentences.Add(a);
            }


            WriteAnswer();


            canvas.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("BigBossBeaten") == 1)
        {
            Spoken = false;

            string Ph = "Salut + Heu, bonjour \n Comment tu vas ? + Heu, je suis super content ! \n ah, super ! + oui je sais ... \n A une prochaine fois + *End* ";

            i = 0;
            sentences = new List<string>();


            foreach (string a in Ph.Split('\n'))
            {
                sentences.Add(a);
            }


            WriteAnswer();


            canvas.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("BigBossBeaten") == 3)
        {
            Spoken = false;

            string Ph = "Salut + Salut toi ! \n Comment tu vas ? + Bien mieux depuis que je te parle \n Quelque chose a changé chez toi non ? + Je ne sais pas, peut etre que tu as changé quelque chose chez moi \n Tu veux me dire quelque chose ? + Ca te tente de discuter autour d'un verre ? \n Allons-y, avec plaisir + *End* ";

            i = 0;
            sentences = new List<string>();


            foreach (string a in Ph.Split('\n'))
            {
                sentences.Add(a);
            }


            WriteAnswer();


            canvas.SetActive(false);

        }




        
    }
}
