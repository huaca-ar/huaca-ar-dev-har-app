
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Text xptext;
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject menu;

    private void Awake()
    {
        Assert.IsNotNull(xptext);
        Assert.IsNotNull(levelText);
        Assert.IsNotNull(menu);
        Debug.Log("Se desperto");
    }

    private void update(){
        updateLevel();
        updateXP();
        Debug.Log("Actualizo UI");
    }

    public void updateLevel()
    {
        levelText.text = GameManager.Instance.CurrentPlayer.Lvl.ToString();
    }

    public void updateXP()
    {
        xptext.text = GameManager.Instance.CurrentPlayer.Xp + " / " + GameManager.Instance.CurrentPlayer.RequiredXp;
    }

    public void toggleMenu()
    {
        menu.SetActive(!menu.activeSelf); 
    }
    private void Start(){

    }

    private void Update(){
        
    }
}
