using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestService.DButil
{
    interface Imanage <T>
    {
        IEnumerable<T> Get();
       

        // GET: api/Hotels/5
        T Get(int id);
        

        // POST: api/Hotels
        bool Post([FromBody] T value);
        

        // PUT: api/Hotels/5
        bool Put(int id, [FromBody] T value);
        
        

        // DELETE: api/Hotels/5
        bool Delete(int id);

    }
}
