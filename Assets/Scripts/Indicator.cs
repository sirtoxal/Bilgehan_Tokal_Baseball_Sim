using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    bool goRight = false, goLeft = true, tapped = false;
    bool redArea, greenArea;
    public GameObject triangleButton, indicator2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IndicatorMove());
    }

    IEnumerator IndicatorMove()
    {
        if (goLeft)
        {
            transform.DOMoveX(-2.6f, 2).SetEase(Ease.InOutCubic);
            goLeft = false;
            goRight = true;
        }
        else if (goRight)
        {
            transform.DOMoveX(2.6f, 2).SetEase(Ease.InOutCubic);
            goLeft = true;
            goRight = false;
        }        
        yield return new WaitForSeconds(2);
        if(tapped == false)
            StartCoroutine(IndicatorMove());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && tapped == false)
        {
            tapped = true;
            transform.DOKill();
            CheckTheSuccessCondition();
        }
    }

    void CheckTheSuccessCondition()
    {
        if (greenArea == true)
        {
            print("I succeed");
            triangleButton.SetActive(true);
            indicator2.GetComponent<Rigidbody2D>().gravityScale = 0.25f;
        }            
        else if (redArea == true)
            print("I failed");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GreenArea")
        {
            greenArea = true;
            redArea = false;
        }
        else if (collision.tag == "RedArea")
        {
            greenArea = false;
            redArea = true;
        }
    }

    public void TriangleHits()
    {
        //indicator2.transform.DOMoveY(indicator2.transform.position.y + 0.01f, 0.1f);
        indicator2.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 100);
    }
}
