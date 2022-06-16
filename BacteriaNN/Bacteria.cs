using System;

namespace BacteriaNN
{
    class Bacteria
    {
        private Layer in_to_hid_1 = new Layer(8);
        private Layer in_to_hid_2 = new Layer(8);
        private Layer in_to_hid_3 = new Layer(8);
        private Layer in_to_hid_4 = new Layer(8);
        private Layer in_to_hid_5 = new Layer(8);
        private Layer in_to_hid_6 = new Layer(8);
        private Layer in_to_hid_7 = new Layer(8);
        public double[] weights_1 = new double[56];

        private Layer hid_to_hid_1 = new Layer(7);
        private Layer hid_to_hid_2 = new Layer(7);
        private Layer hid_to_hid_3 = new Layer(7);
        private Layer hid_to_hid_4 = new Layer(7);
        private Layer hid_to_hid_5 = new Layer(7);
        private Layer hid_to_hid_6 = new Layer(7);
        private Layer hid_to_hid_7 = new Layer(7);
        public double[] weights_2 = new double[49];

        private Layer hid_to_out_1 = new Layer(7);
        private Layer hid_to_out_2 = new Layer(7);
        private Layer hid_to_out_3 = new Layer(7);
        private Layer hid_to_out_4 = new Layer(7);
        public double[] weights_3 = new double[28];
        public double[] Sigmoids = new double[4];
        public int X = 0;
        public int Y = 0;
        public int stX = 0;
        public int stY = 0;
        public int oldX = 0;
        public int oldY = 0;
        public int timeAlive = 100;
        public int lifeTime = 0;
        public int eatFood = 0;
        public bool isDead = false;
        public double progress;
        private double distanceToWallLeft;
        private double distanceToWallRight;
        private double distanceToWallUp;
        private double distanceToWallDown;
        private double dir;
        private int fieldSize;
        public void getFieldSize(int _fieldSize)
        {
            fieldSize = _fieldSize;
        }
        public void setStartOptions()
        {
            isDead = false;
            timeAlive = 100;
            lifeTime = 0;
            eatFood = 0;
            progress = 0;
        }
        public void timeMinus()
        {
            timeAlive--;
            if (timeAlive < 1)
                isDead = true;      
        }
        public void timePlus()
        {
            timeAlive += 50;
            eatFood++;
        }
        public void setPosition(int _x,int _y)
        {
            X = _x;
            Y = _y;
        }
        public void setStartPosition()
        {
            stX = X;
            stY = Y;
        }
        public void setOldPosition()
        {
            oldX = X;
            oldY = Y;
        }
        public double getProgress()
        {
            double prog = Math.Pow(lifeTime, 2) * Math.Pow(2, Math.Min(eatFood, 10)) * Math.Max(1, eatFood - 9);
        //    if (X == stX && Y == stY)
        //        prog *= 0;
            if (X == stX)
            {
                prog *= 0.5;
        //        if (Y < 1 || Y > 18)
        //            prog *= 0.1;
            }
            if (Y == stY)
            {
                prog *= 0.5;
        //        if (X < 1 || X > 18)
        //            prog *= 0.1;
            }
            /*if (lifeTime < 10)
                prog *= 0;
            else if (lifeTime < 20)
               prog *= 0.1;
            else if (lifeTime < 30)
                prog *= 0.3;
            else if (lifeTime < 40)
                prog *= 0.7;
            else if (lifeTime < 50)
                prog *= 0.9;*/
            return prog;
        }
        public void getWeights()
        {
            for (int i = 0, j = 0; i < 8; i++)
            {
                weights_1[i] = in_to_hid_1.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 8, j = 0; i < 16; i++)
            {
                weights_1[i] = in_to_hid_2.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 16, j = 0; i < 24; i++)
            {
                weights_1[i] = in_to_hid_3.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 24, j = 0; i < 32; i++)
            {
                weights_1[i] = in_to_hid_4.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 32, j = 0; i < 40; i++)
            {
                weights_1[i] = in_to_hid_5.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 40, j = 0; i < 48; i++)
            {
                weights_1[i] = in_to_hid_6.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 48, j = 0; i < 56; i++)
            {
                weights_1[i] = in_to_hid_7.GetNeuroWeigh(j);
                j++;
            }
            ///////////////////////////////////////////
            for (int i = 0, j = 0; i < 7; i++)
            {
                weights_2[i] = hid_to_hid_1.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 7, j = 0; i < 14; i++)
            {
                weights_2[i] = hid_to_hid_2.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 14, j = 0; i < 21; i++)
            {
                weights_2[i] = hid_to_hid_3.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 21, j = 0; i < 28; i++)
            {
                weights_2[i] = hid_to_hid_4.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 28, j = 0; i < 35; i++)
            {
                weights_2[i] = hid_to_hid_5.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 35, j = 0; i < 42; i++)
            {
                weights_2[i] = hid_to_hid_6.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 42, j = 0; i < 49; i++)
            {
                weights_2[i] = hid_to_hid_6.GetNeuroWeigh(j);
                j++;
            }
            ///////////////////////////////////////////
            for (int i = 0, j = 0; i < 7; i++)
            {
                weights_3[i] = hid_to_out_1.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 7, j = 0; i < 14; i++)
            {
                weights_3[i] = hid_to_out_2.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 14, j = 0; i < 21; i++)
            {
                weights_3[i] = hid_to_out_3.GetNeuroWeigh(j);
                j++;
            }
            for (int i = 21, j = 0; i < 28; i++)
            {
                weights_3[i] = hid_to_out_4.GetNeuroWeigh(j);
                j++;
            }
        }
        public void setWeights()
        {
            for (int i = 0, j = 0; i < 8; i++)
            {
                in_to_hid_1.SetNeuroWeigh(j, weights_1[i]);
                j++;
            }
            for (int i = 8, j = 0; i < 16; i++)
            {
                in_to_hid_2.SetNeuroWeigh(j, weights_1[i]);
                j++;
            }
            for (int i = 16, j = 0; i < 24; i++)
            {
                in_to_hid_3.SetNeuroWeigh(j, weights_1[i]);
                j++;
            }
            for (int i = 24, j = 0; i < 32; i++)
            {
                in_to_hid_4.SetNeuroWeigh(j, weights_1[i]);
                j++;
            }
            for (int i = 32, j = 0; i < 40; i++)
            {
                in_to_hid_5.SetNeuroWeigh(j, weights_1[i]);
                j++;
            }
            for (int i = 40, j = 0; i < 48; i++)
            {
                in_to_hid_6.SetNeuroWeigh(j, weights_1[i]);
                j++;
            }
            for (int i = 48, j = 0; i < 56; i++)
            {
                in_to_hid_7.SetNeuroWeigh(j, weights_1[i]);
                j++;
            }
            ///////////////////////////////////////////
            for (int i = 0, j = 0; i < 7; i++)
            {
                hid_to_hid_1.SetNeuroWeigh(j, weights_2[i]);
                j++;
            }
            for (int i = 7, j = 0; i < 14; i++)
            {
                hid_to_hid_2.SetNeuroWeigh(j, weights_2[i]);
                j++;
            }
            for (int i = 14, j = 0; i < 21; i++)
            {
                hid_to_hid_3.SetNeuroWeigh(j, weights_2[i]);
                j++;
            }
            for (int i = 21, j = 0; i < 28; i++)
            {
                hid_to_hid_4.SetNeuroWeigh(j, weights_2[i]);
                j++;
            }
            for (int i = 28, j = 0; i < 35; i++)
            {
                hid_to_hid_5.SetNeuroWeigh(j, weights_2[i]);
                j++;
            }
            for (int i = 35, j = 0; i < 42; i++)
            {
                hid_to_hid_6.SetNeuroWeigh(j, weights_2[i]);
                j++;
            }
            for (int i = 42, j = 0; i < 49; i++)
            {
                hid_to_hid_6.SetNeuroWeigh(j, weights_2[i]);
                j++;
            }
            ///////////////////////////////////////////
            for (int i = 0, j = 0; i < 7; i++)
            {
                hid_to_out_1.SetNeuroWeigh(j, weights_3[i]);
                j++;
            }
            for (int i = 7, j = 0; i < 14; i++)
            {
                hid_to_out_2.SetNeuroWeigh(j, weights_3[i]);
                j++;
            }
            for (int i = 14, j = 0; i < 21; i++)
            {
                hid_to_out_3.SetNeuroWeigh(j, weights_3[i]);
                j++;
            }
            for (int i = 21, j = 0; i < 28; i++)
            {
                hid_to_out_4.SetNeuroWeigh(j, weights_3[i]);
                j++;
            }
        }
        public void  makeStep(double distanceToFoodUp, double distanceToFoodDown, double distanceToFoodLeft, double distanceToFoodRight)
        {
            distanceToWallLeft = Math.Pow(Math.Pow(0 - X, 2), 0.5);
            distanceToWallRight = Math.Pow(Math.Pow(fieldSize-1 - X, 2), 0.5);
            distanceToWallUp = Math.Pow(Math.Pow(0 - Y, 2), 0.5);
            distanceToWallDown = Math.Pow(Math.Pow(fieldSize-1 - Y, 2), 0.5);
            distanceToWallLeft = X;
            distanceToWallRight = ((fieldSize - 1) - X);
            distanceToWallUp = Y;
            distanceToWallDown = ((fieldSize - 1) - Y);
            progress = getProgress();
            in_to_hid_1.SetNeuroImpulse(0, distanceToWallUp);
            in_to_hid_1.SetNeuroImpulse(1, distanceToWallDown);
            in_to_hid_1.SetNeuroImpulse(2, distanceToWallLeft);
            in_to_hid_1.SetNeuroImpulse(3, distanceToWallRight);
            in_to_hid_1.SetNeuroImpulse(4, distanceToFoodUp);
            in_to_hid_1.SetNeuroImpulse(5, distanceToFoodDown);
            in_to_hid_1.SetNeuroImpulse(6, distanceToFoodLeft);
            in_to_hid_1.SetNeuroImpulse(7, distanceToFoodRight);

            in_to_hid_2.SetNeuroImpulse(0, distanceToWallUp);
            in_to_hid_2.SetNeuroImpulse(1, distanceToWallDown);
            in_to_hid_2.SetNeuroImpulse(2, distanceToWallLeft);
            in_to_hid_2.SetNeuroImpulse(3, distanceToWallRight);
            in_to_hid_2.SetNeuroImpulse(4, distanceToFoodUp);
            in_to_hid_2.SetNeuroImpulse(5, distanceToFoodDown);
            in_to_hid_2.SetNeuroImpulse(6, distanceToFoodLeft);
            in_to_hid_2.SetNeuroImpulse(7, distanceToFoodRight);

            in_to_hid_3.SetNeuroImpulse(0, distanceToWallUp);
            in_to_hid_3.SetNeuroImpulse(1, distanceToWallDown);
            in_to_hid_3.SetNeuroImpulse(2, distanceToWallLeft);
            in_to_hid_3.SetNeuroImpulse(3, distanceToWallRight);
            in_to_hid_3.SetNeuroImpulse(4, distanceToFoodUp);
            in_to_hid_3.SetNeuroImpulse(5, distanceToFoodDown);
            in_to_hid_3.SetNeuroImpulse(6, distanceToFoodLeft);
            in_to_hid_3.SetNeuroImpulse(7, distanceToFoodRight);

            in_to_hid_4.SetNeuroImpulse(0, distanceToWallUp);
            in_to_hid_4.SetNeuroImpulse(1, distanceToWallDown);
            in_to_hid_4.SetNeuroImpulse(2, distanceToWallLeft);
            in_to_hid_4.SetNeuroImpulse(3, distanceToWallRight);
            in_to_hid_4.SetNeuroImpulse(4, distanceToFoodUp);
            in_to_hid_4.SetNeuroImpulse(5, distanceToFoodDown);
            in_to_hid_4.SetNeuroImpulse(6, distanceToFoodLeft);
            in_to_hid_4.SetNeuroImpulse(7, distanceToFoodRight);

            in_to_hid_5.SetNeuroImpulse(0, distanceToWallUp);
            in_to_hid_5.SetNeuroImpulse(1, distanceToWallDown);
            in_to_hid_5.SetNeuroImpulse(2, distanceToWallLeft);
            in_to_hid_5.SetNeuroImpulse(3, distanceToWallRight);
            in_to_hid_5.SetNeuroImpulse(4, distanceToFoodUp);
            in_to_hid_5.SetNeuroImpulse(5, distanceToFoodDown);
            in_to_hid_5.SetNeuroImpulse(6, distanceToFoodLeft);
            in_to_hid_5.SetNeuroImpulse(7, distanceToFoodRight);

            in_to_hid_6.SetNeuroImpulse(0, distanceToWallUp);
            in_to_hid_6.SetNeuroImpulse(1, distanceToWallDown);
            in_to_hid_6.SetNeuroImpulse(2, distanceToWallLeft);
            in_to_hid_6.SetNeuroImpulse(3, distanceToWallRight);
            in_to_hid_6.SetNeuroImpulse(4, distanceToFoodUp);
            in_to_hid_6.SetNeuroImpulse(5, distanceToFoodDown);
            in_to_hid_6.SetNeuroImpulse(6, distanceToFoodLeft);
            in_to_hid_6.SetNeuroImpulse(7, distanceToFoodRight);

            in_to_hid_7.SetNeuroImpulse(0, distanceToWallUp);
            in_to_hid_7.SetNeuroImpulse(1, distanceToWallDown);
            in_to_hid_7.SetNeuroImpulse(2, distanceToWallLeft);
            in_to_hid_7.SetNeuroImpulse(3, distanceToWallRight);
            in_to_hid_7.SetNeuroImpulse(4, distanceToFoodUp);
            in_to_hid_7.SetNeuroImpulse(5, distanceToFoodDown);
            in_to_hid_7.SetNeuroImpulse(6, distanceToFoodLeft);
            in_to_hid_7.SetNeuroImpulse(7, distanceToFoodRight);

            hid_to_hid_1.SetNeuroImpulse(0, in_to_hid_1.Sigmoid());
            hid_to_hid_1.SetNeuroImpulse(1, in_to_hid_2.Sigmoid());
            hid_to_hid_1.SetNeuroImpulse(2, in_to_hid_3.Sigmoid());
            hid_to_hid_1.SetNeuroImpulse(3, in_to_hid_4.Sigmoid());
            hid_to_hid_1.SetNeuroImpulse(4, in_to_hid_5.Sigmoid());
            hid_to_hid_1.SetNeuroImpulse(5, in_to_hid_6.Sigmoid());
            hid_to_hid_1.SetNeuroImpulse(6, in_to_hid_7.Sigmoid());

            hid_to_hid_2.SetNeuroImpulse(0, in_to_hid_1.Sigmoid());
            hid_to_hid_2.SetNeuroImpulse(1, in_to_hid_2.Sigmoid());
            hid_to_hid_2.SetNeuroImpulse(2, in_to_hid_3.Sigmoid());
            hid_to_hid_2.SetNeuroImpulse(3, in_to_hid_4.Sigmoid());
            hid_to_hid_2.SetNeuroImpulse(4, in_to_hid_5.Sigmoid());
            hid_to_hid_2.SetNeuroImpulse(5, in_to_hid_6.Sigmoid());
            hid_to_hid_2.SetNeuroImpulse(6, in_to_hid_7.Sigmoid());

            hid_to_hid_3.SetNeuroImpulse(0, in_to_hid_1.Sigmoid());
            hid_to_hid_3.SetNeuroImpulse(1, in_to_hid_2.Sigmoid());
            hid_to_hid_3.SetNeuroImpulse(2, in_to_hid_3.Sigmoid());
            hid_to_hid_3.SetNeuroImpulse(3, in_to_hid_4.Sigmoid());
            hid_to_hid_3.SetNeuroImpulse(4, in_to_hid_5.Sigmoid());
            hid_to_hid_3.SetNeuroImpulse(5, in_to_hid_6.Sigmoid());
            hid_to_hid_3.SetNeuroImpulse(6, in_to_hid_7.Sigmoid());

            hid_to_hid_4.SetNeuroImpulse(0, in_to_hid_1.Sigmoid());
            hid_to_hid_4.SetNeuroImpulse(1, in_to_hid_2.Sigmoid());
            hid_to_hid_4.SetNeuroImpulse(2, in_to_hid_3.Sigmoid());
            hid_to_hid_4.SetNeuroImpulse(3, in_to_hid_4.Sigmoid());
            hid_to_hid_4.SetNeuroImpulse(4, in_to_hid_5.Sigmoid());
            hid_to_hid_4.SetNeuroImpulse(5, in_to_hid_6.Sigmoid());
            hid_to_hid_4.SetNeuroImpulse(6, in_to_hid_7.Sigmoid());

            hid_to_hid_5.SetNeuroImpulse(0, in_to_hid_1.Sigmoid());
            hid_to_hid_5.SetNeuroImpulse(1, in_to_hid_2.Sigmoid());
            hid_to_hid_5.SetNeuroImpulse(2, in_to_hid_3.Sigmoid());
            hid_to_hid_5.SetNeuroImpulse(3, in_to_hid_4.Sigmoid());
            hid_to_hid_5.SetNeuroImpulse(4, in_to_hid_5.Sigmoid());
            hid_to_hid_5.SetNeuroImpulse(5, in_to_hid_6.Sigmoid());
            hid_to_hid_5.SetNeuroImpulse(6, in_to_hid_7.Sigmoid());

            hid_to_hid_6.SetNeuroImpulse(0, in_to_hid_1.Sigmoid());
            hid_to_hid_6.SetNeuroImpulse(1, in_to_hid_2.Sigmoid());
            hid_to_hid_6.SetNeuroImpulse(2, in_to_hid_3.Sigmoid());
            hid_to_hid_6.SetNeuroImpulse(3, in_to_hid_4.Sigmoid());
            hid_to_hid_6.SetNeuroImpulse(4, in_to_hid_5.Sigmoid());
            hid_to_hid_6.SetNeuroImpulse(5, in_to_hid_6.Sigmoid());
            hid_to_hid_6.SetNeuroImpulse(6, in_to_hid_7.Sigmoid());

            hid_to_out_1.SetNeuroImpulse(0, hid_to_hid_1.Sigmoid());
            hid_to_out_1.SetNeuroImpulse(1, hid_to_hid_2.Sigmoid());
            hid_to_out_1.SetNeuroImpulse(2, hid_to_hid_3.Sigmoid());
            hid_to_out_1.SetNeuroImpulse(3, hid_to_hid_4.Sigmoid());
            hid_to_out_1.SetNeuroImpulse(4, hid_to_hid_5.Sigmoid());
            hid_to_out_1.SetNeuroImpulse(5, hid_to_hid_6.Sigmoid());
            hid_to_out_1.SetNeuroImpulse(6, hid_to_hid_7.Sigmoid());

            hid_to_out_2.SetNeuroImpulse(0, hid_to_hid_1.Sigmoid());
            hid_to_out_2.SetNeuroImpulse(1, hid_to_hid_2.Sigmoid());
            hid_to_out_2.SetNeuroImpulse(2, hid_to_hid_3.Sigmoid());
            hid_to_out_2.SetNeuroImpulse(3, hid_to_hid_4.Sigmoid());
            hid_to_out_2.SetNeuroImpulse(4, hid_to_hid_5.Sigmoid());
            hid_to_out_2.SetNeuroImpulse(5, hid_to_hid_6.Sigmoid());
            hid_to_out_2.SetNeuroImpulse(6, hid_to_hid_7.Sigmoid());

            hid_to_out_3.SetNeuroImpulse(0, hid_to_hid_1.Sigmoid());
            hid_to_out_3.SetNeuroImpulse(1, hid_to_hid_2.Sigmoid());
            hid_to_out_3.SetNeuroImpulse(2, hid_to_hid_3.Sigmoid());
            hid_to_out_3.SetNeuroImpulse(3, hid_to_hid_4.Sigmoid());
            hid_to_out_3.SetNeuroImpulse(4, hid_to_hid_5.Sigmoid());
            hid_to_out_3.SetNeuroImpulse(5, hid_to_hid_6.Sigmoid());
            hid_to_out_3.SetNeuroImpulse(6, hid_to_hid_7.Sigmoid());

            hid_to_out_4.SetNeuroImpulse(0, hid_to_hid_1.Sigmoid());
            hid_to_out_4.SetNeuroImpulse(1, hid_to_hid_2.Sigmoid());
            hid_to_out_4.SetNeuroImpulse(2, hid_to_hid_3.Sigmoid());
            hid_to_out_4.SetNeuroImpulse(3, hid_to_hid_4.Sigmoid());
            hid_to_out_4.SetNeuroImpulse(4, hid_to_hid_5.Sigmoid());
            hid_to_out_4.SetNeuroImpulse(5, hid_to_hid_6.Sigmoid());
            hid_to_out_4.SetNeuroImpulse(6, hid_to_hid_7.Sigmoid());
            Sigmoids[0] = hid_to_out_1.Sigmoid();
            Sigmoids[1] = hid_to_out_2.Sigmoid();
            Sigmoids[2] = hid_to_out_3.Sigmoid();
            Sigmoids[3] = hid_to_out_4.Sigmoid();
            lifeTime++;
            if (Sigmoids[0] > Sigmoids[1] && Sigmoids[0] > Sigmoids[2] && Sigmoids[0] > Sigmoids[3])
            {
                if(dir != 4)
                    dir = 3; 
            }
            if (Sigmoids[1] > Sigmoids[0] && Sigmoids[1] > Sigmoids[2] && Sigmoids[1] > Sigmoids[3])
            {
                if (dir != 3)
                    dir = 4;
            }
            if (Sigmoids[2] > Sigmoids[0] && Sigmoids[2] > Sigmoids[1] && Sigmoids[2] > Sigmoids[3])
            {
                if (dir != 2)
                    dir = 1;
            }
            if (Sigmoids[3] > Sigmoids[0] && Sigmoids[3] > Sigmoids[1] && Sigmoids[3] > Sigmoids[2])
            {
                if (dir != 1)
                    dir = 2;
            }
            setDir();
        }
        private void setDir()
        {
            if(dir == 1)
            {
                if (Y > 0)
                {
                    Y--;
                }
                else
                    isDead = true;
            }
            if (dir == 2)
            {
                if (Y < fieldSize-1)
                {
                    Y++;
                }
                else
                    isDead = true;
            }
            if (dir == 3)
            {
                if (X > 0)
                {
                    X--;
                }
                else
                    isDead = true;
            }
            if (dir == 4)
            {
                if (X < fieldSize-1)
                {
                    X++;
                }
                else
                    isDead = true;
            }
        }
    }
}
