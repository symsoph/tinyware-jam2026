using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Sprite_Behaviour : MonoBehaviour
{
    public List<GameObject> spawnList = new List<GameObject>();
    [SerializeField] TMP_Text symbolText;
    [SerializeField] TMP_Text bigNumberText;
    [SerializeField] TMP_Text conditionText;

    //public List<GameObject> instanciatedObjects = new List<GameObject>();

    [SerializeField] GameObject prefab;
    public float zoffset = 0;
    
    int sum;
    //string gameState;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameState = "Start";
        // const int N = 9;
        // for(int i = 0; i < N; i++) {
        //         spawnList.Add(Instantiate(prefab));
        //         spawnList.Add(Instantiate(spawnList, spawnPoint, Quaternion.identity));
        // }   

        //Output the current screen window width in the console
        // Debug.Log("Screen Width : " + Screen.width); === 1920
        // Debug.Log("Screen Height : " + Screen.height); ==  1080

        // raycast minPoint and maxPoint 
        
        // save the local Coordinates using cameraTransform.InverseTransformPoint

    }

    void Spawn(int numClones)
    {
          // the grid will always be 1, 2, 3, 4, or 5 prefabs wide
            int xcount = Random.Range(1, 3);
            // the grid will always be 2, 3, or 4 prefabs long
            int ycount = Random.Range(2, 5);

            // for (int x = 0; x != xcount; ++x)
            // {
                for (int y = 0; y < numClones; y++)
                {
            // range X: float p_xcount = Random.Range(-8.0f, 8.0f);
            // range Y: float p_ycount = Random.Range(-5.0f, 5.0f);
            float p_xcount = Random.Range(-6.5f, 6.5f);
            float p_ycount = Random.Range(-4.0f, 4.0f);
                    while ((p_xcount + 1.5f ) > 8.0f || (p_xcount - 1.5f) < -8.0f)
                    {
                        p_xcount = Random.Range(-8.0f, 8.0f);
                    }
                    while ((p_ycount + 1.0f ) > 4.0f || (p_ycount - 1.0f) < -4.0f)
                    {
                        p_ycount = Random.Range(-4.0f, 4.0f);
                    }
                    Vector3 spawnPoint = new Vector3(  p_xcount, p_ycount , 0f);   
                    Debug.Log("Sprite clone position: x " + p_xcount + "y" + p_ycount); 

// Instantiate(spawnObject, cameraTransform.TransformPoint(spawnPoint), Quaternion.Identitiy);


                    // loop? Instantiate(spawnList[y], spawnPoint, Quaternion.identity);
                    GameObject instObj = (GameObject) Instantiate(prefab, spawnPoint, Quaternion.identity);
                    spawnList.Add(instObj);
                }
    }
    
    
    // Click the "Instantiate!" button and a new grid of `prefab` objects will be
    // instantiated with a random number of items in each direction. --- via https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Random.Range.html
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "Instantiate 5!"))
        {
           Spawn(10);
          

            // zoffset += 2;
            Debug.Log("spawnlist size = " + spawnList.Count);
        }
        // rect (x, y, width, height)
        // if (GUI.Button(new Rect(10, 40, 100, 50), "Remove!"))
        if (GUI.Button(new Rect(10, 60, 100, 50), "Remove then add 3!"))
        {
            sum++;
            Debug.Log("Destroying sprite run sum: " + sum);
            for (int i = 0; i < 10; i++) {
                Destroy(spawnList[i]);
            }
            Spawn(3);
        }
            
            
            
            // Destroy(spawnList[0]); // -- worked
            Debug.Log("spawnlist size = " + spawnList.Count);
            //Spawn(3);

            

    }

    void Update() { // doesnt run once lol why
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Debug.Log("Add sprite : " + sum);
            // if symbol == "+"
            Spawn(1);
            sum += 1;
            //receivedInput = true;
            
            // else Destroy(spawnList[0]);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Spawn(2);
            sum += 1;
            //  receivedInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Spawn(3);
            sum += 1;
            // receivedInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            Spawn(4);
            sum += 1;
            // receivedInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            Spawn(5);
            sum += 1;
            // receivedInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            Spawn(6);
            sum += 1;
            //  receivedInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            Spawn(7);
            sum += 1;
            // receivedInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8)) {
            Spawn(8);
            sum += 1;
            // receivedInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9)) {
            Spawn(9);
            sum += 1;
            // receivedInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0)) {
            // calculate sum or difference
        } else
        {
          //  receivedInput = false;
        }


        List<string> symbolList = new List<string>(); // +, -
        symbolList.Add("+");
        symbolList.Add("-");

        List<int> numbers = new List<int>();
        numbers.Add(0);
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);
        numbers.Add(5);
        numbers.Add(6);
        numbers.Add(7);
        numbers.Add(8);
        numbers.Add(9);

        // select random
        string ranSym = symbolList[Random.Range(1, 3)];
        int ranNum = numbers[Random.Range(0, 10)];

        // display symbol
        symbolText.text = string.Format("{+}", ranSym);
        bigNumberText.text = string.Format("{1}", ranNum);

        if (sum == ranNum)
        {
            conditionText.text = "{Yay}";
        }


    }
}
