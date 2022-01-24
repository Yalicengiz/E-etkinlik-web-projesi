using Business.Concrete;
using System;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ActivityManager ActivityManager = new ActivityManager(new EfActivityDal());
            //ActivityManager.Add(new Activity(){ActivityTypeId =1,IsFreeId = 1,ActivityName = "",DailyPrice = 1000,Description = "SATILIK",ModelYear = 1000});
            //ActivityManager.Delete(Activity:new Activity(){Id = 1});
            //ActivityManager.Update(new Activity(){Id = 2,DailyPrice = 30});
            //IsFreeManager IsFreeManager = new IsFreeManager(new EfIsFreeDal());
            //IsFreeManager.Add(new IsFree(){IsFreeName = "Gri"});
            //IsFreeManager.Update(new IsFree(){IsFreeId =1 ,IsFreeName = "Kırmızıı"});
            //IsFreeManager.Delete(new IsFree(){IsFreeId = 11});
            //ActivityTypeManager ActivityTypeManager = new ActivityTypeManager(new EfActivityTypeDal());
            //ActivityTypeManager.Add(new ActivityType() {ActivityTypeName  = "Volvo"});
            //ActivityTest();
            JoinManager JoinManager = new JoinManager(new EfJoinDal());
            //JoinManager.Add(new Join() {ActivityId = 4, CustomerId = 1, RentDate = 2020});
            JoinManager.Update(new Join() {Id = 3,ActivityId = 2, CustomerId = 1, JoinDate = 2020, ReturnDate = 2020});


        }

        private static void ActivityTest()
        {
            ActivityManager ActivityManager = new ActivityManager(new EfActivityDal());
            var result = ActivityManager.GetActivityDetails();
            if (result.Success == true)
            {
                foreach (var Activity in result.Data)
                {
                    Console.WriteLine("Bilgiler:" + Activity.ActivityName +"-"+ Activity.IsFreeName +"-"+ Activity.ActivityTypeName +"-"+ Activity.DailyPrice+Messages.Listed);
                }
            }
            else
            {
                Console.WriteLine("Hatalı");
            }
        }
    }
}
