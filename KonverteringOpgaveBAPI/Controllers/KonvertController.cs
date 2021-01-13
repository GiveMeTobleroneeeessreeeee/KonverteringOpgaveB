using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonverteringModel;

//domænet er:
//https://localhost:44390

namespace KonverteringOpgaveBAPI.Controllers

{   //nedenstående tilføjes for at få fat i controller
    // /konvert

    [Route("konvert")]
    [ApiController]
    public class KonvertController : ControllerBase
    {
        private const double rateDKSV = 0.7041;

        //Get: kaldes når man blot kalder controller.
        [HttpGet]
        public double GetRate()
        {
            return rateDKSV;
        }

        //nedenstående skrives for at få fat i denn metode.
        //Get: /konvert/NoRate/{antal}/{retning}

        [HttpGet]
        [Route("NoRate/{antal}/{retning}")]
        public double GetKonvert(double antal, string retning)
        {
            double rate = rateDKSV;

            if (retning == "dkktosvk")
            {
                var result = Konvertering.TilSvenskeKroner(antal, rate);
                return result;
            }
            if (retning == "svktodkk")
            {
                var result = Konvertering.TilDanskeKroner(antal, rate);
                return result;
            }
            else
            {
                return 0;
            }

        }

        //Get: /konvert/WithRate/{antal}/{retning}/{rate}

        [HttpGet]
        [Route("WithRate/{antal}/{retning}/{rate}")]
        public double GetKonvertCustomRate(double antal, string retning, double rate)
        {

            if (retning == "dkktosvk")
            {
                
                    var result = Konvertering.TilSvenskeKroner(antal, rate);
                    return result;
            }
            if (retning == "svktodkk")
            {
                    var result = Konvertering.TilDanskeKroner(antal, rate);
                    return result;
            }
            else
            {
                return 0;
            }
            
        }

    }
}
