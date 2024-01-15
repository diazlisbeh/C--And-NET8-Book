using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;
public class DvdPlayer : IPlayable
{
    public void Pause()
    {
        WriteLine("Pause from DvdPlayer");
    }

    public void Play()
    {
        WriteLine("Playing from DvdPlayer");
    }
}
