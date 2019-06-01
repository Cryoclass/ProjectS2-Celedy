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

        using (StreamReader myReader = new StreamReader(LinkBefore))
        {
            string RTE = myReader.ReadToEnd();
            foreach (string a in RTE.Split('\n'))
            {
                sentencesBefore.Add(a);
            }
        }

        using (StreamReader myReader = new StreamReader(LinkAfter))
        {
            string RTE = myReader.ReadToEnd();
            foreach (string a in RTE.Split('\n'))
            {
                sentencesAfter.Add(a);
            }
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
