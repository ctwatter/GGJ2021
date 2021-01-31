using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonMasher : MonoBehaviour
{
    int buttonMashCount = 0;
    Slider slider;
    bool oneShot = true;
    public GameObject baby;
    public GameObject hand;
    public AudioSource cry;
    

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        if(oneShot)
        {
            if(slider.value == slider.maxValue)
            {
                baby.GetComponent<Animator>().SetTrigger("getNose");
                hand.GetComponent<Animator>().SetTrigger("done");
                cry.Stop();
                
                goNextGame();
                
                oneShot = false;
            //Load random scene
            }
        }

    }

    void goNextGame()
    {
        StartCoroutine("wait");
        PersitentData.Instance.NextScene();

    
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }

    void OnBabyButtonMash()
    {
        if(oneShot)
        {
        
            slider.value = buttonMashCount++;
            if(baby.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("cry"))
            {
                //nothing
            }
            else 
            {
                if(!cry.isPlaying) cry.Play();
                baby.GetComponent<Animator>().SetTrigger("cry");
                
            }
        }
        
    }
}
