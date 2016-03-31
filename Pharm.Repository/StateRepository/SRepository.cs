using Pharm.Core.Entities;
using Pharm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Repository.StateRepository
{
    public class SRepository : GRepository<State>
    {
        public SRepository(bool lazy):base(lazy)
        {

        }
        public State GetStateByCode(string code)
        {
            var Result = GetAll().Where(x => x.Code == code).FirstOrDefault();
            return Result;
        }
    }
}
