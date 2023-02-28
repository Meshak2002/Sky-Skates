using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text sor;//game display
    public Text sco;//end display
    public Text sco2;
    public float score;
    public int intscore;
    public int hiscore;
    public int twohund=200,forty=40;
    public float points=10f;
    public bool onetime;
    public Total_coins_score tc;
    public GameObject neu; //new (highscore) txt
    public PlayerMovement pm;

    public int activate_score = 1000;

    // Update is called once per frame
    private void OnGUI(){
        sor.text=""+Mathf.Round(score);
        sco.text=intscore.ToString();
        sco2.text=intscore.ToString();
    }
    public void Start()
    {
        Debug.Log("time");
    }
    private void Update()
    {
        score+=points*Time.deltaTime;
        intscore=(int)score;


        if(((int)score-twohund==0 && onetime==false) && (int)score!=0){
              Debug.Log("time"); 
              pm.forwardM+=0.35f;
            pm.Movespeed = pm.Movespeed+pm.mosped;
            points += 2;
              twohund += 200;
              twohund += forty;
              forty += 40;
              onetime = true;
            StartCoroutine(wi());
            }
        
        if(intscore>hiscore){
             tc.SaveScore();
             neu.SetActive(true);
        }
    }
    IEnumerator wi()
    {
        yield return new WaitForSeconds(1);
        onetime = false;
    }
}
