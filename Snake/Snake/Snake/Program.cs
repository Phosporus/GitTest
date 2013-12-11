using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;


namespace Snake
{
    public class Program
    {
        static int counter = 0;

        static void Main(string[] args)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Dropbox\Handledare\Datastrukturer och algoritmer\Rättningar projektet\Abu\Snake\Snake\Snake\textfile.txt"); //Läser textdokumentet med angivna värden.
            string[] first = file.ReadLine().Split(','); //skapar en array som splittar.

            int wide = Int16.Parse(first[0]); //Sätter bredden till 4
            int height = Int16.Parse(first[1]); //Sätter höjden till 4
            int forbidden = Int16.Parse(first[2]); //Anger koordinaterna
            int[,] coordinates = new int[wide, height]; //En instans av int arrayen med bredden och höjden som attribut

            for (int x = 0; x < wide; x++) //sätter de olika rutorna till 0
            {
                for (int y = 0; y < height; y++)
                {
                    coordinates[x, y] = 0;
                }
            }



            while ((line = file.ReadLine()) != null) 
            {
                string[] blocks = line.Split(','); 
                int x = Int16.Parse(blocks[0]); 
                int y = Int16.Parse(blocks[1]);
                coordinates[x, y] = 1; 
            }
            file.Close();
            DFS(coordinates, 0, 0);
            Console.WriteLine("Number of visited coordinates: " + counter);
            Console.ReadLine();
        }

        public static bool DFS(int[,] coordinates, int x, int y)    
        {
            counter++; //Ökar med 1 hela tiden
            Console.WriteLine(x + "  " + y); //Detta skriver ut resultatet
            coordinates[x, y] = 2; 
           
            if (y + 1 < coordinates.GetLength(1)) 
            {
                if (coordinates[x, y + 1] != 2 && coordinates[x, y + 1] != 1) //IFall grannen inte är besökt eller förbjuden
                {
                    return DFS(coordinates, x, y + 1); //Ett steg ner
                }
            }
            if (x - 1 >= 0) 
            {
                if (coordinates[x - 1, y] != 2 && coordinates[x - 1, y] != 1) 
                {
                    return DFS(coordinates, x - 1, y); //Ett steg till vänster
                }
            }
            if (x + 1 < coordinates.GetLength(0)) 
            {
                if (coordinates[x + 1, y] != 2 && coordinates[x + 1, y] != 1) //Ifall grannen inte är besökt eller förbjuden
                {
                    return DFS(coordinates, x + 1, y); //Ett steg till höger
                }
            }
            if (y - 1 >= 0)
            {
                if (coordinates[x, y - 1] != 2 && coordinates[x, y - 1] != 1) //Ifall grannar inte är besökta eller förbjudna
                {
                    return DFS(coordinates, x, y - 1); //Ett steg upp
                }
            }
            return false; // Ifall ingen av statements är true, så returnerar den false.
        }

    }
}
