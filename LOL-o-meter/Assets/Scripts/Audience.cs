using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{
    public static event Action<int> OnReactionExcecute;

    [SerializeField] TYPEOFJOKE[] _audienceReactionRating = new TYPEOFJOKE[5];
    // Start is called before the first frame update
    void Start()
    {
        Obstacle.OnExecuteJoke += Execute;
    }
    private void OnDestroy()
    {
        Obstacle.OnExecuteJoke -= Execute;
    }

    // Update is called once per frame
    void Execute(TYPEOFJOKE typeOfJoke)
    {
        for(int i=0; i < _audienceReactionRating.Length; i++)
        {
            if (_audienceReactionRating[i] != typeOfJoke)
            {
                continue;
            }

            if (i < 2)
            {
                //TODO AUDIO

                OnReactionExcecute?.Invoke(1);
                return;
            }
            else if (i == 2)
            {  
                //TODO AUDIO
                OnReactionExcecute?.Invoke(0);
                return;
            }
            else if (i > 2)
            {
                //TODO AUDIO
                OnReactionExcecute?.Invoke(-1);
                return;
            }
        }
    }
}
