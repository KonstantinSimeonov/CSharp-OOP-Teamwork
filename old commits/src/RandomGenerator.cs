using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCademyGame
{
    // Singleton
    public class RandomGenerator
    {
        private static Random rand;

        public static Random Instance
        {
            get
            {
                if (rand == null)
                {
                    rand = new Random();
                }

                return rand;
            }
        }
    }
}
