using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Facility
    {
        private int _facilityId;
        private string _facilityName;

        public int FacilityId
        {
            get => _facilityId;
            set => _facilityId = value;
        }

        public string FacilityName
        {
            get => _facilityName;
            set => _facilityName = value;
        }

        public Facility(int facilityId, string facilityName)
        {
            _facilityId = facilityId;
            _facilityName = facilityName;
        }

        public Facility()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(FacilityId)}: {FacilityId}, {nameof(FacilityName)}: {FacilityName}";
        }
    }
}
