﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IMongoRepository
    {
        Guid CreateStudent(Student student);
    }
}
