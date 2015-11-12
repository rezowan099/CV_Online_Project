using CV_Online.Models;
using CV_Online.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CV_Online.BLL
{
    public class Manager
    {
        CVOContext db = new CVOContext();

        public int GetPersonalInfoIdOfCurrentUser(int userId)
        {
            try
            {
                int id = db.PersonalInformations.FirstOrDefault(p => p.UserProfileId == userId).Id;
                db.Dispose();
                return id;
            }
            catch
            {
                db.Dispose();
                return -1;
            }
        }

        public int GetSpecializationId(int userId)
        {
            try
            {
                int PersonalInformationId = db.PersonalInformations.FirstOrDefault(p => p.UserProfileId == userId).Id;
                int id = db.Specializations.FirstOrDefault(p => p.PersonalInfoId == PersonalInformationId).Id;
                db.Dispose();
                return id;
            }
            catch
            {
                db.Dispose();
                return -1;
            }
        }

    }
}