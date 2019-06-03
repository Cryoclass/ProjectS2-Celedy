using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerFairy : MonoBehaviour
{
    private List<string> sentences;
    private int i;
    public GameObject WithModify;

    public GameObject ThePNJ;

    public GameObject canvas;

    private string[] splited;

    public List<GameObject> Monstres;

    // Start is called before the first frame update
    void Start()
    {
        string initial = "Qu'est ce que tu me veux toi?! + Euuh bonjour petite fée! + Détend toi parcontre! \n Ah oui hihi bonjour jeune garçon qui cherche une fée dans sa quête à la c**pour sauver une princesse qui l'a friendzone de toute façon! + elle m'a pas.. elle m'a pas friendzone... + Tu vas redescendre d'un ton jeune fille! \n Qu'est ce qu'il me veut le merdeux? Eh !Ecoute!retourne te taper un génocide en pensant que t'as raison c'est pas mes affaires!! + Toujours mieux que de rester dans une pièce toute la journée a fumer sa propre poudre + Pourquoi tu hurles comme ça? \n Bouffon... *End!* + + \n JE SUIS PAS UNE PETITE FILLE!+ Euh ? + Euh ? \n Je...euh.. (il semblerait que vous l'ayez vexée...) *End!* \n JE HURLE PAS! + OoooOooooOhhHhHHHH!!!! + JE VAIS TE CALMER MOI! \n Il semblerait que les cris aient attirés des monstres... *New Ally* \n Il semblerait que les cris aient attirés des monstres... *New Ally* \n + + \n + + \n (Votre cri d'animal gênerait n'importe qui...elle vous ignore) + *End !* + *End !* \n C'EST CE QU'ON VA VOIR! (Il semblerait que vos cris aient attirés des monstres...) + *New Ally* + *New Ally*";

        i = 0;
        sentences = new List<string>();
        sentences.Add("");



        foreach (string a in initial.Split('\n'))
        {
            sentences.Add(a);
        }

        Changed(1);
        canvas.SetActive(false);

    }

    public void Changed(int oupas)
    {       

        i = i * 2 + oupas;

        if (i < sentences.Count)
        {
            splited = sentences[i].Split('+');
            Debug.Log(splited);

            WithModify.GetComponent<DialPerso>().modify(splited[0], splited[1], splited[2]);

            if (splited[0] == " ' ")
            {
                Debug.Log("cassé?");
                canvas.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        else
        {
            if (splited[1] == " *New Ally* ")
            {
                foreach (GameObject mo in Monstres)
                {
                    Debug.Log("camarchepas");
                    Instantiate(mo, transform.position + new Vector3(0, 20), Quaternion.Euler(0, 0, 0));
                }
                ThePNJ.GetComponent<SpeakFairy>().DialogueSucceed(true);
                
                
            }
            else if (splited[1] == " *End!* ")
            {
                ThePNJ.GetComponent<SpeakFairy>().DialogueSucceed(false);
            }
            
            else
            {
                ThePNJ.GetComponent<SpeakFairy>().SetCanSpeak(false);
            }
            
            Time.timeScale = 1f;
        }

    }

    public void Activate()
    {
        canvas.SetActive(true);
    }

    public void Desactivate()
    {
        canvas.SetActive(false);
    }
}
