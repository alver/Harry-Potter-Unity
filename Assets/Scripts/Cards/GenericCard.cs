﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GenericCard : MonoBehaviour {

    public enum CardStates
    {
        IN_DECK, IN_HAND, IN_PLAY
    }

    public enum CardTypes
    {
        LESSON, CREATURE, SPELL, ITEM, LOCATION, MATCH, ADVENTURE, CHARACTER
    }
    public enum CostTypes
    {
        CARE_OF_MAGICAL_CREATURES, CHARMS, TRANSFIGURATION, POTIONS, QUIDDITCH
    }

    public CardStates State;
    public CardTypes CardType;

    public Player _Player;

    protected bool Zoomed;
    protected readonly float TweenTime = 0.25f;
    protected readonly float ZoomScaleValue = 3f;

    public void Start()
    {
        Zoomed = false;
        Debug.Log("GenericCard Start");
    }

    public void OnMouseEnter()
    {
        // TODO: Implement separate zoom when card is IN_PLAY
        if (State != CardStates.IN_HAND) return;

        if (!Zoomed)
        {
            iTween.ScaleTo(gameObject, iTween.Hash("x", ZoomScaleValue, "y", ZoomScaleValue, "time", TweenTime));
            iTween.MoveTo(gameObject, iTween.Hash("y", -92f, "time", TweenTime, "islocal", true));
            Zoomed = true;
        }
    }

    public void OnMouseExit()
    {
        if (State != CardStates.IN_HAND) return;

        if (Zoomed)
        {
            iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "time", TweenTime));
            iTween.MoveTo(gameObject, iTween.Hash("y", Hand.HAND_CARDS_OFFSET.y, "time", TweenTime, "islocal", true));
            Zoomed = false;
        }
    }

    public void SwitchState(CardStates newState)
    {
        State = newState;
    }

    public abstract void BeforeTurnAction();
    public abstract void AfterTurnAction();
}
