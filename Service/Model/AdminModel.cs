using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class AdminModel(Guid id)
        : UserModel(id)
    { }
}
