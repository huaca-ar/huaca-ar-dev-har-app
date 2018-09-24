using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private int xp = 0;
    [SerializeField] private int requiredXp = 100;
    [SerializeField] private int levelBase = 100;
    [SerializeField] private List <GameObject> artifacts = new List<GameObject>();
    private int lvl = 1;

    

    public void AddXp(int xp)
    {
        this.xp = Mathf.Max(0, xp);
    }
    //addDroid
    public void addArtifact(GameObject artifact)
    {
        artifacts.Add(artifact);
    }

    private void InitLevelData()
    {
        lvl = (xp / levelBase) + 1;
        requiredXp = levelBase + lvl;
    }



    // Use this for initialization
    void Start () {
        Debug.Log("Iniciar player");
		InitLevelData();
	}
	


    
    public int Xp
    {
        get
        {
            return xp;
        }

        set
        {
            xp = value;
        }
    }

    public int RequiredXp
    {
        get
        {
            return requiredXp;
        }

        set
        {
            requiredXp = value;
        }
    }

    public int LevelBase
    {
        get
        {
            return levelBase;
        }

        set
        {
            levelBase = value;
        }
    }

    public List<GameObject> Artifacts
    {
        get
        {
            return artifacts;
        }

        set
        {
            artifacts = value;
        }
    }

    public int Lvl
    {
        get
        {
            return lvl;
        }

        set
        {
            lvl = value;
        }
    }

}
