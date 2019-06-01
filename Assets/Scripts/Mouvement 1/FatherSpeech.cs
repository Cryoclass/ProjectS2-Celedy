using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class FatherSpeech : MonoBehaviour
{

    private List<string> sentencesBefore;
    private List<string> sentencesAfter;

    public string LinkBefore;
    public string LinkAfter;

    public GameObject canvas;

    private string[] splited;

    private int i1;
    private int i2;

    public GameObject ContinueButton;
    public GameObject MonicaAnswer;

    public GameObject Monica;

    // Start is called before the first frame update
    void Start()
    {
        LinkAfter = "Tu t'es fait recale ? bah, ca arrive + Mais, tu m'avais dit que ... \n Je t'avais dit d'essayer !pas d'y arriver + Mais, je la trouvais migonne ... \n Ce fut drole pour moi, mais a toi, il reste une solution + C'est quoi papa ? \n Passe par ce portail, et tente de ne pas succomber + Il y a quoi dans ce portail \n Du mystere, et surtout, tes plus grandes peurs. + Mais ca me servira a quoi? \n Peut etre que avec quelques cicatrices, elle t'appreciera plus ?! + *End* ";
        LinkBefore = "Regarde toi, fils, et regarde la elle ! + Mais ... quoi papa ? \n Qu'attends tu ? Fonce ! + Tu es sur ? \n Pose pas de questions gamin, embraye et accelère + *End * ";
        Begin();
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
        if (Monica.GetComponent<Monica>().GetSpoken())
        {
            if (i2 == 0)
            {
                MonicaAnswer.GetComponent<TextMeshProUGUI>().text = sentencesAfter[i2].Split('+')[0];
                ContinueButton.GetComponent<TextMeshProUGUI>().text = sentencesAfter[i2].Split('+')[1];
                i2++;
            }
            else
            {
                if (i2 < sentencesAfter.Count && sentencesAfter[i2 - 1].Split('+')[1] != " *End* ")
                {
                    MonicaAnswer.GetComponent<TextMeshProUGUI>().text = sentencesAfter[i2].Split('+')[0];
                    ContinueButton.GetComponent<TextMeshProUGUI>().text = sentencesAfter[i2].Split('+')[1];
                    i2++;
                }
                else
                {
                    try
                    {
                        GameObject.FindGameObjectWithTag("Portal").GetComponent<PortalExitIntro>().OpenIt();
                    }
                    catch (System.Exception)
                    {
                    }                    
                    Time.timeScale = 1f;
                    canvas.SetActive(false);
                }
            }
        }
        else
        {
            if (i1 == 0)
            {
                MonicaAnswer.GetComponent<TextMeshProUGUI>().text = sentencesBefore[i1].Split('+')[0];
                ContinueButton.GetComponent<TextMeshProUGUI>().text = sentencesBefore[i1].Split('+')[1];
                i1++;
            }
            else
            {
                if (i1 < sentencesBefore.Count && sentencesBefore[i1 - 1].Split('+')[1] != " *End* ")
                {
                    MonicaAnswer.GetComponent<TextMeshProUGUI>().text = sentencesBefore[i1].Split('+')[0];
                    ContinueButton.GetComponent<TextMeshProUGUI>().text = sentencesBefore[i1].Split('+')[1];
                    i1++;
                }
                else
                {
                    Time.timeScale = 1f;
                    canvas.SetActive(false);
                }
            }
        }
    }

    private void Begin()
    {
        i1 = 0;
        i2 = 0;
        sentencesBefore = new List<string>();
        sentencesAfter = new List<string>();


        foreach (string a in LinkBefore.Split('\n'))
        {
            sentencesBefore.Add(a);
        }




        foreach (string a in LinkAfter.Split('\n'))
        {
            sentencesAfter.Add(a);
        }


        WriteAnswer();

        try
        {
            GameObject.FindGameObjectWithTag("Portal").GetComponent<PortalExitIntro>().CloseIt();
        }
        catch (System.Exception)
        {
        }


        canvas.SetActive(false);
    }
}
