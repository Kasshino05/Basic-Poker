using System;
using System.Collections.Generic;

Console.WriteLine(" Velkommen, til poker!");

List<Card> deck = Card.CreateDeck();

Card.ShuffleDeck(deck);

Console.WriteLine("How many players are playing?");
int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

List<List<Card>> players = new List<List<Card>>();

for (int i = 0; i < numberOfPlayers; i++)
{
    players.Add(new List<Card>());
}

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < numberOfPlayers; j++)
    {
        players[j].Add(deck[0]);
        deck.RemoveAt(0);
    }
}

Console.WriteLine($"Number of cards: {deck.Count}");

foreach (Card card in deck)
{
    Console.WriteLine(card.color + " " + card.Value);
}

for (int i = 0; i < players.Count; i++)
{
    Console.WriteLine($"Player {i + 1}:");

    foreach (Card card in players[i])
    {
        Console.WriteLine(card.color + " " + card.Value);
    }
}

class Card
{
    public string color;
    public string Value;

    public Card(string color, string value)
    {
        this.color = color;
        this.Value = value;
    }

    enum Suits
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public static List<Card> CreateDeck()
    {
        List<Card> deck = new List<Card>();

        foreach (Suits suit in Enum.GetValues(typeof(Suits)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                deck.Add(new Card(suit.ToString(), rank.ToString()));
            }
        }

        Console.WriteLine("Deck of cards:");
        return deck;
    }

    public static void ShuffleDeck(List<Card> deck)
    {
        Random random = new Random();
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            Card temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }
}