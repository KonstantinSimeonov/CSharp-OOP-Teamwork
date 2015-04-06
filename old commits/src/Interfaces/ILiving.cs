using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame.Interfaces
{
    public interface ILiving
    {
        int HitPoints { get; set; }

        bool IsDead { get; }
    }
}
