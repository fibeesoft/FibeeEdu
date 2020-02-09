using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksExplanation : MonoBehaviour
{
    public static TasksExplanation instance;
    [SerializeField] GameObject explanationPanel;
    [SerializeField] Button btnExplanation;
    [SerializeField] Text txtExplanation;

    List<string> taskExplanationEngArray;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        explanationPanel.SetActive(false);
        taskExplanationEngArray = new List<string> ();
        taskExplanationEngArray.Add("No task");
        taskExplanationEngArray.Add( "Read the time from the digital clock and use pointers on the analog clock to set the same time. \n" +
            "Once it's done, press CHECK button. If the answer was correct, new task will be generated.");
        taskExplanationEngArray.Add("Read time from the analog clock and use sliders to set the same time on the digital one. \n" +
            "Once you set it, press CHECK button. If the answer was correct, new task will be generated.");
        taskExplanationEngArray.Add( "Multiplication table");
        taskExplanationEngArray.Add( "Answer the question by typing the answer or by choosing one of the answers provided");


    }

    public void ActivateTaskExplanationButton()
    {
        if(GameManager.instance.CurrentTask != Tasks.NoTask)
        {
            btnExplanation.gameObject.SetActive(true);
        }
        else
        {
            btnExplanation.gameObject.SetActive(false);

        }
    }
    public void ShowTaskExplanation()
    {
        if (explanationPanel.activeSelf)
        {
            explanationPanel.SetActive(false);
        }
        else
        {
            explanationPanel.SetActive(true);
            txtExplanation.text = taskExplanationEngArray[(int) GameManager.instance.CurrentTask];
        }
    }
}
