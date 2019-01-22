using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    [HideInInspector]
    public static int score;

    private static int totalCount = 4;

    private bool flag;

    private Vector2[] positions = new Vector2[totalCount];

    public GameObject[] logos = new GameObject[totalCount];
    public GameObject[] statements = new GameObject[totalCount];
            
    void Start()
    {
        SetPositions();
        AssignStatements();
    }

    void Update()
    {
        CheckChildCount();
        if(flag)
        {
            CheckScore();
        }
    }

    void SetPositions()
    {
        List<int> randomList = GenerateRandomList();
        for (int i = 0; i < totalCount; i++)
        {
            positions[i] = statements[i].GetComponent<RectTransform>().transform.position;
        }
        for (int i = 0; i < totalCount; i++)
        {
            statements[i].GetComponent<RectTransform>().transform.position = positions[randomList[i]];
        }            
    }

    public List<int> GenerateRandomList()
    {
        List<int> list = new List<int>();
        int rand;
        for (int i = 0; i < totalCount; i++)
        {
            rand = Random.Range(0, totalCount);

            while (list.Contains(rand))
            {
                rand = Random.Range(0, totalCount);
            }

            list.Add(rand);
        }

        return list;
    }

        void AssignStatements()
    {
        for (int i = 0; i < totalCount; i++)
        {
            string statementText = "";
            
            switch(i)
            {
                case 0:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            statementText = "The program receives participation from the BU as well as the bottling associates";
                            break;
                        case 1:
                            statementText = "The program participants undertake an international best practice learning visit";
                            break;
                        case 2:
                            statementText = "It is a flagship program of FCS to nurture leadership talent across the Coca – Cola INSWA BU ";
                            break;
                    }
                    break;

                case 1:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            statementText = "It is a two – day training intervention for sales team leads";
                            break;
                        case 1:
                            statementText = "This program focusses on territory management and coaching process";
                            break;
                        case 2:
                            statementText = "This program was launched in 2018";
                            break;
                    }
                    break;

                case 2:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            statementText = "This five-month program offers specialization in Operations (sales, ME, RTM, NKA) and Technical (QSE, Production, Maintenance)";
                            break;
                        case 1:
                            statementText = "This program is a recipient of BU president’s award in 2013";
                            break;
                        case 2:
                            statementText = "This program completed its 10th year in 2018";
                            break;
                    }
                    break;

                case 3:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            statementText = "This program is designed in collaboration with FSSAI";
                            break;
                        case 1:
                            statementText = "This program focusses on training street food vendors on hygienic and safe food practices";
                            break;
                        case 2:
                            statementText = "Launched in 2017, this program witnessed 10,000+ food vendors trained so far";
                            break;
                    }
                    break;
            }
            statements[i].GetComponent<Text>().text = statementText;
        }
    }

    void CheckChildCount()
    {
        int childrenCount = 0;

        for (int i = 0; i < totalCount; i++)
        {
            if (statements[i].transform.childCount > 0)
            {
                childrenCount++;
                statements[i].transform.GetChild(0).transform.GetComponent<RectTransform>().localPosition = new Vector2(7500, 0);
            }
        }
        if (childrenCount == totalCount)
        {
            flag = true;
        }
    }

    void CheckScore()
    {
        score = 0;
        for (int i = 0; i < totalCount; i++)
        {
            if (logos[i].transform.parent == statements[i].transform)
            {
                score++;
            }
        }
        StartCoroutine(Wait());        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<ChangeScene>().SwitchScene("finish");
    }
}
