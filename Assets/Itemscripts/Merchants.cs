using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;
using TMPro;
public class Merchants : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshPro;
    private ItemSelector mItemSelector;
    private GetInput getinput;
    private GameObject imageObject;
    private SpriteLoader spriteLoader;
    private AnimatorScript animatorScript;
    private ButtonChanger buttonChanger;
    public Movement arm1movement;
    public Movement arm2movement;
    private RotateObject RotateObject;
    public enum Human
    {
        Buyer,
        Seller
    }
    string name = ("Untitled 15");
    private bool moving = false;
    private int y;
    private int rate;
    private int firstValue;
    private int secondValue;
    private int finalValue;
    private int anger;
    public TMP_Text text1;
    private Human human;
    private int temporarybuyer;
    private int temporaryseller;
    public void Dialog()
    {
        animatorScript.animator1.Rebind();
        animatorScript.animator2.Rebind();
        if (animatorScript != null)
        {
            animatorScript.Walk();
        }
        if (moving == false)
        {
            arm2movement.ForwardMovement();
            moving = true;
        }
        human = SelectionHuman();
        Debug.Log(SelectionHuman());
        mItemSelector = FindObjectOfType<ItemSelector>();
        getinput = FindObjectOfType<GetInput>();
        if (getinput == null)
        {
            Debug.LogError("GetInput!");
        }
        switch (human)
        {
            case Human.Buyer:
                y = mItemSelector.RandomItem();
                if (y == 0)
                {
                    TextMeshPro.text = ("Alabilecegim hicbir seyin yok.");
                    return;
                }
                rate = UnityEngine.Random.Range(80, 120);
                firstValue = mItemSelector.ItemValue() * rate / 100;
                TextMeshPro.text = (mItemSelector.ItemName() + " Baya iyimis.");
                TextMeshPro.text += ("Senden bu esyayi alabilmek icin " + firstValue + " kadar altin verebilirim.");
                TextMeshPro.text += ("Ne dersin ?");
                spriteLoader.SpriteLoad(name);
                if (animatorScript != null)
                {
                    animatorScript.Trigger();
                }
                //spriteLoader.SpriteLoad(mItemSelector.ItemName());
                break;
            case Human.Seller:
                if (mItemSelector.TotalLength() == 20)
                {
                    TextMeshPro.text = ("Sana esya satabilmem icin cantandani biraz bosaltmalisin.");
                }
                else
                {
                    y = mItemSelector.RandomItemTest();
                    while (mItemSelector.items.Exists(item => item.itemName == mItemSelector.itemsTest[y].itemName))
                    {
                        y = mItemSelector.RandomItemTest();
                    }
                    TextMeshPro.text = ("Ilgini cekebilcek esyalarim var evlat.");
                    rate = UnityEngine.Random.Range(80, 120);
                    firstValue = mItemSelector.ItemValueTest() * rate / 100;
                    TextMeshPro.text = (mItemSelector.ItemNameTest() + "'a bakmaya ne dersin?");
                    TextMeshPro.text += ("bu esyayi " + firstValue + " altina satabilirim.");
                    TextMeshPro.text += ("Ne dersin ?");
                    spriteLoader.SpriteLoad(name);
                    if (animatorScript != null)
                    {
                        animatorScript.Trigger();
                    }
                    //spriteLoader.SpriteLoad(mItemSelector.ItemNameTest());
                }
                break;
        }
    }
    public void CounterOffer()
    {
        if (TextMeshPro.text == null)
        {

        }
        else if (TextMeshPro.text == ("Bu is burda biter, dolandirici birader"))
        {

        }
        else if (TextMeshPro.text == ("bu fiyata anlastik"))
        {
            
        }
        else
        {
            int no;
            int angerRate;
            secondValue = getinput.ReadInput();
            switch (human)
            {
                case Human.Buyer:
                    imageObject = GameObject.Find(mItemSelector.items[y].itemName);
                    if (secondValue <= firstValue)
                    {
                        TextMeshPro.text = ("bu fiyata anlastik");
                        if (imageObject != null)
                        {
                            imageObject.SetActive(false);
                            mItemSelector.items.RemoveAt(y);
                        }
                        if (!int.TryParse(text1.text, out no))
                        {
                            Debug.Log("Deneme");
                        }
                        no += secondValue;
                        text1.text = no.ToString();
                        if (animatorScript != null)
                        {
                            animatorScript.ShakeTrigger();
                        }
                        delay();
                        spriteLoader.SpriteDeactive();
                        if (no > 10000)
                        {
                            gameOver();
                        }
                        arm2movement.BackMovement();
                        moving = false;
                        buttonChanger.buttonDisableLonger();
                        Invoke(nameof(DelayRotate), 2.65f);
                        Invoke(nameof(DelayRotate), 4.75f);
                    }
                    else if (secondValue >= firstValue * 3 / 2)
                    {
                        TextMeshPro.text = ("Bu is burda biter, dolandirici birader");
                        animatorScript.animator1.Rebind();
                        animatorScript.animator2.Rebind();
                        getinput.tmpInputField.text = null;
                        spriteLoader.SpriteDeactive();
                        arm2movement.MoveBack();
                        moving = false;
                        if (animatorScript != null)
                        {
                            animatorScript.Walk();
                        }
                        delayshort();
                        buttonChanger.buttonDisable();
                        Invoke(nameof(DelayRotate), 0f);
                        Invoke(nameof(DelayRotate), 1.57f);
                    }
                    else
                    {
                        int chance = UnityEngine.Random.Range(0, 6);
                        Debug.Log(chance);
                        if (chance == 0)
                        {
                            TextMeshPro.text = ("Bu is burda biter, dolandirici birader");
                            animatorScript.animator1.Rebind();
                            animatorScript.animator2.Rebind();
                            getinput.tmpInputField.text = null;
                            spriteLoader.SpriteDeactive();
                            arm2movement.MoveBack();
                            moving = false;
                            if (animatorScript != null)
                            {
                                animatorScript.Walk();
                            }
                            delayshort();
                            buttonChanger.buttonDisable();
                            Invoke(nameof(DelayRotate), 0f);
                            Invoke(nameof(DelayRotate), 1.57f);
                        }
                        else
                        {
                            Debug.Log(secondValue);
                            if (secondValue <= finalValue && temporarybuyer == 1)
                            {
                                temporarybuyer = 0;
                                TextMeshPro.text = ("anlastik");
                                if (imageObject != null)
                                {
                                    imageObject.SetActive(false);
                                    mItemSelector.items.RemoveAt(y);
                                }
                                if (!int.TryParse(text1.text, out no))
                                {
                                    Debug.Log("Deneme");
                                }
                                no += secondValue;
                                text1.text = no.ToString();
                                if (animatorScript != null)
                                {
                                    animatorScript.ShakeTrigger();
                                }
                                delay();
                                spriteLoader.SpriteDeactive();
                                if (no > 10000)
                                {
                                    gameOver();
                                }
                                arm2movement.BackMovement();
                                moving = false;
                                buttonChanger.buttonDisableLonger();
                                Invoke(nameof(DelayRotate), 2.65f);
                                Invoke(nameof(DelayRotate), 4.75f);

                            }
                            else
                            {
                                angerRate = Mathf.Abs(secondValue - firstValue);
                                anger = Mathf.Clamp(angerRate / 100, 0, 10);
                                int averagePrice = (firstValue + secondValue) / 2;
                                finalValue = averagePrice - ((averagePrice - firstValue) * anger / 10);
                                TextMeshPro.text = (finalValue + " bu fiyata ne dersin?");
                                temporarybuyer = 1;
                                Debug.Log(finalValue + " " + temporarybuyer);
                            }
                        }
                    }
                    break;
                case Human.Seller:
                    int money;
                    if (!int.TryParse(text1.text, out money))
                    {
                        Debug.Log("Deneme");
                    }
                    imageObject = GameObject.Find(mItemSelector.itemsTest[y].itemName);
                    if (secondValue >= firstValue)
                    {
                        if (money < secondValue)
                        {
                            notEnoughMoney();
                            spriteLoader.SpriteDeactive();
                            getinput.tmpInputField.text = null;
                            animatorScript.animator1.Rebind();
                            animatorScript.animator2.Rebind();
                            arm2movement.MoveBack();
                            moving = false;
                            if (animatorScript != null)
                            {
                                animatorScript.Walk();
                            }
                            delayshort();
                            buttonChanger.buttonDisable();
                            Invoke(nameof(DelayRotate), 0f);
                            Invoke(nameof(DelayRotate), 1.57f);
                        }
                        else
                        {
                            TextMeshPro.text = (secondValue + " bu fiyata anlastik");
                            if (!int.TryParse(text1.text, out no))
                            {
                                Debug.Log("Deneme");
                            }
                            no += -secondValue;
                            text1.text = no.ToString();
                            if (imageObject == null)
                            {
                                FindingDisabled();
                                mItemSelector.items.Add(mItemSelector.itemsTest[y]);
                            }
                            if (animatorScript != null)
                            {
                                animatorScript.ShakeTrigger();
                            }
                            delay();
                            spriteLoader.SpriteDeactive();
                            arm2movement.BackMovement();
                            moving = false;
                            buttonChanger.buttonDisableLonger();
                            Invoke(nameof(DelayRotate), 2.65f);
                            Invoke(nameof(DelayRotate), 4.75f);
                        }
                    }
                    else if (secondValue <= firstValue / 2)
                    {
                        TextMeshPro.text = ("Bu is burda biter, dolandirici birader");
                        animatorScript.animator1.Rebind();
                        animatorScript.animator2.Rebind();
                        getinput.tmpInputField.text = null;
                        spriteLoader.SpriteDeactive();
                        arm2movement.MoveBack();
                        moving = false;
                        if (animatorScript != null)
                        {
                            animatorScript.Walk();
                        }
                        delayshort();
                        buttonChanger.buttonDisable();
                        Invoke(nameof(DelayRotate), 0f);
                        Invoke(nameof(DelayRotate), 1.57f);
                    }
                    else
                    {
                        Debug.Log(secondValue);
                        Debug.Log(finalValue + " " + temporaryseller);
                        if (secondValue >= finalValue && temporaryseller == 1)
                        {
                            if (money < secondValue)
                            {
                                notEnoughMoney();
                                spriteLoader.SpriteDeactive();
                                getinput.tmpInputField.text = null;
                                animatorScript.animator1.Rebind();
                                animatorScript.animator2.Rebind();
                                arm2movement.MoveBack();
                                moving = false;
                                if (animatorScript != null)
                                {
                                    animatorScript.Walk();
                                }
                                delayshort();
                                buttonChanger.buttonDisable();
                                Invoke(nameof(DelayRotate), 0f);
                                Invoke(nameof(DelayRotate), 1.57f);
                            }
                            else
                            { 
                            temporaryseller = 0;
                            TextMeshPro.text = ("anlastik");
                            if (imageObject == null)
                            {
                                FindingDisabled();
                                mItemSelector.items.Add(mItemSelector.itemsTest[y]);
                            }
                            if (!int.TryParse(text1.text, out no))
                            {
                                Debug.Log("Deneme");
                            }
                            no += -secondValue;
                            text1.text = no.ToString();
                            if (animatorScript != null)
                            {
                                animatorScript.ShakeTrigger();
                            }
                            delay();
                            spriteLoader.SpriteDeactive();
                            if (no > 10000)
                            {
                                gameOver();
                            }
                            arm2movement.BackMovement();
                            moving = false;
                            buttonChanger.buttonDisableLonger();
                            Invoke(nameof(DelayRotate), 2.65f);
                            Invoke(nameof(DelayRotate), 4.75f);
                            }
                        }
                        else
                        {
                            angerRate = Mathf.Abs(secondValue - firstValue);
                            anger = Mathf.Clamp(angerRate / 100, 0, 10);
                            int averageprice = (firstValue + secondValue) / 2;
                            Debug.Log(finalValue + " " + temporaryseller);
                            temporaryseller = 1;
                            finalValue = averageprice - ((averageprice - firstValue) * anger / 10);
                            TextMeshPro.text = (finalValue + " bu fiyata ne dersin?");
                        }
                    }
                    break;
            }
        }
    }
    private void delay()
    {
        Invoke(nameof(Rebingding), 3f);
    }
    private void delayshort()
    {
        Invoke(nameof(Rebingding), 1f);
        Invoke(nameof(Teleport), 3f);
    }
    private void Teleport()
    {
        RotateObject.teleport();
    }
    private void DelayRotate()
    {
        RotateObject.NegativeObjectRotate();
        animatorScript.animator2.Rebind();
        animatorScript.animator1.Rebind();
    }
    private void Rebingding()
    {
        animatorScript.animator1.Rebind();
        animatorScript.animator2.Rebind();
        if (animatorScript != null)
        {
            animatorScript.Walk();
        }
    }
    public void Reset()
    {
        RotateObject.ObjectRotate();
        if (!string.IsNullOrEmpty(TextMeshPro.text))
        {
            arm2movement.MoveBack();
            animatorScript.animator1.Rebind();
            animatorScript.animator2.Rebind();
            if (animatorScript != null)
            {
                animatorScript.Walk();
            }
            delayshort();
        }
        TextMeshPro.text = null;
        spriteLoader.SpriteDeactive();
        moving = false;
        Invoke(nameof(DelayRotate), 1.57f);
    }
    public void DealAcceptance()
    {
        if (TextMeshPro.text == null)
        {

        }
        else if (TextMeshPro.text == ("Bu is burda biter, dolandirici birader"))
        {

        }
        else if (TextMeshPro.text == ("bu fiyata anlastik"))
        {

        }
        else
        {
            int no;
            switch (human)
            {
                case Human.Buyer:
                    imageObject = GameObject.Find(mItemSelector.items[y].itemName);
                    if (TextMeshPro.text.EndsWith("Ne dersin ?"))
                    {
                        TextMeshPro.text = (firstValue + " bu fiyata anlastik");
                        if (!int.TryParse(text1.text, out no))
                        {
                            Debug.Log("Deneme");
                        }
                        no += firstValue;
                    }
                    else
                    {
                        TextMeshPro.text = (finalValue + " bu fiyata anlastik");
                        if (!int.TryParse(text1.text, out no))
                        {
                            Debug.Log("Deneme");
                        }
                        no += finalValue;
                    }
                    if (imageObject != null)
                    {
                        imageObject.SetActive(false);
                        mItemSelector.items.RemoveAt(y); ;
                    }
                    text1.text = no.ToString();
                    spriteLoader.SpriteDeactive();
                    if (animatorScript != null)
                    {
                        animatorScript.ShakeTrigger();
                    }
                    delay();
                    if (no > 10000)
                    {
                        gameOver();
                    }
                    arm2movement.BackMovement();
                    moving = false;
                    TextMeshPro.text = null;
                    spriteLoader.SpriteDeactive();
                    Invoke(nameof(DelayRotate), 2.65f);
                    Invoke(nameof(DelayRotate), 4.75f);
                    break;
                case Human.Seller:
                    int money;
                    if (!int.TryParse(text1.text, out money))
                    {
                        Debug.Log("Deneme");

                    }
                    if (money < finalValue && money <firstValue || money==0)
                    {
                        notEnoughMoney();
                        spriteLoader.SpriteDeactive();
                        arm2movement.MoveBack();
                        moving = false;
                        if (animatorScript != null)
                        {
                            animatorScript.Walk();
                        }
                        delayshort();
                        Invoke(nameof(DelayRotate), 0f);
                        Invoke(nameof(DelayRotate), 1.57f);
                    }
                    else if (TextMeshPro.text.EndsWith("Ne dersin ?"))
                    {
                        TextMeshPro.text = (finalValue + " bu fiyata anlastik");
                        if (!int.TryParse(text1.text, out no))
                        {
                            Debug.Log("Deneme");
                        }
                        no += -firstValue;
                        text1.text = no.ToString();
                        if (imageObject == null)
                        {
                            FindingDisabled();
                            mItemSelector.items.Add(mItemSelector.itemsTest[y]);
                        }
                        if (animatorScript != null)
                        {
                            animatorScript.ShakeTrigger();
                        }
                        delay();
                        spriteLoader.SpriteDeactive();
                        arm2movement.BackMovement();
                        moving = false;
                        Invoke(nameof(DelayRotate), 2.65f);
                        Invoke(nameof(DelayRotate), 4.75f);
                    }
                    else
                    {
                        TextMeshPro.text = (finalValue + " bu fiyata anlastik");
                        if (!int.TryParse(text1.text, out no))
                        {
                            Debug.Log("Deneme");
                        }
                        no += -finalValue;
                        text1.text = no.ToString();
                        if (imageObject == null)
                        {
                            FindingDisabled();
                            mItemSelector.items.Add(mItemSelector.itemsTest[y]);
                        }
                        if (animatorScript != null)
                        {
                            animatorScript.ShakeTrigger();
                        }
                        delay();
                        spriteLoader.SpriteDeactive();
                        arm2movement.BackMovement();
                        moving = false;
                        Invoke(nameof(DelayRotate), 2.65f);
                        Invoke(nameof(DelayRotate), 4.75f);
                    }
                    TextMeshPro.text = null;
                    spriteLoader.SpriteDeactive();
                    break;
            }
        }
    }
    private void notEnoughMoney()
    {
        int money;
        if (!int.TryParse(text1.text, out money))
        {
            Debug.Log("Deneme");
        }
        TextMeshPro.text = ("Fakirsin oglum sen");
    }
    private void FindingDisabled()
    {
        ItemDisplay[] allObjects = FindObjectsOfType<ItemDisplay>(true);
        foreach (ItemDisplay obj in allObjects)
        {
            if (obj.gameObject.name == mItemSelector.itemsTest[y].itemName)
            {
                GameObject myDisabledObject = obj.gameObject;
                myDisabledObject.SetActive(true);
            }
        }
    }
    private Human SelectionHuman()
    {
        int selection = UnityEngine.Random.Range(0, 2);
        return (Human)selection;
    }
    private void gameOver()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Start()
    {
        RotateObject = FindAnyObjectByType<RotateObject>();
        buttonChanger = FindAnyObjectByType<ButtonChanger>();
        animatorScript = FindAnyObjectByType<AnimatorScript>();
        animatorScript.animator1 = GameObject.Find("Arm").GetComponent<Animator>();
        animatorScript.animator2 = GameObject.Find("Arm (1)").GetComponent<Animator>();
        spriteLoader = FindAnyObjectByType<SpriteLoader>();
        buttonChanger.buttonDisable();
        TextMeshPro.text = null;
        spriteLoader.SpriteDeactive();
        temporarybuyer = 0;
        temporaryseller = 0;
        if (animatorScript != null)
        {

            animatorScript.Walk();
        }
        Invoke(nameof(Rebingding), 1f);
        arm1movement.ForwardMovement();
        mItemSelector = FindObjectOfType<ItemSelector>();
        mItemSelector.RandomizeItem();
        int a = mItemSelector.TotalLength();
        for (int i = 0; i < 20; i++)
        {
            GameObject subobject = GameObject.Find(mItemSelector.itemsTest[i].itemName);
            if (mItemSelector.items.Exists(item => item.itemName == mItemSelector.itemsTest[i].itemName))
            {
                Debug.Log("BLABLA");
            }
            else
            {
                subobject.SetActive(false);
            }
        }

    }

}