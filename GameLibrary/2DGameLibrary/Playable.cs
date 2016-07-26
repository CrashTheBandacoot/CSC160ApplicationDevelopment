using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameLibrary
{
    public interface Playable
    {
        void TakeTurn(_2DGameLibrary.Player activePlayer);
    }
}
