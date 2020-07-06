using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class SkinScript : MonoBehaviour
{
    bool randomSelected = false;
    Image img; 

    public const int initialFlikkerCount = 20;
    public const int initialItemCount = 9;

    //public Image img;
    public Color colorOn = new Color(0.1619794f, 0.5283019f, 0.177457f);
    public Color colorOff = new Color(0.5019608f, 0.5019608f, 0.5019608f);
    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        //color = img.color;
        Debug.Log(gameObject.name);

        

    }
/*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            Debug.Log("mouse clicked!");
        if (Input.GetMouseButtonUp(0))
        {
            if (img.color == colorOn)
                img.color = colorOff;
            else if (img.color == colorOff)
                img.color = colorOn;
        }

        if (!randomSelected)
        {
            StartCoroutine(randomSelectNumbers());
            randomSelected = true;
        }


    }

    IEnumerator randomSelectNumbers()
    {
        int flikkerCount = initialFlikkerCount;
        int itemCount = initialItemCount;
        while (itemCount > 0)
        {
            for (int i = 0; i < flikkerCount; i++)
            {
                yield return new WaitForSeconds(0.5f);
                Debug.Log("flikker:" + Random.Range(0, itemCount));
            }
            Debug.Log("##Choose: " + Random.Range(0, itemCount));
            itemCount--;
        }
    }
    */

    public void lightsOn (int skinNum)
    {
        if(gameObject.name == "Skin" + skinNum)
        {
            img.color = colorOn;
            Debug.Log(colorOn);
        }
    }

    public void lightsOff ()
    {
        img.color = colorOff;
    }

    public void reveal()
    {
        string str = gameObject.name;
        str = "" + str[str.Length - 1];
        Sprite spr = Resources.Load<Sprite>(str);
        gameObject.GetComponentsInChildren<Image>()[2].sprite = spr;
        Debug.Log(gameObject.GetComponentsInChildren<Image>()[2].sprite);
        
    }
}
