using System;
using System.Collections;

namespace UnixGPSConverter
{

    public static class UGPSC
    {

        public static double[] leaps = new double[]{
            46828800,
            78364801,
            109900802,
            173059203,
            252028804,
            315187205,
            346723206,
            393984007,
            425520008,
            457056009,
            504489610,
            551750411,
            599184012,
            820108813,
            914803214,
            1025136015,
            1119744016,
            1167264017
        };

        public static bool IsLeap(double gpsTime)
        {

            bool isLeap = false;

            for (int x = 0; x < leaps.Length; x++)
            {

                if (gpsTime == leaps[x])
                {

                    isLeap = true;

                }

            }

            return isLeap;

        }

        public static int CountLeaps(double gpsTime, string dirFlag)
        {

            int leapNum = 0;

            for (int x = 0; x < leaps.Length; x++)
            {

                if (dirFlag == "UnixToGPS")
                {

                    if (gpsTime >= leaps[x] - x)
                    {

                        leapNum++;

                    }

                }
                else if (dirFlag == "GPSToUnix")
                {

                    if (gpsTime >= leaps[x])
                    {

                        leapNum++;

                    }

                }
                else
                {

                    throw new System.ArgumentException("ERROR: Invalid conversion string (must be either 'GPSToUnix' or 'UnixToGPS')");

                }

            }

            return leapNum;

        }

        public static double UnixToGPS(double unixTime)
        {

            double gpsTime = 0;
            int isLeap = 0;

            if (unixTime % 1 != 0)
            {

                unixTime = unixTime - 0.5f;
                isLeap = 1;

            }
            else
            {

                isLeap = 0;

            }

            gpsTime = unixTime - (double)315964800;
            int numLeaps = CountLeaps(gpsTime, "UnixToGPS");
            gpsTime += (numLeaps + isLeap);

            return gpsTime;

        }

        public static double GPSToUnix(double gpsTime)
        {

            double unixTime = gpsTime + (double)315964800;

            int numLeaps = CountLeaps(gpsTime, "GPSToUnix");

            unixTime -= numLeaps;

            if (IsLeap(gpsTime))
            {

                unixTime += (double)0.5f;

            }

            return unixTime;

        }

    }

}