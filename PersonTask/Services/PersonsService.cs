using Microsoft.Extensions.Logging;
using PersonsProfileMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsProfileMVC.Services
{
    public class PersonsService:IPersonRepo<PersonsProfile>
    {
        private PersonsProfileContext _context;
        private ILogger<PersonsService> _logger;

        public PersonsService(PersonsProfileContext context, ILogger<PersonsService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(PersonsProfile t)
        {
            try
            {
                _context.persons.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
                throw;
            }
        }
        public PersonsProfile Get(int id)
        {
            try
            {
                PersonsProfile profile = _context.persons.FirstOrDefault(a => a.id == id);
                return profile;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<PersonsProfile> GetAll()
        {
            try
            {
                if (_context.persons.Count() == 0)
                    return null;
                return _context.persons.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

    }
}
