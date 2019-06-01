using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerBird : MonoBehaviour
{
    private List<string> sentences;
    private int i;
    public GameObject WithModify;

    public GameObject ThePNJ;

    public GameObject canvas;

    private string[] splited;

    // Start is called before the first frame update
    void Start()
    {
        string initial = "Il fait un froid de canard... + Grave + Je crois bien que c'est pas la seule chose qui va nous y faire laisser des plumes... \n T'as l'air d'un ennui mortel... + Si t'as quelque chose contre moi dit le tout de suite! + Oui... \n T'es un sacré rigolo, mais crois moi qu'a ce jeu la c'est moi qui vait te clouer le bec + Brrr j'en ai la chair de poule + T'es cinglée... \n Mais je viens de le dire! + Tu sais que c'est pas parce que je suis pas hilarant maintenant que c'est aussi le cas tout le temps?! + Pardon... \n ' + ' + ' \n Tien tien, ce drôle d'oiseau sortit de nul part se sent pousser des ailes? + On dirait bien que tes blagues battent de l'aile, la seule chose qu'elles arrivent a faire c'est me faire bailler aux corneilles. + T'es cinglée... \n ' + ' + ' \n Wow Calme toi! Je t'ai pas agressé non plus! + C'est vraiment pas sympa ni intelligent de juger quelqu'un comme ça avec un seul mot alors qu'au fond il peut être très intéressant et drôle et sensible avec un sacré passé triste et cool. + Pardon... \n ' + ' + ' \n ' + ' + ' \n ' + ' + ' \n Haha, t'es un drôle d'oiseau, mais j'avais besoin de quelqu'un de gai comme un pinson. + *New Ally* + *New Ally* \n T'es cinglée... + *End* + *End* ";

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
        Debug.Log("Les boutons marchent");

        i = i * 2 + oupas;

        if (i < sentences.Count)
        {
            splited = sentences[i].Split('+');

            WithModify.GetComponent<DialPerso>().modify(splited[0], splited[1], splited[2]);

            if (splited[0] == " ' ")
            {
                canvas.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        else
        {
            if (splited[1] == " *New Ally* ")
            {
                ThePNJ.GetComponent<BirdPNJ>().DialogueSucceed(true);
            }
            else if (splited[1] == " *Start Fight* ")
            {
                ThePNJ.GetComponent<BirdPNJ>().DialogueSucceed(false);
            }
            else
            {
                ThePNJ.GetComponent<BirdPNJ>().SetCanSpeak(false);
            }
            canvas.SetActive(false);
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
