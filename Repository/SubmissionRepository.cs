using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class SubmissionRepository : RepositoryBase<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RepositoryContext repositoryContext)
             : base(repositoryContext)
        {
        }
    }

}
