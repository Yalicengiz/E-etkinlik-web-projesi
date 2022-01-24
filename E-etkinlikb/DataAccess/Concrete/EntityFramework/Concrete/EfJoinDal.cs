using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfJoinDal : EfEntityRepository<Join, ReCapContext>, IJoinDal
    {
        public void DeleteJoin(int id)
        {

            using (ReCapContext context = new ReCapContext())
            {

                var join = context.Join.First(c => c.Id == id);

                context.Remove(join);

                context.SaveChanges();
            }
        }

        public List<JoinDto> GetJoinsByUserId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {

                var result = from p in context.Join
                             join c in context.Activitys on p.ActivityId equals c.Id
                           
                             select new JoinDto
                             {
                                 Id = p.Id,
                                 ActivityId=p.ActivityId,
                                 ActivityName=c.ActivityName,
                                 CustomerId=p.CustomerId,
                                 JoinDate=p.JoinDate,
                                 ReturnDate=p.ReturnDate


                             };

                return result.Where(x => x.CustomerId == id).ToList();
            }
        }
    }
}
