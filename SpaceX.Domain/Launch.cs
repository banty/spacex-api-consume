using System;
namespace SpaceX.Domain
{
	public class Launch
	{

		public Launch(int flightNumber,
			string missionName,
			string launchYear,
			DateTime? launchDate,
			bool? launchSuccess,
			string details,
			DateTime staticFireDate)
		{
			FlightNumber = flightNumber;
			MissionName = missionName;
			LaunchSuccess = launchSuccess;
			LaunchDateUTC = launchDate;
			Details = details;
			LaunchYear = launchYear;
			StaticFireDateUTC = staticFireDate;

		}
		
		public int FlightNumber { get; set; }
		public string MissionName { get; set; }
		public string LaunchYear { get; set; }
		public DateTime? LaunchDateUTC { get; set; }
		public bool? LaunchSuccess { get; set; }
		public string Details { get; set; }
		public DateTime StaticFireDateUTC { get; set; }

	}
}

