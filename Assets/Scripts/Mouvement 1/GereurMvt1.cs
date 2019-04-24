using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GereurMvt1 : MonoBehaviour
{
    public GameObject Yaelle;
    private Queue<int[]> Actions;

    // Start is called before the first frame update
    void Start()
    {
        Actions = new Queue<int[]>();
        Actions.Enqueue(new int[2] { 0, -25 });
        Actions.Enqueue(new int[2] { -30, 0 });
        Actions.Enqueue(new int[2] { 100, 45 });
    }

    public void Declencheur()
    {
        if(Actions.Count !=0 )
        {
            int[] nextMoove = Actions.Dequeue();
            Yaelle.GetComponent<DeplacementYa>().Depl(nextMoove[0], nextMoove[1]);
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
