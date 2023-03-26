using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public coins c;
    public Text txt;
    public GameObject bx1;
    public GameObject bx2;
    public GameObject by1;
    public GameObject by2;
    public GameObject bz1;
    public GameObject bz2;
    public GameObject bx1_;
    public GameObject bx2_;
    public GameObject by1_;
    public GameObject by2_;
    public GameObject bz1_;
    public GameObject bz2_;
    private int x1=2;
    private int x2=3500;
    private int y1=7000;
    private int y2=1000;
    private int z1=2100;
    private int z2=10000;
    public GameObject edx1;
    public GameObject edx2;
    public GameObject edy1;
    public GameObject edy2;
    public GameObject edz1;
    public GameObject edz2;
    public GameObject box1;
    public GameObject box2;
    public GameObject boy1;
    public GameObject boy2;
    public GameObject boz1;
    public GameObject boz2;
    public GameObject startcanvas;
    public GameObject self;
    private const string boughtx1="x1";
    private const string boughtx2="x2";
    private const string boughty1="y1";
    private const string boughty2="y2";
    private const string boughtz1="z1";
    private const string boughtz2="z2";
    private const string equippef="equiped";
    private int pefx1;
    private int pefx2;
    private int pefy1;
    private int pefy2;
    private int pefz1;
    private int pefz2;
    private int pefequip;
    public int totcoins;
    public Total_coins_score tcs;
    public Button Left, Right;
    public RectTransform content;
    public float currentPos;
    public AudioSource swipe,bought,eq,nmsound;
    public GameObject nomoney;
    Animator an;
    public static ShopManager sm;
    private void Start()
    {
        if (sm == null)
        {
            sm = this;
        }
        an = nomoney.GetComponent<Animator>();
        pefx1 =PlayerPrefs.GetInt(boughtx1);
        pefx2=PlayerPrefs.GetInt(boughtx2);
        pefy1=PlayerPrefs.GetInt(boughty1);
        pefy2=PlayerPrefs.GetInt(boughty2);
        pefz1=PlayerPrefs.GetInt(boughtz1);
        pefz2=PlayerPrefs.GetInt(boughtz2);
        pefequip=PlayerPrefs.GetInt(equippef);
        if(pefx1==1){
            bx1.SetActive(false);
            bx1_.SetActive(true);
        }
        if(pefx2==1){
            bx2.SetActive(false);
            bx2_.SetActive(true);
        }
        if(pefy1==1){
            by1.SetActive(false);
            by1_.SetActive(true);
        }
        if(pefy2==1){
            by2.SetActive(false);
            by2_.SetActive(true);
        }
        if(pefz1==1){
            bz1.SetActive(false);
            bz1_.SetActive(true);
        }
        if(pefz2==1){
            bz2.SetActive(false);
            bz2_.SetActive(true);
        }
        if(pefequip==1){
            onclick_x1e();
        }
        if(pefequip==2){
            onclick_x2e();
        }
        if(pefequip==3){
            onclick_y1e();
        }
        if(pefequip==4){
            onclick_y2e();
        }
        if(pefequip==5){
            onclick_z1e();
        }
        if(pefequip==6){
            onclick_z2e();
        }
        //Skate_Scroll_POsition
        currentPos = PlayerPrefs.GetFloat("currentPos");
        content.anchoredPosition = new Vector2(currentPos, content.anchoredPosition.y);
        Debug.Log(currentPos);

        Left.onClick.AddListener(Lefft);
        Right.onClick.AddListener(Rigght);
    }

    // Update is called once per frame
    private void Update(){
        txt.text=""+c.Totalcoins;
        totcoins=c.Totalcoins;
        if (an.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            nomoney.SetActive(false);
        }
    }
    public void Lefft()
    {
        //Debug.Log("LFT");
        if (content.position.x < 0)
        {
            swipe.Play();
            nomoney.SetActive(false);
            content.anchoredPosition = new Vector2(content.anchoredPosition.x + 200, content.anchoredPosition.y);
            PlayerPrefs.SetFloat("currentPos", content.anchoredPosition.x);
            currentPos = content.anchoredPosition.x;
        }
    }public void Rigght()
    {
        if (currentPos/(-200) < content.transform.childCount-1)
        {
            swipe.Play();
            nomoney.SetActive(false);
            content.anchoredPosition = new Vector2(content.anchoredPosition.x - 200, content.anchoredPosition.y);
            PlayerPrefs.SetFloat("currentPos", content.anchoredPosition.x);
            currentPos = content.anchoredPosition.x;
        }
    }
    public void onclic_x1()
    {
        if(c.Totalcoins>=x1){
            bought.Play();
            c.Totalcoins-=x1;
            tcs.SaveCoins();
            bx1.SetActive(false);
            bx1_.SetActive(true);
            PlayerPrefs.SetInt(boughtx1,1);
        }
        else
        {
            nomoney.SetActive(true);
            nmsound.Play();
        }
    }
     public void onclic_x2()
    {
        if(c.Totalcoins>=x2){
            bought.Play();
            c.Totalcoins-=x2;
            tcs.SaveCoins();
            bx2.SetActive(false);
            bx2_.SetActive(true);
            PlayerPrefs.SetInt(boughtx2,1);
        }
        else
        {
            nomoney.SetActive(true);
            nmsound.Play();

        }
    }
     public void onclic_y1()
    {
        if(c.Totalcoins>=y1){
            bought.Play();
            c.Totalcoins-=y1;
            tcs.SaveCoins();
            by1.SetActive(false);
            by1_.SetActive(true);
            PlayerPrefs.SetInt(boughty1,1);
        }
        else
        {
            nomoney.SetActive(true);
            nmsound.Play();
        }
    }
     public void onclic_y2()
    {
        if(c.Totalcoins>=y2){
            bought.Play();
            c.Totalcoins-=y2;
            tcs.SaveCoins();
            by2.SetActive(false);
            by2_.SetActive(true);
            PlayerPrefs.SetInt(boughty2,1);
        }
        else
        {
            nomoney.SetActive(true);
            nmsound.Play();
        }
    }
     public void onclic_z1()
    {
        if(c.Totalcoins>=z1){
            bought.Play();
            c.Totalcoins-=z1;
            tcs.SaveCoins();
            bz1.SetActive(false);
            bz1_.SetActive(true);
            PlayerPrefs.SetInt(boughtz1,1);
        }
        else
        {
            nomoney.SetActive(true);
            nmsound.Play();
        }
    }
     public void onclic_z2()
    {
        if(c.Totalcoins>=z2){
            bought.Play();
            c.Totalcoins-=z2;
            tcs.SaveCoins();
            bz2.SetActive(false);
            bz2_.SetActive(true);
            PlayerPrefs.SetInt(boughtz2,1);
        }
        else
        {
            nomoney.SetActive(true);
            nmsound.Play();
        }
    }
    public void onclick_x1e(){
        
        if (bx1_.transform.GetChild(0).gameObject.activeSelf == true && self.activeSelf==true)
        {
            eq.Play();
        }
        equipShow();
        bx1_.transform.GetChild(0).gameObject.SetActive(false);
        edx1.SetActive(true);
        edx2.SetActive(false);
        edy1.SetActive(false);
        edy2.SetActive(false);
        edz1.SetActive(false);
        edz2.SetActive(false);
        box1.SetActive(true);
        box2.SetActive(false);
        boy1.SetActive(false);
        boy2.SetActive(false);
        boz1.SetActive(false);
        boz2.SetActive(false);
        PlayerPrefs.SetInt(equippef,1);
    }
    public void onclick_x2e(){
        
        if (bx2_.transform.GetChild(0).gameObject.activeSelf == true && self.activeSelf == true)
        {
            eq.Play();
        }
        equipShow();
        bx2_.transform.GetChild(0).gameObject.SetActive(false);
        edx1.SetActive(false);
        edx2.SetActive(true);
        edy1.SetActive(false);
        edy2.SetActive(false);
        edz1.SetActive(false);
        edz2.SetActive(false);
        box1.SetActive(false);
        box2.SetActive(true);
        boy1.SetActive(false);
        boy2.SetActive(false);
        boz1.SetActive(false);
        boz2.SetActive(false);
         PlayerPrefs.SetInt(equippef,2);
    }
    public void onclick_y1e(){
        
        if (by1_.transform.GetChild(0).gameObject.activeSelf == true && self.activeSelf == true)
        {
            eq.Play();
        }
        equipShow();
        by1_.transform.GetChild(0).gameObject.SetActive(false);
        edx1.SetActive(false);
        edx2.SetActive(false);
        edy1.SetActive(true);
        edy2.SetActive(false);
        edz1.SetActive(false);
        edz2.SetActive(false);
        box1.SetActive(false);
        box2.SetActive(false);
        boy1.SetActive(true);
        boy2.SetActive(false);
        boz1.SetActive(false);
        boz2.SetActive(false);
         PlayerPrefs.SetInt(equippef,3);
    }
    public void onclick_y2e(){
        
        if (by2_.transform.GetChild(0).gameObject.activeSelf == true && self.activeSelf == true)
        {
            eq.Play();
        }
        equipShow();
        by2_.transform.GetChild(0).gameObject.SetActive(false);
        edx1.SetActive(false);
        edx2.SetActive(false);
        edy1.SetActive(false);
        edy2.SetActive(true);
        edz1.SetActive(false);
        edz2.SetActive(false);
        box1.SetActive(false);
        box2.SetActive(false);
        boy1.SetActive(false);
        boy2.SetActive(true);
        boz1.SetActive(false);
        boz2.SetActive(false);
         PlayerPrefs.SetInt(equippef,4);
    }
    public void onclick_z1e(){
        if (bz1_.transform.GetChild(0).gameObject.activeSelf == true && self.activeSelf == true)
        {
            eq.Play();
        }
        equipShow();
        bz1_.transform.GetChild(0).gameObject.SetActive(false);
        edx1.SetActive(false);
        edx2.SetActive(false);
        edy1.SetActive(false);
        edy2.SetActive(false);
        edz1.SetActive(true);
        edz2.SetActive(false);
        box1.SetActive(false);
        box2.SetActive(false);
        boy1.SetActive(false);
        boy2.SetActive(false);
        boz1.SetActive(true);
        boz2.SetActive(false);
         PlayerPrefs.SetInt(equippef,5);
    }
    public void onclick_z2e(){
       
        if (bz2_.transform.GetChild(0).gameObject.activeSelf == true && self.activeSelf == true)
        {
            eq.Play();
        }
        equipShow();
        bz2_.transform.GetChild(0).gameObject.SetActive(false);
        edx1.SetActive(false);
        edx2.SetActive(false);
        edy1.SetActive(false);
        edy2.SetActive(false);
        edz1.SetActive(false);
        edz2.SetActive(true);
        box1.SetActive(false);
        box2.SetActive(false);
        boy1.SetActive(false);
        boy2.SetActive(false);
        boz1.SetActive(false);
        boz2.SetActive(true);
         PlayerPrefs.SetInt(equippef,6);
    }
    public void equipShow()
    {
        bx1_.transform.GetChild(0).gameObject.SetActive(true);
        bx2_.transform.GetChild(0).gameObject.SetActive(true);
        by1_.transform.GetChild(0).gameObject.SetActive(true);
        by2_.transform.GetChild(0).gameObject.SetActive(true);
        bz1_.transform.GetChild(0).gameObject.SetActive(true);
        bz2_.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void onback(){
        startcanvas.SetActive(true);
        self.SetActive(false);
        nomoney.SetActive(false);
    }
}
