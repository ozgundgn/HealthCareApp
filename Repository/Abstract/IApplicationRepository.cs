﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using Entity.Models;
using Models.Application;

namespace Repository.Abstract
{
    public interface IApplicationRepository : IEntityRepository<Application>
    {
        List<SickApplicationListModel> GetSickApplicationList();
        List<DonorApplicationListModel> GetDonorApplicationList();
        List<Question> GetQuestionList();
        List<City> GetCityList();
        List<District> GetDistrictList(int id);
    }
}
