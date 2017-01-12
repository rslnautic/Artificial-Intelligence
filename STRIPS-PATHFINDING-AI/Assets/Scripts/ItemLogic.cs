using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemLogic : MonoBehaviour
{

    public string Tag;
    public List<GameObject> Required;
    public Sprite ActiveSprite;
    public bool Active;
	// Use this for initialization
	void Awake ()
	{
	    Active = false;
        Required = new List<GameObject>();
	}
	
	

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        foreach (var o in Required)
        {
            ItemLogic logic = o.GetComponent<ItemLogic>();
            if (!logic.Active)
                return;

        }
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        render.sprite = ActiveSprite;
        Active = true;
    }

    void OnGUI()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        GUI.Label(new Rect(pos.x-25,Screen.height-pos.y,70,20), Tag );
    }
}
