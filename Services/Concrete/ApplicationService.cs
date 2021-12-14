using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstract;
using Service.Abstract;

namespace Service.Concrete
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
    }
}
