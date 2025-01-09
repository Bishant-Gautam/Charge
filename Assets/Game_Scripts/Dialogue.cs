using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dialogue : MonoBehaviour
{
    [SerializeField] GameObject[] levelsHiddenkey;
    [SerializeField] GameObject switchControlUI;
    [SerializeField] UnityEngine.Experimental.Rendering.Universal.Light2D lightRadius;
    void Update()
    {
        Invoke("WaitForCorrect",4f);
    }
    //This method is used turnoff laser light
    public void TurnLaserOff()
    {
        levelsHiddenkey[0].SetActive(false);
        Time.timeScale = 1f;
    }
    //This method is used to set active level 2 hidden platform
    public void ActivateLadder()
    {
        levelsHiddenkey[0].SetActive(true);
        Time.timeScale = 1f;
    }
    
    void WaitForCorrect()
    {
        switchControlUI.SetActive(false);   
    }

    public void WaitForLight()
    {
        Invoke("LightRadiusIncrease", 3f);
        Time.timeScale = 1f;
        
    }

    void LightRadiusIncrease()
    {
        lightRadius.pointLightOuterRadius = (9f);
        Invoke("LightRadiusDecrease", 2f);
    }
    void LightRadiusDecrease()
    {
        lightRadius.pointLightOuterRadius = (1.8f);
    }
}
