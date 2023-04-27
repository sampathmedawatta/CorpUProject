using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class MappingProfile
    {
        private readonly AplicantProfile _AplicantProfile;
        private readonly ApplicantQualificationProfile _ApplicantQualificationProfile;
        private readonly ApplicantContactDetailProfile _ApplicantContactDetailProfile;

        public MappingProfile()
        {
            _AplicantProfile = new AplicantProfile();
            _ApplicantContactDetailProfile = new ApplicantContactDetailProfile();
            _ApplicantQualificationProfile = new ApplicantQualificationProfile();
        }
    }
}
