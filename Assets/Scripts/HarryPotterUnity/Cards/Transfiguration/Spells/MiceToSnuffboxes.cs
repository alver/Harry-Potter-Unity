﻿using System.Collections.Generic;
using HarryPotterUnity.Cards.Generic;
using JetBrains.Annotations;

namespace HarryPotterUnity.Cards.Transfiguration.Spells
{
    [UsedImplicitly]
    public class MiceToSnuffboxes : GenericSpell {
        public override List<GenericCard> GetValidTargets()
        {
            var validCards = Player.InPlay.GetCreaturesInPlay();
            validCards.AddRange(Player.OppositePlayer.InPlay.GetCreaturesInPlay());

            return validCards;
        }

        protected override void SpellAction(List<GenericCard> selectedCards)
        {
            //TODO: fix animation bugs by doing an AddAll of the selected cards belong to the same player.
            foreach(var card in selectedCards) {
                card.Player.Hand.Add(card, preview: false);
                card.Player.InPlay.Remove(card);
            }


        }
    }
}