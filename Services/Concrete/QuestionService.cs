using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstract;
using Service.Abstract;

namespace Service.Concrete
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
    }
}
