﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftSeventeeGameRule : IHitStrategy
    {

        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            int score = a_dealer.CalcScore();

            if(score == g_hitLimit){
                foreach(Card c in a_dealer.GetHand()){
                    if(c.GetValue() == Card.Value.Ace && (score - 11) == 6){
                        score -= 10;
                    }
                }
                return score < g_hitLimit;
            }
            else if(score < g_hitLimit){
                return true;
            }
            return false;
        }
    }
}
