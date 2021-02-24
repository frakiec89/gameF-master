using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BordF
{
    struct  Map
    {
        private int _size;
        private  int[,] _map;
        public  Map  (  int  size)
        {
            this._size = size;
            _map = new int[size, size];
        }

        public  void Set  (  Coord xy  ,  int  valie)
        {
            if (xy.OnBoard(_size))
            { _map[xy.x, xy.y] = valie; }
        }

        public int  Get (  Coord xy)
        {
            if (xy.OnBoard(_size))
            { return _map[xy.x, xy.y]; }
            return 0; 
        }

        public  void Copy(Coord from, Coord to)
        {
            Set(to, Get(from));
        }
    }
}
