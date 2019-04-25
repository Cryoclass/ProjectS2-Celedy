using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GereurMvt1 : MonoBehaviour
{
    public GameObject Yaelle;
    private Queue<int[]> Actions;
    public GameObject DialogueManager;
    private bool DialogueLaunched;
    public GameObject ButtonContinue;

    // Start is called before the first frame update
    void Start()
    {
        ButtonContinue.SetActive(true);
        DialogueLaunched = false;
        DialogueManager.SetActive(false);
        Actions = new Queue<int[]>();
        Actions.Enqueue(new int[2] { 0, -37 });
        Actions.Enqueue(new int[2] { -25, 0 });
        Actions.Enqueue(new int[2] { 150, 0 });
    }

    public void Declencheur()
    {
        if(Actions.Count == 1 && !DialogueLaunched)
        {
            ButtonContinue.SetActive(false);
            DialogueLaunched = true;
            DialogueManager.SetActive(true);
            DialogueManager.GetComponent<ParolesYa>().Speaking();
        }
        else if(Actions.Count != 0)
        {
            ButtonContinue.SetActive(true);
            DialogueManager.SetActive(false);
            int[] NextMove = Actions.Dequeue();
            Yaelle.GetComponent<DeplacementYa>().Depl(NextMove[0], NextMove[1]);
        }
        else
        {
            SceneManager.LoadScene("Game1");
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
