using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCsharp
{
    class Program
    {
        public static int iPosX1;
        public static int iPosY1;
        public static int iPosX2;
        public static int iPosY2;
        public static string sMessageX;
        public static string sMessageY;
        static void Main(string[] args)
        {
            Console.WriteLine("*****Welcome to BattleShip!*****\n" +
                "RULES:\n1. Player 1 goes first\n2.Pick a number for X and Y from 0-9 to place your boat down\n3. Choose a number for X and Y to destroy\n" +
                "*****ENJOY PLAYING*****");
            int[,] a10x10Grid = { { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, // array for a 10 x 10 grid
                                    { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                                    { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                                    { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                                    { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}};
            while (true) // enable game to run endlessly until stated otherwise
            {
                PlayGame();
            }
        }
        public static void PlayGame()
        {
            try
            {
                sMessageX = "Select a X Position: ";
                sMessageY = "Select a Y Position: ";
                Console.WriteLine("PLAYER 1: \n");
                GetChosenXY(sMessageX, sMessageY, out iPosX1, out iPosY1); // gets user entered X & Y positions
                Console.Clear();
                Console.WriteLine("PLAYER 2: \n");
                GetChosenXY(sMessageX, sMessageY, out iPosX2, out iPosY2);
                Console.Clear();
                battleItOut(iPosX1, iPosY1, iPosX2, iPosY2);
            }catch(Exception e)
            {
                Console.WriteLine("Please Enter A Valid Number");
            }
        }
        public static void checkNumber(int num) // check if user selected a valid number between 0-9
        {
            if(num > 9 || num < 0)
            {
                Console.WriteLine("Please Enter a number between 0-9");
                PlayGame();
            }
        }
        public static void battleItOut(int iDPosX1, int iDPosY1, int iDPosX2, int iDPosY2) // will repeat until one player successfully destroys the other player selected box
        {
            while (true)
            {
                sMessageX = "Select a X Position To Destroy: ";
                sMessageY = "Select a Y Position To Destroy: ";
                Console.WriteLine("***PLAYER 1***");
                GetChosenXY(sMessageX, sMessageY, out iDPosX1, out iDPosY1); 
                checkHit(iDPosX1, iDPosY1 ,iPosX2, iPosY2);
                Console.WriteLine("***PLAYER 2***");
                GetChosenXY(sMessageX, sMessageY, out iDPosX2, out iDPosY2);
                checkHit(iDPosX2, iDPosY2, iPosX1, iPosY1);
            }
        }
        public static void GetChosenXY(string sMessage1, string sMessage2,  out int iChosenX, out int iChosenY) // get user x and y inputs whenever needed
        {
            Console.WriteLine(sMessage1);
            iChosenX = Convert.ToInt32(Console.ReadLine());
            checkNumber(iChosenX);
            Console.WriteLine(sMessage2);
            iChosenY = Convert.ToInt32(Console.ReadLine());
            checkNumber(iChosenY);
        }
        public static void checkHit(int iX, int iY, int iX2, int iY2) // check if player destroyed the other players selected box
        {
            if(iX.Equals(iX2) && iY.Equals(iY2))
            {
                Console.WriteLine("DESTROYED!");
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Better Luck Next Time!");
            }
        }

    }
}
