using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Text HPText;
    public Image HPFillValue;

    CharacterStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = playerStats.health.ToString();
        float fillValue = playerStats.health / (float)playerStats.maxhealth;
        HPFillValue.rectTransform.localScale = new Vector3(fillValue, 1, 1); //Adjust the scale of the Health bar based on current Health
    }
}
