using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class Main : MonoBehaviour
{
    bool runningFlicker = false;
    bool buttonClicked = false;

    //Const nums
    public const float flickerCurve = 2.7f; //The higher flickeringCurve, earlier fast flickering comes
    public const float flickerCoefficient = 0.027f; //The higher flickeringCoefficient, slower overall flickering speed
    public const int initialFlickerCount = 27; //Number of total flickers
    public const int initialItemCount = 9; //Number of skins

    //Variable nums
    public int itemCount;

    public SkinScript[] scriptsArray;

    //Lists to be emptied
    List<int> numbers;
    public List<SkinScript> scriptsList;

    //Button
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        itemCount = initialItemCount;

        scriptsArray = gameObject.GetComponentsInChildren<SkinScript>();
        scriptsList = new List<SkinScript>();
        for(int i = 0; i < initialItemCount ; i++)
        {
            Debug.Log(i);
            Debug.Log(scriptsArray[i]);
            scriptsList.Add(scriptsArray[i]);
        }

        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        button = gameObject.GetComponentsInChildren<Button>()[9];

        Debug.Log(button);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonUp(0))
            Debug.Log("mouse clicked!");
        if (Input.GetMouseButtonUp(0))
        {
            if (img.color == colorOn)
                img.color = colorOff;
            else if (img.color == colorOff)     && Input.GetButtonUp(button.name)
                img.color = colorOn;
        }
        */

        if (!runningFlicker && itemCount != 0 && buttonClicked)
        {
            StartCoroutine(randomSelectNumbers());
            runningFlicker = true;
        }


    }

    IEnumerator randomSelectNumbers()
    {
        int flickerCount = initialFlickerCount;
        if (itemCount > 1)
        {
            int preRandNum = -1;
            for (int i = 0; i < flickerCount; i++)
            {
                float flickeringTime = Abs(i - flickerCount / flickerCurve)*flickerCoefficient;
                int randNum = Random.Range(0, itemCount);
                while (preRandNum == randNum) { randNum = Random.Range(0, itemCount); } //Make sure no two consecutive randoms are not equal
                SkinScript fSkinScript = scriptsList[randNum];
                Debug.Log("flicker:" + Random.Range(0, itemCount));
                fSkinScript.lightsOn(numbers[randNum]);
                yield return new WaitForSeconds(flickeringTime);
                fSkinScript.lightsOff();
                preRandNum = randNum;
            }
        }
        //Chosen skin flickers three times
        int randNum2 = Random.Range(0, itemCount);
        SkinScript skinScript = scriptsList[randNum2];
        for (int i = 0; i<3; i++)
        {
            skinScript.lightsOn(numbers[randNum2]);
            yield return new WaitForSeconds(0.2f);
            skinScript.lightsOff();
            yield return new WaitForSeconds(0.2f);
            Debug.Log("##Flickering: " + skinScript);
        }
        skinScript.reveal();      
        //Removing shown item
        itemCount--;    
        numbers.RemoveAt(randNum2);
        scriptsList.RemoveAt(randNum2);

        runningFlicker = false;
        buttonClicked = false;
    }

    public void buttonIsClicked(){ buttonClicked = true; }

}
