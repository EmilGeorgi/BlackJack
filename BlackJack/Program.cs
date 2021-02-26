using System;
using System.Collections.Generic;
using BlackJack.Entities;
namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Write amount of players");
                try
                {
                    Deck deck = new Deck();
                    deck.GenerateDeck(6);
                    int playerCount = int.Parse(Console.ReadLine());
                    List<Hand> hands = new List<Hand>();
                    for (int i = 0; i < playerCount; i++)
                    {
                        hands.Add(new Hand("player " + (i+1), deck));
                    }
                    foreach (Hand hand in hands)
                    {
                        Console.WriteLine($"{hand.PlayerName} your turn");
                        if (hand.GetValue() == 21)
                        {
                            Console.WriteLine($"you got blackjack with {hand.GetCards()}");
                        }
                        else
                        {
                            actions(hand, deck);
                        }
                    }
                    Hand WinnerHand = Winner(hands, deck);
                    Console.WriteLine($"{WinnerHand.PlayerName} won with {WinnerHand.GetCards()}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static Hand Winner(List<Hand> hands, Deck deck)
        {
            Hand tempHighestHand = hands.Find(hand => hand.GetValue() <= 21);
            foreach (var hand in hands)
            {
                if(hand.GetValue() < 21)
                {
                    if(tempHighestHand.GetValue() < hand.GetValue())
                    {
                        tempHighestHand = hand;
                    }
                }
                else if (hand.GetValue() == 21)
                {
                    tempHighestHand = hand;
                }
            }
            return tempHighestHand;
        }
        private static void actions(Hand hand, Deck deck)
        {
            Console.WriteLine($"you have \n{hand.GetCards()}");
            Console.WriteLine("if you want to draw type draw");
            Console.WriteLine("if you want to stay type stay");
            string action = Console.ReadLine();
            if (action == "draw")
            {
                hand.AddCard(deck);
                if (hand.GetValue() > 21)
                {
                    Console.WriteLine($"{hand.PlayerName} has \n{hand.GetCards()}");
                    Console.WriteLine($"{hand.PlayerName} has over 21 and is busted");
                    Console.WriteLine();
                    return;
                }
                else if (hand.GetValue() == 21)
                {
                    Console.WriteLine($"you have 21");
                }
                else
                {
                    actions(hand, deck);
                }
            }
            else if (action == "stay")
            {
                Console.WriteLine();
                return;
            }
        }
    }
}
