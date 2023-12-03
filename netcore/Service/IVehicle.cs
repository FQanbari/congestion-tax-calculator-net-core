using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator.Service
{
    public interface IVehicle
    {
        VehicleEnum Type { get; }
    }
}