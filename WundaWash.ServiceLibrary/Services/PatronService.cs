﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Interfaces;
using WundaWash.Core.Models;
using WundaWash.ServiceLibrary.Interfaces;

namespace WundaWash.ServiceLibrary.Services
{

    public class PatronService : IPatronService
    {
        IPatronRepository _patronRepository;

        public PatronService(IPatronRepository patronRepository)
        {
            _patronRepository = patronRepository;
        }
        public List<Patron> GetAllPatrons()
        {
            return _patronRepository.GetAllPatrons();
        }
    }
}