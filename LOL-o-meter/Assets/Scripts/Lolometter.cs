using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lolometter : MonoBehaviour
{
    [Range(-3,3)] private int _value;
    [SerializeField] Slider _lolometerSlider;

    // Start is called before the first frame update
    void Start()
    {
        Audience.OnReactionExcecute += UpdateLolometer;    
    }
    private void OnDestroy()
    {
        Audience.OnReactionExcecute -= UpdateLolometer;
    }

    // Update is called once per frame
    void UpdateLolometer(int value)
    {
        _value += value;
        _lolometerSlider.value = _value;
    }
}
