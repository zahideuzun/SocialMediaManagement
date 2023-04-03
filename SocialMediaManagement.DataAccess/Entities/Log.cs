using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaManagement.DataAccess.Entities
{
	public class Log
	{
		public int LogId { get; set; }
		public int LogTypeId { get; set; }
		public int? UserId { get; set; }
		public string LogDescription { get; set; }
		public DateTime LogTime { get; set; }

		public LogType LogType { get; set; }
		public virtual User User { get; set; }
	}
}
