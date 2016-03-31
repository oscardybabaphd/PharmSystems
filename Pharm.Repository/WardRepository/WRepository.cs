using Pharm.Core.Entities;
using Pharm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Repository.WardRepository
{
    public class WRepository : GRepository<Ward>
    {
        public WRepository(bool lazy):base(lazy)
        {

        }

        public IList<Ward> FilterByName(string name)
        {
            var result = GetAll().Where(x => x.Name == name).ToList();
            return result;
        }

        public Ward GetWardByCode(string code)
        {
            var result = GetAll().Where(x => x.Code == code).FirstOrDefault();
            return result;
        }
        public List<Ward> GetWardByPagination(int pageIndex,int pageSize)
        {
            var result = GetByPagination(pageIndex, pageSize);
            return result;
        }
    }
}
