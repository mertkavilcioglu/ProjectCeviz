
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchants : ItemSelector
{
    private GetInput getinput;

    public enum Human
    {
        Buyer,
        Seller
    }



    private int textValue;
    private int rate;
    private int totalValue;
    private int tolerance = 100;
    private int toleranceRate;
    private int finalValue;
    public Human human;
    void Start()
    {
        getinput = FindObjectOfType<GetInput>(); 
        if (getinput == null)
        {
            Debug.LogError("GetInput script not found in the scene!");
        }
        
        int x=RandomItem();
        GameObject imageObject = GameObject.Find("Image" + x);


        switch (human)
        {
            case Human.Buyer:
                if (x == 0)
                {
                    Debug.Log("Alabilecegim hicbir seyin yok.");
                }
                else
                {

                    rate = Random.Range(80, 120);
                    totalValue = ItemValue() * rate / 100;
                    Debug.Log(ItemName() + " Baya iyimis");
                    Debug.Log("Sana bu esya icin " + totalValue + " kadar altin verebilirim");
                    Debug.Log("Ne dersin?");
                    textValue = getinput.ReadInput();
                    if (textValue <= totalValue )
                    {
                        Debug.Log("Anlastik");
                        
                        if (imageObject != null)
                        {
                            imageObject.SetActive(false);
                        }

                    }

                    else
                    {
                        toleranceRate = tolerance * (totalValue - textValue) / textValue;
                        if (toleranceRate > 70)
                        {
                            Debug.Log("Yuh");
                        }
                        else 
                        {
                            finalValue = totalValue - (totalValue - textValue) * (tolerance - toleranceRate) / 100;
                            Debug.Log(finalValue + " bu fiyata anlastik");
                            
                            if (imageObject != null)
                            {
                                imageObject.SetActive(false);
                            }

                        }
                        //finalvalue=firstvalue*(tolerance-toleranceRate)/100;//


                    }

                }
                break;

            case Human.Seller:
                if (TotalLength() == 20)
                {
                    Debug.Log("Sana esya satabilmem icin cantandani biraz bosaltmalisin.");
                }
                else
                {
                    Debug.Log("Ilgini cekebilcek esyalarim var evlat");
                    rate = Random.Range(80, 120);
                    totalValue = ItemValue() * rate / 100;
                    Debug.Log(ItemName() + "'a bakmaya ne dersin");
                    Debug.Log("bu esyayi " + totalValue + " altina satabilirim");
                    Debug.Log("Ne dersin?");
                    textValue = getinput.ReadInput();
                    if (textValue >= totalValue * 110 / 100)
                    {
                        Debug.Log("Anlastik");
                        
                        if (imageObject != null)
                        {
                            imageObject.SetActive(true);
                        }

                    }

                    else
                    {
                        toleranceRate = tolerance * (totalValue - textValue) / textValue;
                        if (toleranceRate > 70)
                        {
                            Debug.Log("Yuh");
                        }
                        else
                        {
                            finalValue = totalValue - (totalValue - textValue) * (tolerance - toleranceRate) / 100;
                            Debug.Log(finalValue + "altina anlastik");
                            if (imageObject != null)
                            {
                                imageObject.SetActive(false);
                            }

                        }
                        //finalvalue=firstvalue*(tolerance-toleranceRate)/100;//


                    }
                }
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {




    }
}