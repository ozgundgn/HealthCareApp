using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Entity;
using Entity.Models;

namespace Repository.Abstract
{
    public interface IQuestionRepository : IEntityRepository<Question>
    {
    }
}
