using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Home11GENERICS
{
    public class FootballTeam : IEnumerable<Footballer>
    {
        public Footballer[] Players { get; set; }
        public FootballTeam(Footballer[] players)
        {
               Players = players;
        }
        public void AddPlayer(Footballer newPlayer)
        {
            var temp = Players;
            Array.Resize(ref temp, temp.Length + 1);
            Players = temp;
            Players[Players.Length - 1] = newPlayer;
        }
        public void ReplacePlayer(int index, Footballer newPlayer)
        {
            if (index >= 0 && index < Players.Length)
            {
                Players[index] = newPlayer;
            }
        }
        public void RemovePlayer(int index)
        {
            if (index >= 0 && index < Players.Length)
            {
                for (int i = index; i < Players.Length - 1; i++)
                {
                    Players[i] = Players[i + 1];
                }
                var temp = Players;
                Array.Resize(ref temp, temp.Length - 1);
                Players = temp;
            }
        }
        public IEnumerator<Footballer> GetEnumerator()
        {
            foreach (Footballer player in Players)
            {
                yield return player;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
