using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public int amountToBeDie;
    public Slider sliderHP;
    private int currentAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        sliderHP.maxValue = amountToBeDie;
        sliderHP.value = 0;
        sliderHP.fillRect.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillEnemy(int amount)
    {
        currentAmount += amount;
        sliderHP.fillRect.gameObject.SetActive(true);
        sliderHP.value = currentAmount;

        if(currentAmount >= amountToBeDie)
        {
            Destroy(gameObject, 0.1f);
        }

    }
}
