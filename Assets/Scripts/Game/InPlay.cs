﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LessonTypes = Lesson.LessonTypes;
using CardStates = GenericCard.CardStates;
using CardTypes = GenericCard.CardTypes;

public class InPlay : MonoBehaviour {

    public List<Transform> Cards;

    public Player _Player;

    private static readonly Vector3 LESSON_POSITION_OFFSET = new Vector3(-160f, 6f, 15f);
    private static readonly Vector2 LESSON_SPACING = new Vector2(80f, 15f);

    public float InPlayTweenTime;

    public void Start()
    {
        Cards = new List<Transform>();
    }

    public void Add(Transform card, CardTypes CardType)
    {
        Cards.Add(card);
        card.parent = transform;

        switch (CardType)
        {
            case CardTypes.LESSON:
                AnimateLessonToBoard(card);
                break;
        }
    }

    private void AnimateLessonToBoard(Transform card)
    {
        Vector3 cardPosition = LESSON_POSITION_OFFSET;

        cardPosition.x += (_Player.LessonsInPlay % 3) * LESSON_SPACING.x;
        cardPosition.y -= (int)(_Player.LessonsInPlay / 3) * LESSON_SPACING.y;
        cardPosition.z -= (int)(_Player.LessonsInPlay / 3);

        iTween.MoveTo(card.gameObject, iTween.Hash("time", InPlayTweenTime,
                                                   "position", cardPosition,
                                                   "easetype", iTween.EaseType.easeInOutSine,
                                                   "islocal", true
                                                   ));

        iTween.RotateTo(card.gameObject, iTween.Hash("time", InPlayTweenTime,
                                                     "z", 270f,
                                                     "easetype", iTween.EaseType.easeInOutSine
                                                     ));

        iTween.ScaleTo(card.gameObject, iTween.Hash("x", 1, "y", 1, "time", InPlayTweenTime));
    }
}
