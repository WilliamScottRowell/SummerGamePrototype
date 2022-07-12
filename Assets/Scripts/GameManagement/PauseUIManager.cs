using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIManager : MonoBehaviour, ResetScript
{
    // Attach various components of pause menu UI
    public Canvas mainPauseMenu;
    public Canvas talentSystemCanvas;
    public MasterVolumeControl volumeControl;
    public bool disableAudioInMenu = true;

    // Start is called before the first frame update
    void Start()
    {
        SetAllData();
    }

    public void SetAllData()
    {
        mainPauseMenu.gameObject.SetActive(false);  // Start turned off
        talentSystemCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!mainPauseMenu.isActiveAndEnabled)  // If not in menu yet
            {
                talentSystemCanvas.gameObject.SetActive(false);
                mainPauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;

                if(disableAudioInMenu && volumeControl != null)
                {
                    volumeControl.MuteAll();
                }
            }
            else
            {
                mainPauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;

                if (disableAudioInMenu && volumeControl != null)
                {
                    volumeControl.UnmuteAll();
                }
            }    
        }
            
    }
}
