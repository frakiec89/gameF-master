using System;

namespace BordF
{
    public class Game
    {
        #region поля 
        int size; // размер 
        Map map; // карта 
        Coord speca; // пробел
        public int moves { get; set; } // ходы 
        #endregion

        public Game ( int  size)
        {
            this.size = size;
            map = new Map(size);
        }

        public  void    Start  ( int  seed=0 )
        {
            int digit = 0;
           
          foreach (Coord  xy in  new  Coord().YieldCoord (size))
            {
                map.Set(xy, ++digit);
            }

            speca = new Coord(size);

            if (seed > 0)
            { Shuffle(seed); }

            moves = 0; 
        }

        void Shuffle  (  int  seed) // перемешивание 
        {
            Random random = new Random(seed);

            for  ( int  k =  0; k  < seed; k++)
            {
                PresAt(random.Next(size), random.Next(size));
            }
        }
            

        public  int  PresAt (  int  x , int  y) // нажатие 
        {
            return PresAt(new Coord(x, y)); // обертка 
        }

        int PresAt( Coord  xy)
        {
            if  ( speca.Equals (xy))
            {
                return 0;
            }

            if  ( xy.x != speca.x &&  xy.y != speca.y)
            {
                return 0;
            }

            int step = Math.Abs(xy.x - speca.x) + Math.Abs(xy.y - speca.y);

            while  (  xy.x != speca.x)
            {
                Shift(Math.Sign (xy.x - speca.x), 0);
            }

            while (xy.y != speca.y)
            {
                Shift( 0 , Math.Sign(xy.y - speca.y));
            }

            moves += step;
            return step;
        }

        void  Shift (  int sx ,int  sy )
        {
            Coord next = speca.Add(sx, sy);
            map.Copy(next, speca);
            speca = next; 

        }

        public  int  GetDigitAt ( int  x , int  y) // определение  номера 
        {
            return GetDigitAt(new Coord(x, y));
        }

        int GetDigitAt( Coord  xy)
        {
            if (speca.Equals(xy))
            {
                return 0;
            }
            return  map.Get( xy);
        }
        
        public  bool  Solved  () // игра  окончена 
        {
            if  (  !speca.Equals ( new Coord (size)))
            {
                return false; 
            }

            int digit = 0;
             foreach (  Coord xy in  new  Coord  ().YieldCoord (size))
            {
                if (map.Get(xy) != ++digit)
                    return speca.Equals(xy);
            }
            return true;
        }
    }
}
