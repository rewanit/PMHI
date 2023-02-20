using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMHI
{
    public class LogObject : ShowModel
    {
        public LogObject(long elapsedTicks,ShowModel model)
        {
            ElapsedTicks= elapsedTicks;
            this.Size = model.Size;
            this.Range = model.Range;
            
        }

        public long ElapsedTicks { get; set; }
    }
}
