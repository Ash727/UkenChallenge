using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEditor.UI;
using System.Text;

public class NumberFileReader : MonoBehaviour
{


    [SerializeField]
    private TextAsset _File;
    private string[] fileContent;
    private List<string> listofIntegers;
    private List<int> Number_listofIntegers = new List<int>();
    private List<int> Number_listfreqs = new List<int>();
    private Dictionary<int, int> NumbFreq_Dictonary = new Dictionary<int, int>();
    private int _lowestNumber;
    private int _lowestFreq;
    private List<int> DistInctList;
    int count = 0;
    
    public int getlowestNumber { get { return _lowestNumber; } }
    public int getlowestFreq { get { return _lowestFreq; } }
    // Start is called before the first frame update
    void Start()
    {
        ////if we have a file
        //if (_File!=null)
        //{   //Split File into File Content Array  
        //    fileContent = _File.text.Split('\n');
        //    listofIntegers = fileContent.ToList();

        //    // For every FileContent Print out file content 
        //    // But only if the number is not empty
        //    for (int i = 0; i < listofIntegers.Count; i++)
        //    {
        //        if (listofIntegers[i] != "")
        //        {
        //            int num = int.Parse(listofIntegers[i]);
        //            // Add the numbers to the number list 
        //            Number_listofIntegers.Add(num);
        //        }

        //    }
        //    List<int> DistInctList = Number_listofIntegers.Distinct().ToList<int>();
        //    for (int i = 0; i < DistInctList.Count(); i++)
        //    {
        //        // Using linq get account for all elements equal to the distinc elemetns in list
        //        int freq = Number_listofIntegers.Count(e => e == DistInctList[i]);
        //        // Add frequencies to list 
        //        Number_listfreqs.Add(freq);
        //        // Add it to the dictionary for further analysis
        //        NumbFreq_Dictonary.Add(DistInctList[i], freq);
        //        print(DistInctList[i] + "has a freq of : " + freq);
        //    }
        //    print("Lowest freq is " + Number_listfreqs.Min());
        //    _lowestNumber = NumbFreq_Dictonary.Where(e => e.Value == Number_listfreqs.Min()).Select(e => e.Key).Min();
        //    print("Lowest Number is" + _lowestNumber);



        //}
    }


    public void readFile()
    {
        string file = "";
        {
            // Get the directory of the file 
            file = EditorUtility.OpenFilePanel("Text File Select", "", "txt");

            // if we have a file 
            if (file != "")
            {   //Split File into File Content Array this method gets all
                // Read all text gets a ll the texts of the file 
                fileContent = System.IO.File.ReadAllText(file).Split('\n');
                listofIntegers = fileContent.ToList();

                // For every FileContent Print out file content 
                // But only if the number is not empty
                for (int i = 0; i < listofIntegers.Count; i++)
                {
                    if (listofIntegers[i] != "")
                    {
                        int num = int.Parse(listofIntegers[i]);
                        // Add the numbers to the number list 
                        Number_listofIntegers.Add(num);
                    }

                }
                // Get a distinc Number of integers from the list of integers 
                DistInctList = Number_listofIntegers.Distinct().ToList<int>();
                // loop through the distinct list to get a count for all of the integers 
                for (int i = 0; i < DistInctList.Count(); i++)
                {
                    // Using linq get account for all elements equal to the distinc elemetns in list
                    int freq = Number_listofIntegers.Count(e => e == DistInctList[i]);
                    // Add frequencies to list 
                    Number_listfreqs.Add(freq);
                    // Add it to the dictionary for further analysis
                    NumbFreq_Dictonary.Add(DistInctList[i], freq);
                }
                // Assign lowest number 
                _lowestFreq = Number_listfreqs.Min();
                // Assign lowest frequency of numbers
                _lowestNumber = NumbFreq_Dictonary.Where(e => e.Value == Number_listfreqs.Min()).Select(e => e.Key).Min();
            }
            // Clean up and clear all list for next file 
            Number_listfreqs.Clear();
            NumbFreq_Dictonary.Clear();
            listofIntegers.Clear();
            DistInctList.Clear();
            Number_listofIntegers.Clear();
        }
        GUILayout.Label("Number Repeated fewest times:" + _lowestNumber);
        GUILayout.Label("Number of times Repeated:" + _lowestFreq);
        print("Number repeated the least:" + _lowestNumber);
        print("Number of times repeated" + _lowestFreq);
    }
    private void OnGUI()
    {
        string file = "";
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 100), "File Select"))
        {
            // Get the directory of the file 
            file = EditorUtility.OpenFilePanel("Text File Select", "", "txt");

            // if we have a file 
            if (file != "")
            {   //Split File into File Content Array this method gets all
                // Read all text gets a ll the texts of the file 
                fileContent = System.IO.File.ReadAllText(file).Split('\n');
                listofIntegers = fileContent.ToList();

                // For every FileContent Print out file content 
                // But only if the number is not empty
                for (int i = 0; i < listofIntegers.Count; i++)
                {
                    if (listofIntegers[i] != "")
                    {
                        int num = int.Parse(listofIntegers[i]);
                        // Add the numbers to the number list 
                        Number_listofIntegers.Add(num);
                    }

                }
                // Get a distinc Number of integers from the list of integers 
                DistInctList = Number_listofIntegers.Distinct().ToList<int>();
                // loop through the distinct list to get a count for all of the integers 
                for (int i = 0; i < DistInctList.Count(); i++)
                {
                    // Using linq get account for all elements equal to the distinc elemetns in list
                    int freq = Number_listofIntegers.Count(e => e == DistInctList[i]);
                    // Add frequencies to list 
                    Number_listfreqs.Add(freq);
                    // Add it to the dictionary for further analysis
                    NumbFreq_Dictonary.Add(DistInctList[i], freq);
                }
                // Assign lowest number 
                _lowestFreq = Number_listfreqs.Min();
                // Assign lowest frequency of numbers
                _lowestNumber = NumbFreq_Dictonary.Where(e => e.Value == Number_listfreqs.Min()).Select(e => e.Key).Min();
            }
            // Clean up and clear all list for next file 
            Number_listfreqs.Clear();
            NumbFreq_Dictonary.Clear();
            listofIntegers.Clear();
            DistInctList.Clear();
            Number_listofIntegers.Clear();
        }
        GUILayout.Label("Number Repeated fewest times:" + _lowestNumber);
        GUILayout.Label("Number of times Repeated:" + _lowestFreq);
        print("Number repeated the least:" + _lowestNumber);
        print("Number of times repeated" + _lowestFreq);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
