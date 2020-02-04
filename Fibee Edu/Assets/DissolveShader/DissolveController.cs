using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DissolveController : MonoBehaviour
{
    float dissolveAmount;
    float dissolveSpeed;
    public bool isDissolving;
    [ColorUsageAttribute(true, true)] public Color outColor;
    [ColorUsageAttribute(true, true)] public Color inColor;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Image>().material;

    }

    void PrepareButton()
    {
        dissolveAmount = 1f;
        dissolveSpeed = 1f;
        //mat = GetComponent<SpriteRenderer>().material;
        mat = GetComponent<Image>().material;
    }

    public void ShowButton()
    {
        PrepareButton();
        isDissolving = false;
    }

    public void DissolveButton()
    {
        PrepareButton();
        isDissolving = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isDissolving = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            isDissolving = false;
        }
        if (isDissolving)
        {
            mat.SetColor("_DissolveColor", outColor);
            if(dissolveAmount > -0.1f)
            {
                dissolveAmount -= Time.deltaTime * dissolveSpeed;
            }
        }
        if (!isDissolving)
        {
            mat.SetColor("_DissolveColor", inColor);
            if(dissolveAmount < 1f)
            {
                dissolveAmount += Time.deltaTime * dissolveSpeed;
            }
        }
        mat.SetFloat("_DissolveAmount", dissolveAmount);

    }
}
