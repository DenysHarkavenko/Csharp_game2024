using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuContoller : MonoBehaviour
{
    public GameObject menu; 
    public Texture2D cursorTexture; 
    private bool isMenuOpen = false; 

    public List<GameObject> otherMenus;


    void Start()
    {
        menu.SetActive(false);
        isMenuOpen = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
{
    if (Input.GetKeyUp(KeyCode.Escape))
    {
        if (menu.activeSelf) 
        {
            menu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
        }
        else
        {
            bool isAnyOtherMenuActive = otherMenus.Any(menu => menu.activeSelf);

            if (!isAnyOtherMenuActive)
            {
                menu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Vector2 hotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
                Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
            }
        }
    }
}
}