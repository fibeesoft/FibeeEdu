using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTasks : MonoBehaviour
{
    public int id;
    int taskClass;
    int taskCategory;
    public string taskQuestion;
    public string taskGoodAnswer;
    string taskBadAnswer1, taskBadAnswer2, taskBadAnswer3;
    string taskHelp;
    string taskSolution;

    public TextTasks(int _id, string _taskQuestion, string _taskGoodAnswer)
    {
        id = _id;
        taskQuestion = _taskQuestion;
        taskGoodAnswer = _taskGoodAnswer;
    }
}
