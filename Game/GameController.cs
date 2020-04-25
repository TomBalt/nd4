using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGame.Units;

namespace ConsoleGame.Game
{
    class GameController
    {
        private PlayerSelectionMenu playerSelectionMenu;
        private DiceSelectionMenu diceSelectionMenu;
        private int numberOfPLayers;
        private int numberOfDices;
        private List<Player> players = new List<Player>();
        private Dice dice = new Dice();
        private int highestScoreNumber;
        private bool winnerNotFound = false;

        public void StartGame()
        {
            InitGame();
            RollTheDice();
        }

        public void ReplayGame()
        {
            Console.Clear();
            Console.WriteLine($"Replaying game with {numberOfPLayers} number of and number {numberOfDices} of dices.");
            Console.ReadKey();
            preparePlayersForAGame(numberOfPLayers);
            RollTheDice();
        }

        private void RollTheDice() {
            winnerNotFound = true;
            do
            {
                StartPlayingGame(players);
                findAWinner(players);
            } while (winnerNotFound);
        }

        private void InitGame()
        {
            diceSelectionMenu = new DiceSelectionMenu();
            playerSelectionMenu = new PlayerSelectionMenu();
           
            numberOfPLayers = playerSelectionMenu.GetNumberOfPlayers();
            preparePlayersForAGame(numberOfPLayers);
            
            numberOfDices = diceSelectionMenu.GetNumberOfDices();

        }
        private void preparePlayersForAGame(int numberOfPLayers) {
            players.Clear();
            for (int i = 0; i < numberOfPLayers; i++)
            {
                int nr = i + 1;
                string playername = "P" + nr.ToString();
                players.Add(new Player(playername));
            }
        }

        private void StartPlayingGame(List<Player> gamePlayers)
        {
            Console.Clear();
            Console.WriteLine($"In this game will be {gamePlayers.Count} playing and rolling {numberOfDices} dices at a time.");
            Console.WriteLine("============================");
            foreach (Player player in gamePlayers)
            {
                Console.WriteLine($"Playing player: {player.Name}");
                for (int i = 0; i < numberOfDices; i++)
                {
                    System.Threading.Thread.Sleep(250);
                    dice.ThrowADice();

                    Console.WriteLine($"Player {player.Name} throwing {i+1} time and score: {dice.Score}");
                    player.Score = player.Score + dice.Score;
                }
                Console.WriteLine($"Player {player.Name} has scored: {player.Score}");
                System.Threading.Thread.Sleep(250);
                Console.WriteLine("============================");
            }
            System.Threading.Thread.Sleep(250);
        }

        private void findAWinner(List<Player> gamePlayers)
        {
            List<int> listOfScores = new List<int>();
            if (gamePlayers.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            foreach (Player p in gamePlayers) {
                listOfScores.Add(p.Score);
            }
            
            highestScoreNumber = highestScore(listOfScores);
            winnerNotFound = numberOfWinners(listOfScores, highestScoreNumber);
            if (winnerNotFound)
            {
                GameNotificationWindow newRoundWindow = new GameNotificationWindow( new List<string>() { "More than one high scorer", " " , "     NEW ROUND" });
                newRoundWindow.Render();
                prepareForAnotherRound(gamePlayers, highestScoreNumber);
                Console.ReadKey();
            }
            else {
                
                foreach (Player p in gamePlayers)
                {
                    if (p.Score == highestScoreNumber)
                    {
                        GameNotificationWindow winnerWindow = new GameNotificationWindow( new List<string>() { "Winner of the game!!!","      " + p.Name, "With a score of "+ highestScoreNumber });
                        winnerWindow.Render();
                        Console.ReadKey();
                    }
                }
                winnerNotFound = false;
            }
        }

        private void prepareForAnotherRound(List<Player> gamePlayers, int highestScoreNumber) {
            List<Player> anotheRoundPlayers = new List<Player>();
            foreach (Player p in gamePlayers) {
                if (p.Score == highestScoreNumber) {
                    p.Score = 0;
                    anotheRoundPlayers.Add(p);
                }
            }
            players.Clear();
            players.AddRange(anotheRoundPlayers);
            players.ForEach(p => Console.WriteLine("Player for a new round : " + p.Name));
        }

        private bool numberOfWinners(List<int> scores, int highestScore) {
            int i = 0;
            foreach (int score in scores) {
                if (score == highestScore) {
                    i += 1;
                }
            }
            Console.WriteLine($"Number of players with highest {highestScore} score : {i}" );
            return i != 1;
        }
        private int highestScore(List<int> scores)
        {

            int maxScore = 0;
           
            foreach (int score in scores)
            {
                if (score > maxScore)
                {
                    maxScore = score;
                }
            }

            return maxScore;
        }
    }
}
