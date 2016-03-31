using Pharm.Core.Entities;
using Pharm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Repository.LGARepository
{
    public class LRepository:GRepository<LGA>
    {
        
        public LRepository(bool lazy):base(lazy)
        {

        }
        public IList<LGA> FilterByName(string name)
        {
            var Result = GetAll().Where(x => x.Name == name).ToList();
            return Result;
        }

        public LGA GetLGAByCode(string code)
        {
            var Result = GetAll().Where(x => x.Code == code).FirstOrDefault();
            return Result;
        }

        public IList<LGA> GetLGAPagination(int pageIndex,int pageSize)
        {
            var result = GetByPagination(pageIndex, pageSize);
            return result;
        }
    }
}
