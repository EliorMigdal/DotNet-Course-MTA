using GarageLogic.Manager;
using System;

namespace GarageLogic.Exceptions
{
    public class VehicleAlreadyExistsException : Exception
    {
        public VehicleAlreadyExistsException(string i_License)
            : base($"Vehicle licensed {i_License} already exists in the garage! Updating state to {eVehicleStatus.Fixing}")
        {

        }
    }
}