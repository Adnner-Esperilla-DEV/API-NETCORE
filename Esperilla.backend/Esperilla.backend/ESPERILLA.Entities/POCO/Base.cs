using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPERILLA.Entities;

public abstract class Base:IBase
{
    public DateTime Created { get; set; }
    public DateTime Updated{ get; set; }
}
