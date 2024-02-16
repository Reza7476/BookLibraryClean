using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavv.Contract;
public interface UnitOfWork
{
    Task Begin();
    Task Complete();
    Task Commit();
    Task RolleBack();


}
