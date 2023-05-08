using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource battleMusic;



    // Start is called before the first frame update
    
    void Start()
    {
        playBackgroundMusic();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playBackgroundMusic()
    {
        //audioSource.Stop();
        backgroundMusic.enabled = true;
        battleMusic.enabled = false;
    }

    public void playBattleMusic()
    {
        backgroundMusic.enabled = false;
        battleMusic.enabled = true;
    }
}
