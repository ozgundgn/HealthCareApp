using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Helpers;

namespace Repository.Concrete
{
    public class UserRepository : EntityRepositoryBase<HealtyCareContext, User>, IUserRepository
    {
        public bool SendMail(string message, string emailTo)
        {
            MailHelper mailHelper = new MailHelper("ornekgmail.com", "orneksifre", true);
            return mailHelper.Send(emailTo, message);
        }
        public Address GetUserAddress(int userid)
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                return context.Addresses.Include(x => x.User).FirstOrDefault(x => x.UserId == userid);
            }
        }
        public List<City> GetCityList()
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var cityList = context.Cities.Select(x => new City()
                {
                    Id = x.Id,
                    CityName = x.CityName,
                    District = x.District
                })
                    .ToList();
                return cityList;
            }
        }
        public List<District> GetDistrictList(int id)
        {
            using (HealtyCareContext context = new HealtyCareContext())
            {
                var districtList = context.Districts.Where(x => x.CityId == id).ToList();
                return districtList;
            }
        }
    }
}
