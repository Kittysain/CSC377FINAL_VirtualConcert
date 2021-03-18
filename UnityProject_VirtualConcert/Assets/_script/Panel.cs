using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private Canvas canvas = null;
    private MenuManeger menuManeger = null;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Setup(MenuManeger menuManeger)
    {
        this.menuManeger = menuManeger;
        hide();
    }

    public void show()
    {
        canvas.enabled = true;
    }

    public void hide()
    {
        canvas.enabled = false;
    }
}
