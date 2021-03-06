﻿using System.Collections.Generic;
using System.Linq;

namespace HarryPotterUnity.Cards.Transfiguration.Locations
{
    public class FlourishAndBlotts : BaseLocation
    {
        public override bool CanPerformInPlayAction()
        {
            var player = this.Player.IsLocalPlayer ? this.Player : this.Player.OppositePlayer;

            return player.CanUseActions() &&
                   player.InPlay.Lessons.Count >= 2;
        }

        public override void OnInPlayAction(List<BaseCard> targets = null)
        {
            var player = this.Player.CanUseActions() ? this.Player : this.Player.OppositePlayer;

            var lessons = player.InPlay.Lessons.Take(2);

            player.Discard.AddAll(lessons);

            for (int i = 0; i < 5; i++)
            {
                player.Deck.DrawCard();
            }

            player.UseActions();
        }
    }
}