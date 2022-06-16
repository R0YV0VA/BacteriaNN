using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BacteriaNN
{
    class Field
    {
        public const int Bacterias_count = 100;
        public const int foodCount = 5;
        public const int tempFoodCount = 500;
        public const int fieldSize = 20;
        int[,] field = new int[fieldSize, fieldSize];
        Apple[] foods = new Apple[tempFoodCount];
        Bacteria[] bacterias = new Bacteria[Bacterias_count];
        Bacteria temp_bacteria;
        double[,] distations = new double[Bacterias_count, 4];
        public int population = 0;
        public double bestResult = 0;
        public double timeAlive = 0;
        
        public double getTimeAlive() => timeAlive;
        
        public void setFood_rnd()
        {
            for (int i = 0; i < Bacterias_count; i++)
                bacterias[i].getFieldSize(fieldSize);
            for (int i = 0; i < tempFoodCount; i++)
            {
            go:
                foods[i].setRandomPosition(fieldSize);
                for (int j = 0; j < Bacterias_count; j++)
                {
                    if (foods[i].getY() == bacterias[j].Y && foods[i].getX() == bacterias[j].X)
                        goto go;
                }
            }
        }
        public void setFoodToField()
        {
            for (int i = 0; i < tempFoodCount; i++)
            {
                if(foods[i].getisAlive())
                    field[foods[i].getY(), foods[i].getX()] = 1;
            }
        }
        public void printField()
        {
            for (int i = 0; i < fieldSize + 2; i++)
                Console.Write("#");
            Console.WriteLine($"   population:{population}  best result:{bestResult}    timeAlive:{timeAlive}");
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write("#");
                for (int j = 0; j < fieldSize; j++)
                {
                    if (field[i, j] == 1)
                    {
                        Console.Write("o");
                    }
                    else if (field[i, j] == 2)
                    {
                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("#");
            }
            for (int i = 0; i < fieldSize + 2; i++)
                Console.Write("#");
            //Console.WriteLine("1 dist:{0}   2 dist:{1}  3 dist:{2}  4 dist:{3}", distations[0, 0], distations[0, 1], distations[0, 2], distations[0, 3]);
            //Console.WriteLine("4 dist:{0}   5 dist:{1}  6 dist:{2}", distations[3], distations[4], distations[5]);
            //Console.WriteLine("7 dist:{0}   8 dist:{1}  9 dist:{2}", distations[6], distations[7], distations[8]);
            //Console.WriteLine("1 life:{0}   2 life:{1}  3 life:{2}", bacterias[0].timeAlive, bacterias[1].timeAlive, bacterias[2].timeAlive);
            //Console.WriteLine("4 life:{0}   5 life:{1}  6 life:{2}", bacterias[3].timeAlive, bacterias[4].timeAlive, bacterias[5].timeAlive);
            //Console.WriteLine("7 life:{0}   8 life:{1}  9 life:{2}", bacterias[6].timeAlive, bacterias[7].timeAlive, bacterias[8].timeAlive);
            //Console.WriteLine("1 up:{0}    2 up:{1}    3 up:{2}     4 up:{3}    5 up:{4}    6 up:{5}    7 up:{6}    8 up:{7}    9 up:{8}", bacterias[0].Sigmoids[0], bacterias[1].Sigmoids[0], bacterias[2].Sigmoids[0], bacterias[3].Sigmoids[0], bacterias[4].Sigmoids[0], bacterias[5].Sigmoids[0], bacterias[6].Sigmoids[0], bacterias[7].Sigmoids[0], bacterias[8].Sigmoids[0]);
            //Console.WriteLine("  down:{0}    down:{1}    down:{2}     down:{3}    down:{4}    down:{5}    down:{6}    down:{7}    down:{8}", bacterias[0].Sigmoids[1], bacterias[1].Sigmoids[1], bacterias[2].Sigmoids[1], bacterias[3].Sigmoids[1], bacterias[4].Sigmoids[1], bacterias[5].Sigmoids[1], bacterias[6].Sigmoids[1], bacterias[7].Sigmoids[1], bacterias[8].Sigmoids[1]);
            //Console.WriteLine("  left:{0}    left:{1}    left:{2}     left:{3}    left:{4}    left:{5}    left:{6}    left:{7}    left:{8}", bacterias[0].Sigmoids[2], bacterias[1].Sigmoids[2], bacterias[2].Sigmoids[2], bacterias[3].Sigmoids[2], bacterias[4].Sigmoids[2], bacterias[5].Sigmoids[2], bacterias[6].Sigmoids[2], bacterias[7].Sigmoids[2], bacterias[8].Sigmoids[2]);
            //Console.WriteLine("  right:{0}   right:{1}   right:{2}    right:{3}   right:{4}   right:{5}   right:{6}   right:{7}   right:{8}", bacterias[0].Sigmoids[3], bacterias[1].Sigmoids[3], bacterias[2].Sigmoids[3], bacterias[3].Sigmoids[3], bacterias[4].Sigmoids[3], bacterias[5].Sigmoids[3], bacterias[6].Sigmoids[3], bacterias[7].Sigmoids[3], bacterias[8].Sigmoids[3]);
        }
        public void setStartOptions()
        {
            for (int i = 0; i < Bacterias_count; i++)
                bacterias[i] = new Bacteria();
            for (int i = 0; i < tempFoodCount; i++)
                foods[i] = new Apple();
        }
        public void setStartPositions()
        {
            Random rnd = new Random();
            for (int i = 0; i < Bacterias_count; i++)
            {
                go2:
                int X = rnd.Next(0, fieldSize), Y = rnd.Next(0, fieldSize);
                for(int j = 0;j < foodCount; j++)
                {
                    if (foods[j].getX() == X && foods[j].getY() == Y)
                        goto go2;
                }
                bacterias[i].setPosition(X, Y);
            }

            for (int i = 0; i < Bacterias_count; i++)
                bacterias[i].setStartPosition();
                
            for (int i = 0; i < Bacterias_count/10; i++)
                field[bacterias[i].Y, bacterias[i].X] = 2;
        }
        public void fillFoodCountandDistation()
        {
            for (int i = 0; i < Bacterias_count; i++)
            {
                for (int j = 0; j < tempFoodCount; j++)
                {
                    if (foods[j].getisAlive())
                    {
                        if (foods[j].getY() < bacterias[i].Y && foods[j].getX() == bacterias[i].X)
                        {
                            distations[i, 0] = bacterias[i].Y - foods[j].getY();
                        }
                        else
                        {
                            distations[i, 0] = bacterias[i].Y;
                        }
                        if (foods[j].getY() > bacterias[i].Y && foods[j].getX() == bacterias[i].X)
                        {
                            distations[i, 1] = foods[j].getY() - bacterias[i].Y;
                        }
                        else
                        {
                            distations[i, 1] = fieldSize-1;
                        }
                        if (foods[j].getX() < bacterias[i].X && foods[j].getY() == bacterias[i].Y)
                        {
                            distations[i, 2] = bacterias[i].X - foods[j].getX();
                        }
                        else
                        {
                            distations[i, 2] = bacterias[i].X;
                        }
                        if (foods[j].getX() > bacterias[i].X && foods[j].getY() == bacterias[i].Y)
                        {
                            distations[i, 3] = foods[j].getX() - bacterias[i].X;
                        }
                        else
                        {
                            distations[i, 3] = fieldSize - 1;
                        }
                    }
                }
            }
        }
        public void makeStep()
        {
            checkFields();
            for (int i = 0; i < Bacterias_count; i++)
                field[bacterias[i].Y, bacterias[i].X] = 0;
            fillFoodCountandDistation();
            for (int i = 0; i < Bacterias_count; i++)
            {
                if (!bacterias[i].isDead)
                {
                    bacterias[i].makeStep(distations[i, 0], distations[i, 1], distations[i, 2], distations[i, 3]);
                    bacterias[i].timeMinus();
                    field[bacterias[i].Y, bacterias[i].X] = 2;
                }
                else 
                {
                    field[bacterias[i].Y, bacterias[i].X] = 0;
                }
            }
            checkFields();

        }
        public void checkFields()
        {
            for (int i = 0; i < Bacterias_count; i++)
            {
                for (int j = 0; j < tempFoodCount; j++)
                {
                    if (bacterias[i].Y == foods[j].getY() && bacterias[i].X == foods[j].getX() && foods[j].getisAlive())
                    {
                        field[foods[j].getY(), foods[j].getX()] = 2;
                        bacterias[i].timePlus();
                        if (j < foodCount)
                            foods[j].setRandomPosition(fieldSize);
                        else
                            foods[j].isAlive = false;
                    }
                }
            }
            setFoodToField();
        }
        public void progressFilter()
        {
            bool exit = true;
            Random rnd = new Random();
            for (int i = 0; i < Bacterias_count; i++)
            {
                if (!bacterias[i].isDead)
                { exit = false; }
            }
            if (exit)
            {
                population++;
                for (int i = 0; i < Bacterias_count; i++)
                    bacterias[i].setOldPosition();
                for (int j = 0; j < Bacterias_count; j++)
                {
                    for (int i = 1 + j; i < Bacterias_count; i++)
                    {
                        if (bacterias[i].getProgress() > bacterias[j].getProgress())
                        {
                            temp_bacteria = bacterias[j];
                            bacterias[j] = bacterias[i];
                            bacterias[i] = temp_bacteria;
                        }
                    }
                }
                bestResult = bacterias[0].progress;
                timeAlive = bacterias[0].lifeTime;
                for (int i = 0; i < Bacterias_count; i++)
                    bacterias[i].getWeights();
                for (int i = 25; i < Bacterias_count; i++)
                {
                    for (int j = 0; j < bacterias[0].weights_1.Length; j++)
                    {
                        int random_number = rnd.Next(1, 31);
                        int random_gen = rnd.Next(1, 11);
                        switch(random_number)
                        {
                            case 1: 
                                if(random_gen < 9)
                                    bacterias[i].weights_1[j] = bacterias[Bacterias_count-1].weights_1[j];
                                else
                                    bacterias[i].weights_1[j] = rnd.NextDouble();
                                break;
                            case 2:
                                bacterias[i].weights_1[j] = bacterias[0].weights_1[j];
                                break;
                            case 3:
                                bacterias[i].weights_1[j] = bacterias[0].weights_1[j];
                                break;
                            case 4:
                                bacterias[i].weights_1[j] = bacterias[0].weights_1[j];
                                break;
                            case 5:
                                bacterias[i].weights_1[j] = bacterias[0].weights_1[j];
                                break;
                            case 6:
                                bacterias[i].weights_1[j] = bacterias[0].weights_1[j];
                                break;
                            case 7:
                                bacterias[i].weights_1[j] = bacterias[0].weights_1[j];
                                break;
                            case 8:
                                bacterias[i].weights_1[j] = bacterias[0].weights_1[j];
                                break;
                            case 9:
                                bacterias[i].weights_1[j] = bacterias[0].weights_1[j];
                                break;
                            case 10:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 11:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 12:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 13:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 14:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 15:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 16:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 17:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 18:
                                bacterias[i].weights_1[j] = bacterias[1].weights_1[j];
                                break;
                            case 19:
                                bacterias[i].weights_1[j] = bacterias[2].weights_1[j];
                                break;
                            case 20:
                                bacterias[i].weights_1[j] = bacterias[2].weights_1[j];
                                break;
                            case 21:
                                bacterias[i].weights_1[j] = bacterias[2].weights_1[j];
                                break;
                            case 22:
                                bacterias[i].weights_1[j] = bacterias[2].weights_1[j];
                                break;
                            case 23:
                                bacterias[i].weights_1[j] = bacterias[2].weights_1[j];
                                break;
                            case 24:
                                bacterias[i].weights_1[j] = bacterias[2].weights_1[j];
                                break;
                            case 25:
                                bacterias[i].weights_1[j] = bacterias[2].weights_1[j];
                                break;
                            case 26:
                                bacterias[i].weights_1[j] = bacterias[2].weights_1[j];
                                break;
                            case 27:
                                bacterias[i].weights_1[j] = rnd.NextDouble();
                                //bacterias[i].weights_1[j] = bacterias[26].weights_1[j];
                                break;
                            case 28:
                                bacterias[i].weights_1[j] = rnd.NextDouble();
                                //bacterias[i].weights_1[j] = bacterias[27].weights_1[j];
                                break;
                            case 29:
                                bacterias[i].weights_1[j] = rnd.NextDouble();
                                //bacterias[i].weights_1[j] = bacterias[28].weights_1[j];
                                break;
                            case 30:
                                bacterias[i].weights_1[j] = rnd.NextDouble();
                                //bacterias[i].weights_1[j] = bacterias[29].weights_1[j];
                                break;
                            default:
                                bacterias[i].weights_1[j] = rnd.NextDouble();
                                break;
                        }
                    }
                    for (int j = 0; j < bacterias[0].weights_2.Length; j++)
                    {
                        int random_number = rnd.Next(1, 31);
                        switch (random_number)
                        {
                            case 1:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 2:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 3:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 4:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 5:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 6:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 7:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 8:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 9:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 10:
                                bacterias[i].weights_2[j] = bacterias[0].weights_2[j];
                                break;
                            case 11:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 12:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 13:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 14:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 15:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 16:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 17:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 18:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 19:
                                bacterias[i].weights_2[j] = bacterias[1].weights_2[j];
                                break;
                            case 20:
                                bacterias[i].weights_2[j] = bacterias[2].weights_2[j];
                                break;
                            case 21:
                                bacterias[i].weights_2[j] = bacterias[2].weights_2[j];
                                break;
                            case 22:
                                bacterias[i].weights_2[j] = bacterias[2].weights_2[j];
                                break;
                            case 23:
                                bacterias[i].weights_2[j] = bacterias[2].weights_2[j];
                                break;
                            case 24:
                                bacterias[i].weights_2[j] = bacterias[2].weights_2[j];
                                break;
                            case 25:
                                bacterias[i].weights_2[j] = bacterias[2].weights_2[j];
                                break;
                            case 26:
                                bacterias[i].weights_2[j] = bacterias[2].weights_2[j];
                                break;
                            case 27:
                                bacterias[i].weights_2[j] = rnd.NextDouble();
                                //bacterias[i].weights_2[j] = bacterias[26].weights_2[j];
                                break;
                            case 28:
                                bacterias[i].weights_2[j] = rnd.NextDouble();
                                //bacterias[i].weights_2[j] = bacterias[27].weights_2[j];
                                break;
                            case 29:
                                bacterias[i].weights_2[j] = rnd.NextDouble();
                                //bacterias[i].weights_2[j] = bacterias[28].weights_2[j];
                                break;
                            case 30:
                                bacterias[i].weights_2[j] = rnd.NextDouble();
                                //bacterias[i].weights_2[j] = bacterias[29].weights_2[j];
                                break;
                            default:
                                bacterias[i].weights_2[j] = rnd.NextDouble();
                                break;
                        }
                    }
                    for (int j = 0; j < bacterias[0].weights_3.Length; j++)
                    {
                        int random_number = rnd.Next(1, 31);
                        switch (random_number)
                        {
                            case 1:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 2:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 3:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 4:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 5:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 6:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 7:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 8:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 9:
                                bacterias[i].weights_3[j] = bacterias[0].weights_3[j];
                                break;
                            case 10:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 11:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 12:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 13:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 14:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 15:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 16:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 17:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 18:
                                bacterias[i].weights_3[j] = bacterias[1].weights_3[j];
                                break;
                            case 19:
                                bacterias[i].weights_3[j] = bacterias[2].weights_3[j];
                                break;
                            case 20:
                                bacterias[i].weights_3[j] = bacterias[2].weights_3[j];
                                break;
                            case 21:
                                bacterias[i].weights_3[j] = bacterias[2].weights_3[j];
                                break;
                            case 22:
                                bacterias[i].weights_3[j] = bacterias[2].weights_3[j];
                                break;
                            case 23:
                                bacterias[i].weights_3[j] = bacterias[2].weights_3[j];
                                break;
                            case 24:
                                bacterias[i].weights_3[j] = bacterias[2].weights_3[j];
                                break;
                            case 25:
                                bacterias[i].weights_3[j] = bacterias[2].weights_3[j];
                                break;
                            case 26:
                                bacterias[i].weights_3[j] = bacterias[2].weights_3[j];
                                break;
                            case 27:
                                bacterias[i].weights_3[j] = rnd.NextDouble();
                                //bacterias[i].weights_3[j] = bacterias[26].weights_3[j];
                                break;
                            case 28:
                                bacterias[i].weights_3[j] = rnd.NextDouble();
                                //bacterias[i].weights_3[j] = bacterias[27].weights_3[j];
                                break;
                            case 29:
                                bacterias[i].weights_3[j] = rnd.NextDouble();
                                //bacterias[i].weights_3[j] = bacterias[28].weights_3[j];
                                break;
                            case 30:
                                bacterias[i].weights_3[j] = rnd.NextDouble();
                                //bacterias[i].weights_3[j] = bacterias[29].weights_3[j];
                                break;
                            default:
                                bacterias[i].weights_3[j] = rnd.NextDouble();
                                break;
                        }
                    }
                }
                for (int i = 0; i < Bacterias_count; i++)
                {
                    bacterias[i].setStartOptions();
                    bacterias[i].setWeights();
                }
                clearField();
                for (int i = 0; i < tempFoodCount; i++)
                    foods[i].isAlive = true;
                setFood_rnd();
                setFoodToField();
                setStartPositions();
            }

        }
        public void clearField()
        {
            for(int i = 0;i< fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    field[i, j] = 0;
                }
            }
        }
    }
}
