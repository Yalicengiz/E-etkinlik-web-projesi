using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfActivityDal : EfEntityRepository<Activity, ReCapContext>, IActivityDal
    {
        public List<ActivityDetailsDTOs> GetActivityDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from p in context.Activitys
                             join c in context.PriceType on p.PriceTypeId equals c.PriceTypeId
                             join b in context.ActivityType on p.ActivityTypeId equals b.ActivityTypeId
                             select new ActivityDetailsDTOs() 
                             {
                                 Id=p.Id,
                                 PriceTypeId=c.PriceTypeId,
                                 ActivityTypeId=b.ActivityTypeId,
                                 ActivityName = p.ActivityName,
                                 PriceTypeName = c.PriceTypeName,
                                 ActivityTypeName = b.ActivityTypeName,
                                 Description = p.Description,
                                 ActivityLocation = p.ActivityLocation,
                                 ActivityDate = p.ActivityDate,
                                 Price = p.Price,
                                 InsertUserId = p.InsertUserId,
                                 Capacity = p.Capacity


                             };
                return result.ToList();
            }
        }

        public List<ActivityDetailsDTOs> GetActivitysByActivityTypeId(int id)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from p in context.Activitys
                    join c in context.PriceType on p.PriceTypeId equals c.PriceTypeId
                    join b in context.ActivityType on p.ActivityTypeId equals b.ActivityTypeId
                    select new ActivityDetailsDTOs()
                    {
                        Id = p.Id,
                        PriceTypeId = c.PriceTypeId,
                        ActivityTypeId = b.ActivityTypeId,
                        ActivityName = p.ActivityName,
                        PriceTypeName = c.PriceTypeName,
                        ActivityTypeName = b.ActivityTypeName,
                        Description = p.Description,
                        ActivityLocation = p.ActivityLocation,
                        ActivityDate = p.ActivityDate,
                        Price = p.Price,
                        InsertUserId = p.InsertUserId,
                        Capacity = p.Capacity


                    };

                return result.Where(x => x.ActivityTypeId == id).ToList();
            }
        }

        public List<ActivityDetailsDTOs> GetActivitysByPriceTypeId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {

                var result = from p in context.Activitys
                    join c in context.PriceType on p.PriceTypeId equals c.PriceTypeId
                    join b in context.ActivityType on p.ActivityTypeId equals b.ActivityTypeId
                    select new ActivityDetailsDTOs()
                    {
                        Id = p.Id,
                        PriceTypeId = c.PriceTypeId,
                        ActivityTypeId = b.ActivityTypeId,
                        ActivityName = p.ActivityName,
                        PriceTypeName = c.PriceTypeName,
                        ActivityTypeName = b.ActivityTypeName,
                        Description = p.Description,
                        ActivityLocation = p.ActivityLocation,
                        ActivityDate = p.ActivityDate,
                        Price = p.Price,
                        InsertUserId = p.InsertUserId,
                        Capacity= p.Capacity
                        


                    };

                return result.Where(x => x.PriceTypeId == id).ToList();
            }
        }

        public List<Activity> GetActivitysByActivityId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Activity>().Where(p => p.Id == id).ToList();
            }
        }

        public Boolean CapacityCount(int id)
        {

            using (ReCapContext context = new ReCapContext())
            {
                context.Activitys.Where(p => p.Id == id).FirstOrDefault().Capacity = context.Activitys.Where(p => p.Id == id).FirstOrDefault().Capacity - 1;
               context.SaveChanges();
               return true; 
            }
        }

        public bool CapacityCountPlus(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Activitys.Where(p => p.Id == id).FirstOrDefault().Capacity = context.Activitys.Where(p => p.Id == id).FirstOrDefault().Capacity + 1;
                context.SaveChanges();
                return true;
            }
        }
    }
}
