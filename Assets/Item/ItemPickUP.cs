﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUP : Interactables
{
    public Item item;
    Fighter health;
    
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    void PickUp()
    {
        item.Use();
    }
}
